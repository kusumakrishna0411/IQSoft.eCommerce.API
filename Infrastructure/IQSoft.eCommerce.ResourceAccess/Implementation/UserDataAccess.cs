﻿using IQSoft.eCommerce.Entities.Security;
using IQSoft.eCommerce.ResourceAccess.Contracts;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using IQSoft.eCommerce.Utilities.Extensions;
using IQSoft.eCommerce.Utilities.Communication;
using System;
using IQSoft.eCommerce.Entities.Core;

namespace IQSoft.eCommerce.ResourceAccess.Implementation
{
    public class UserDataAccess : DataAccess, IUserDataAccess
    {
        public UserDataAccess(UserContext userContext)
            : base(userContext)
        {

        }

        public EmployeeProfile GetProfile()
        {
            var employeeProfile = this.clientDbContext.EmployeeProfiles($"UserID = {userContext.LoggedInUserId}").FirstOrDefault();
            employeeProfile.Password = "";

            return employeeProfile;
        }

        public bool ChangePassword(string existingPassword, string newPassword)
        {
            var employeeProfile = this.clientDbContext.EmployeeProfiles($"UserID = {userContext.LoggedInUserId}").FirstOrDefault();

            if (!string.Equals(employeeProfile.Password, existingPassword.ToHash(), System.StringComparison.OrdinalIgnoreCase))
            {
                throw new ApplicationException("Invalid password");
            }

            var parmsCollection = new ParmsCollection();
            var selectedUser = this.clientDbContext.ExecuteStoredProcedure_ToList<User>("[MobileApp].[changePassword]",
                    parmsCollection
                        .AddParm("@userId", SqlDbType.Int, userContext.LoggedInUserId)
                        .AddParm("@newPassword", SqlDbType.VarChar, newPassword.ToHash())
                    ).FirstOrDefault();

            return true; ;
        }

        public bool ForgotPassword(string clientCode, string userName)
        {
            var result = default(bool);

            var client = this.commonDbContext.Clients().FirstOrDefault(c => c.ClientCode == clientCode);

            if (client != null)
            {
                var clientDbContext = new ClientDbContext();
                var randomPassword = StringExtensions.RandomString(6);
                var parmsCollection = new ParmsCollection();

                var selectedUser = clientDbContext.ExecuteStoredProcedure_ToList<User>("[MobileApp].[resetUserPassword]",
                    parmsCollection
                        .AddParm("@userName", SqlDbType.VarChar, userName)
                        .AddParm("@password", SqlDbType.VarChar, randomPassword.ToHash())
                    ).FirstOrDefault();

                if (selectedUser != null)
                {
                    result = true;
                    var employee = clientDbContext.Employees($"EmployeeID = {selectedUser.RefRecordID}").FirstOrDefault();

                    if (employee != null) { selectedUser.Email = employee.Email; }

                    if (!string.IsNullOrWhiteSpace(selectedUser.Email))
                    {
                        EmailTemplates.SendForgotPasswordEmail(selectedUser.Email, userName, randomPassword);
                    }
                }
            }

            return result;
        }

        public Users ValidateUser(string userName, string password)
        {
            var clientDbContext = new ClientDbContext();
            Users result;
            {
                var parmsCollection = new ParmsCollection();
                result = this.clientDbContext.ExecuteStoredProcedure_ToList<Users>("[dbo].[validateUserCredentials]",
                   parmsCollection
                       .AddParm("@userName", SqlDbType.VarChar, userName)
                       .AddParm("@password", SqlDbType.VarChar, password)
                   ).FirstOrDefault();

            }
            return result;

        }

        public List<User> Narasimha()
        {
            var clientDbContext = new ClientDbContext();
            return clientDbContext.Users().ToList();

        }

        public List<App_vResourceKeyValue> GetResourceKeys(string languageCode)
        {
            if (string.IsNullOrWhiteSpace(languageCode)) languageCode = "EN";
            return this.clientDbContext.App_vResourceKeyValues($"LanguageCode = '{languageCode}'");
        }

        public void SavePushNotificationValue(string token, string platform, int loggedInUserId)
        {
            var query = $"INSERT INTO [dbo].[App_UserToken] (DeviceToken, Platform, UserId, RecordStatus, CreatedDate) VALUES(N'{token}',N'{platform}',{loggedInUserId},'Active',GETDATE())";
            this.commonDbContext.ExecuteNonQuery(query);
        }

        public object getHomeDataDetails()
        {
            var clientDbContext = new ClientDbContext();
            return clientDbContext.ExecuteScalar("SELECT [dbo].[fn_GetHomeDataDetails]()");

        }
    }
}