using IQSoft.eCommerce.Entities.Core;
using IQSoft.eCommerce.Entities.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace IQSoft.eCommerce.API.Controllers
{
    [Route("[controller]")]
    [Authorize]
    public class CommonController : IQSoftController
    {

        public CommonController(UserContext userContext)
        {
            this.userContext = userContext;
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult UploadFile([FromForm]ICollection<IFormFile> files)
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

                using (var fileStream = new FileStream(Path.Combine(ConfigSettings.Instance.FileSettings.DocumentsFolder, uniqueFileName), FileMode.Create, FileAccess.Write))
                {
                    memoryStream.WriteTo(fileStream);
                    fileStream.Close();
                    memoryStream.Close();
                }
            }

            return Ok(uniqueFileName);
        }

        [Route("[action]")]
        [AllowAnonymous]
        [HttpGet]
        public IActionResult DownloadFile(string filename)
        {
            var path = Path.Combine(ConfigSettings.Instance.FileSettings.DocumentsFolder, filename);

            var memory = new MemoryStream();
            using (var fileStream = new FileStream(path, FileMode.Open))
            {
                fileStream.CopyTo(memory);
            }
            memory.Position = 0;
            var contentType = "image/png";

            try
            {
                contentType = GetContentType(path);
            }
            catch (Exception)
            {
                contentType = "image/png";
            }

            return File(memory, contentType, Path.GetFileName(path));
        }

        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformats officedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }
    }
}
