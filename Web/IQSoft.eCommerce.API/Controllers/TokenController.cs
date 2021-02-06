using IQSoft.eCommerce.API.Security;
using IQSoft.eCommerce.BusinessAccess.Contracts;
using IQSoft.eCommerce.Entities.Core;
using IQSoft.eCommerce.Entities.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace IQSoft.eCommerce.API.Controllers
{
    [Route("[controller]")]
    public class TokenController : IQSoftController
    {
        private ITokenProvider _tokenProvider;
        private IUserBusinessAccess userBusinessAccess;
        private readonly ILogger _logger;

        public TokenController(UserContext userContext, ITokenProvider tokenProvider, IUserBusinessAccess userBusinessAccess, ILogger<TokenController> logger)
        {
            this.userContext = userContext;
            _tokenProvider = tokenProvider;
            this._logger = logger;
            this.userBusinessAccess = userBusinessAccess;
        }

        [Route("[action]")]
        [HttpGet]
        [Authorize]
        public IActionResult SavePushNotificationValue(string token, string platform)
        {
            try
            {
                this.userBusinessAccess.SavePushNotificationValue(token, platform, this.userContext.LoggedInUserId);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, "SavePushNotificationValue", token, platform);
            }
            return Ok(true);
        }

        [Route("[action]")]
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Generate(string userName, string password)
        {
            var token = _tokenProvider.CreateToken(userName, password);
            if (token.access_token is null)
            {
                return BadRequest("Credentials are invalid!.");
            }
            return Ok(token);
        }

        [Route("[action]")]
        [HttpPost]
        [AllowAnonymous]
        public IActionResult ForgotPassword([FromBody] LoginViewModel model)
        {
            var result = this.userBusinessAccess.ForgotPassword(model.ClientCode, model.username);
            return Ok(result);
        }

        [Route("[action]")]
        [HttpPost]
        [Authorize]
        public IActionResult ChangePassword([FromBody] ChangePasswordViewModel changePasswordViewModel)
        {
            this.userBusinessAccess.ChangePassword(changePasswordViewModel.ExistingPassword, changePasswordViewModel.NewPassword);
            return Ok(true);
        }

        [Route("[action]")]
        [HttpGet]
        [Authorize]
        public IActionResult GetProfile()
        {
            var docsFolder = Path.Combine(ConfigSettings.Instance.FileSettings.DocumentsFolder, "UserProfile");
            if (!Directory.Exists(docsFolder)) { Directory.CreateDirectory(docsFolder); }

            var userProfile = this.userBusinessAccess.GetProfile();

            string[] profilePhotos = Directory.GetFiles(docsFolder, $"{userProfile.UserID}.*");
            var profilePhotoPath = (profilePhotos == null || profilePhotos.Length == 0) ? "noimage.png" : Path.GetFileName(profilePhotos[0]);
            var photoPath = @"https://images.IQSoft.com.vn/UserProfile/" + profilePhotoPath;
            userProfile.PhotoUrl = photoPath;

            return Ok(userProfile);
        }

        [Route("[action]")]
        [HttpGet]
        [Authorize]
        public IActionResult GetResourceKeys(string languageCode)
        {
            return Ok(this.userBusinessAccess.GetResourceKeys(languageCode));
        }

        [Route("[action]")]
        [HttpGet]
        [Authorize]
        public IActionResult Narasimha()
        {
            return Ok(this.userBusinessAccess.Narasimha());
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult UploadPhoto([FromForm] ICollection<IFormFile> files)
        {
            if ((files == null || files.Count == 0) && (Request.Form.Files.Count == 0))
                return Ok(false);

            var uniqueFileName = string.Empty;

            using (var memoryStream = new MemoryStream())
            {
                var fileName = string.Empty;
                if (files != null && files.Count > 0)
                {
                    files.First().CopyTo(memoryStream);
                    fileName = files.First().FileName;
                }
                else
                {
                    Request.Form.Files.First().CopyTo(memoryStream);
                    fileName = Request.Form.Files.First().FileName;
                }

                var extension = System.IO.Path.GetExtension(fileName);
                uniqueFileName = $"{Guid.NewGuid()}{extension}";

                if (this.Request.Headers["FileName"].Any())
                {
                    uniqueFileName = this.Request.Headers["FileName"].First();
                }

                memoryStream.Position = 0;

                var docsFolder = Path.Combine(ConfigSettings.Instance.FileSettings.DocumentsFolder, "UserProfile");

                if (!Directory.Exists(docsFolder)) { Directory.CreateDirectory(docsFolder); }

                string[] profilePhotos = Directory.GetFiles(docsFolder, $"{this.userContext.LoggedInUserId}.*");
                foreach (var item in profilePhotos)
                {
                    System.IO.File.Delete(item);
                }

                uniqueFileName = this.userContext.LoggedInUserId.ToString() + System.IO.Path.GetExtension(uniqueFileName);

                using (var fileStream = new FileStream(Path.Combine(docsFolder, uniqueFileName), FileMode.Create, FileAccess.Write))
                {
                    memoryStream.WriteTo(fileStream);
                    fileStream.Close();
                    memoryStream.Close();
                }
            }

            return Ok(uniqueFileName);
        }

    }

    public class ChangePasswordViewModel
    {
        public string ExistingPassword { get; set; }
        public string NewPassword { get; set; }
    }
    public class LoginViewModel
    {
        public string grant_type { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        //For Mobile
        public string MobileNumber { get; set; }
        public string ClientCode { get; set; }
        public string DeviceId { get; set; }

        public string TokenValue { get; set; }
        public string SimInfo { get; set; }
    }
}
