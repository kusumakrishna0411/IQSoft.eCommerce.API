﻿using IQSoft.eCommerce.Entities.Core;
using IQSoft.eCommerce.Entities.Security;
using System.Collections.Generic;

namespace IQSoft.eCommerce.ResourceAccess.Contracts
{
    public interface IUserDataAccess
    {
        EmployeeProfile GetProfile();
        bool ChangePassword(string existingPassword, string newPassword);
        Users ValidateUser(string userName, string password);
        bool ForgotPassword(string clientCode, string userName);
        void SavePushNotificationValue(string token, string platform, int loggedInUserId);
        List<App_vResourceKeyValue> GetResourceKeys(string languageCode);

        public List<User> Narasimha();

        public object getHomeDataDetails();
    }
}