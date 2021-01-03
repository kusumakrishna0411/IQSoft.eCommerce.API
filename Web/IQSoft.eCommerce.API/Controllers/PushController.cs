using FirebaseAdmin;
using FirebaseAdmin.Auth;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using IQSoft.eCommerce.BusinessAccess.Contracts;
using IQSoft.eCommerce.Entities.Core;
using IQSoft.eCommerce.Entities.Dts;
using IQSoft.eCommerce.Entities.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IQSoft.eCommerce.API.Controllers
{
    [Route("[controller]")]
    [Authorize]
    public class PushController : IQSoftController
    {
        private readonly FirebaseMessaging messaging;
        FirebaseApp app;
        /*
         * Refer this
         * https://firebase.google.com/docs/admin/setup/#windows        
        */
        public PushController(UserContext userContext, IDtsBusinessAccess dtsBusinessAccess)
        {
            this.userContext = userContext;

            app = FirebaseApp.Create(new AppOptions() { Credential = GoogleCredential.FromFile(ConfigSettings.Instance.FileSettings.GoogleFirebaseFile).CreateScoped("https://www.googleapis.com/auth/firebase.messaging") });
            messaging = FirebaseMessaging.GetMessaging(app);
        }

        [Route("[action]")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> TriggerMessage([FromBody]TriggerMessageRequest request)
        {
            //var clientTokens = new List<string>();
            var registrationTokens = request.UserIds.ToList();

            var message = new MulticastMessage()
            {
                Tokens = registrationTokens,
                Notification = new Notification()
                 {
                     Title =  request.Title,
                     Body = request.Message
                 }
            };
            var result = await messaging.SendMulticastAsync(message);
            //var response = FirebaseMessaging.GetMessaging(FirebaseApp.GetInstance("salesforce247app")).SendMulticastAsync(message).ConfigureAwait(true);
            app.Delete();
            return Ok(true);
        }

        

    }

    public class TriggerMessageRequest
    {
        public List<string> UserIds { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
    }

}
