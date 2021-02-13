using IQSoft.eCommerce.Entities.Core;
using IQSoft.eCommerce.Entities.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace IQSoft.eCommerce.BusinessAccess.Contracts
{
    public interface IUserBusinessAccess
    {
        EmployeeProfile GetProfile();
        bool ChangePassword(string existingPassword, string newPassword);
        Users ValidateUser(string userName, string password);
        List<App_vResourceKeyValue> GetResourceKeys(string languageCode);
        bool ForgotPassword(string clientCode, string userName);
        void SavePushNotificationValue(string token, string platform, int loggedInUserId);

        public List<User> Narasimha();
        public object getHomeDataDetails();

        public object GetItemDetailsByCategoy(int categoryId);
    }
}
