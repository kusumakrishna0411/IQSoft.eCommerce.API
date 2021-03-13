using IQSoft.eCommerce.Entities.Core;
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

        public object GetItemDetailsByCategoy(int categoryId);

        public object GetItemDetailsByCategoy2(int categoryId);

        public object GetProductResults(int categoryId);

        public object GetProductDetails(int productId);

        public object GetAdditionalFiltersInfo(int categoryId);

        public object GetFilterInfoByType(int categoryId);

        public object GetMenusDetails();

        public object GetCartInfo(int categoryId);
    }
}
