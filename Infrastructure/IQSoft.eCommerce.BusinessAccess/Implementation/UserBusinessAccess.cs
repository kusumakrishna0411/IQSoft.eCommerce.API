using IQSoft.eCommerce.BusinessAccess.Contracts;
using IQSoft.eCommerce.Entities.Core;
using IQSoft.eCommerce.Entities.Security;
using IQSoft.eCommerce.ResourceAccess.Contracts;
using System.Collections.Generic;

namespace IQSoft.eCommerce.BusinessAccess.Implementation
{
    public class UserBusinessAccess : IUserBusinessAccess
    {
        private IUserDataAccess userDataAccess;
        public UserBusinessAccess(UserContext userContext, IUserDataAccess userDataAccess)
        {
            this.userDataAccess = userDataAccess;
        }

        public EmployeeProfile GetProfile()
        {
            return this.userDataAccess.GetProfile();
        }
        public bool ChangePassword(string existingPassword, string newPassword)
        {
            return this.userDataAccess.ChangePassword(existingPassword, newPassword);
        }

        public bool ForgotPassword(string clientCode, string userName)
        {
            return this.userDataAccess.ForgotPassword(clientCode, userName);
        }

        public Users ValidateUser(string userName, string password)
        {
            return this.userDataAccess.ValidateUser(userName, password);
        }

        public List<App_vResourceKeyValue> GetResourceKeys(string languageCode)
        {
            return this.userDataAccess.GetResourceKeys(languageCode);
        }

        public void SavePushNotificationValue(string token, string platform, int loggedInUserId)
        {
            this.userDataAccess.SavePushNotificationValue(token, platform, loggedInUserId);
        }

        public List<User> Narasimha()
        {
            return this.userDataAccess.Narasimha();
        }
        public object getHomeDataDetails()
        {
            return this.userDataAccess.getHomeDataDetails();
        }

        public object GetItemDetailsByCategoy(int categoryId)
        {
            return this.userDataAccess.GetItemDetailsByCategoy(categoryId);
        }

        public object GetItemDetailsByCategoy2(int categoryId)
        {
            return this.userDataAccess.GetItemDetailsByCategoy2(categoryId);
        }

        public object GetProductResults(int categoryId)
        {
            return this.userDataAccess.GetProductResults(categoryId);
        }

        public object GetProductDetails(int productId)
        {
            return this.userDataAccess.GetProductDetails(productId);
        }

        public object GetAdditionalFiltersInfo(int categoryId)
        {
            return this.userDataAccess.GetAdditionalFiltersInfo(categoryId);
        }
    }
   
}
