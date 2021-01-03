using IQSoft.eCommerce.Entities.Core;
using IQSoft.eCommerce.Entities.Dts;
using IQSoft.eCommerce.Entities.Operations;
using IQSoft.eCommerce.Entities.Security;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace IQSoft.eCommerce.ResourceAccess
{
    public class ClientDbContext : BaseDbContext
    {
        public ClientDbContext()
       : base(DbConnector.Instance.GetClientConnectionString())
        {

        }

        public List<User> Users(string whereCondition = "", string orderBy = "", bool isCache = true)
        {
            return this.GetTable<User>(ClientDbTableNames.User, whereCondition, orderBy, isCache);
        }
        public List<CF_Employee> Employees(string whereCondition = "", string orderBy = "", bool isCache = true)
        {
            return this.GetTable<CF_Employee>(ClientDbTableNames.Employee, whereCondition, orderBy, isCache);
        }
        public List<vw_User> vw_Users(string whereCondition = "", string orderBy = "", bool isCache = true)
        {
            return this.GetTable<vw_User>(ClientDbTableNames.vw_User, whereCondition, orderBy, isCache);
        }
        public List<Opportunity> Opportunities(string whereCondition = "", string orderBy = "", bool isCache = true)
        {
            return this.GetTable<Opportunity>(ClientDbTableNames.vw_Opportunity, whereCondition, orderBy, isCache);
        }
        public List<vw_Property> Properties(string whereCondition = "", string orderBy = "", bool isCache = true)
        {
            return this.GetTable<vw_Property>(ClientDbTableNames.vw_Property, whereCondition, orderBy, isCache);
        }
        public List<vw_Phase> Phases(string whereCondition = "", string orderBy = "", bool isCache = true)
        {
            return this.GetTable<vw_Phase>(ClientDbTableNames.vw_Phase, whereCondition, orderBy, isCache);
        }
        public List<vw_Block> Blocks(string whereCondition = "", string orderBy = "", bool isCache = true)
        {
            return this.GetTable<vw_Block>(ClientDbTableNames.vw_Block, whereCondition, orderBy, isCache);
        }
        public List<vw_Unit> Units(string whereCondition = "", string orderBy = "", bool isCache = true)
        {
            return this.GetTable<vw_Unit>(ClientDbTableNames.vw_Unit, whereCondition, orderBy, isCache);
        }
        public List<BookUnit> BookUnits(string whereCondition = "", string orderBy = "", bool isCache = true)
        {
            return this.GetTable<BookUnit>(ClientDbTableNames.BookUnit, whereCondition, orderBy, isCache);
        }
        public List<vw_PS_Prospect> vw_PS_Prospects(string whereCondition = "", string orderBy = "", bool isCache = true)
        {
            return this.GetTable<vw_PS_Prospect>(ClientDbTableNames.vw_PS_Prospect, whereCondition, orderBy, isCache);
        }
        public List<Currency> Currencies(string whereCondition = "", string orderBy = "", bool isCache = true)
        {
            return this.GetTable<Currency>(ClientDbTableNames.Currency, whereCondition, orderBy, isCache);
        }
        public List<App_UserToken> App_UserTokens(string whereCondition = "", string orderBy = "", bool isCache = true)
        {
            return this.GetTable<App_UserToken>(ClientDbTableNames.vw_App_UserToken, whereCondition, orderBy, isCache);
        }
        public List<vw_BankAccount> BankAccounts(string whereCondition = "", string orderBy = "", bool isCache = true)
        {
            return this.GetTable<vw_BankAccount>(ClientDbTableNames.vw_BankAccount, whereCondition, orderBy, isCache);
        }
        public List<App_SaleAgent> App_SaleAgents(string whereCondition = "", string orderBy = "", bool isCache = true)
        {
            return this.GetTable<App_SaleAgent>(ClientDbTableNames.App_SaleAgent, whereCondition, orderBy, isCache);
        }
        public List<App_Prospect> App_Prospects(string whereCondition = "", string orderBy = "", bool isCache = true)
        {
            return this.GetTable<App_Prospect>(ClientDbTableNames.App_Prospect, whereCondition, orderBy, isCache);
        }
        public List<App_ProspectFollowUp> App_ProspectFollowUps(string whereCondition = "", string orderBy = "", bool isCache = true)
        {
            return this.GetTable<App_ProspectFollowUp>(ClientDbTableNames.App_ProspectFollowUp, whereCondition, orderBy, isCache);
        }
        public List<vw_PS_PaymentHistory> vw_PS_PaymentHistory(string whereCondition = "", string orderBy = "", bool isCache = true)
        {
            return this.GetTable<vw_PS_PaymentHistory>(ClientDbTableNames.vw_PS_PaymentHistory, whereCondition, orderBy, isCache);
        }
        public List<vw_UnitActiveAgg> vw_UnitActiveAggs(string whereCondition = "", string orderBy = "", bool isCache = true)
        {
            return this.GetTable<vw_UnitActiveAgg>(ClientDbTableNames.vw_UnitActiveAgg, whereCondition, orderBy, isCache);
        }
        public List<App_Gender> App_Genders(string whereCondition = "", string orderBy = "", bool isCache = true)
        {
            return this.GetTable<App_Gender>(ClientDbTableNames.App_Gender, whereCondition, orderBy, isCache);
        }
        public List<App_Identity> App_Identities(string whereCondition = "", string orderBy = "", bool isCache = true)
        {
            return this.GetTable<App_Identity>(ClientDbTableNames.App_Identity, whereCondition, orderBy, isCache);
        }
        public List<AgentSale> AgentSales(string whereCondition = "", string orderBy = "", bool isCache = true)
        {
            return this.GetTable<AgentSale>(ClientDbTableNames.vw_PS_AgentSale, whereCondition, orderBy, isCache);
        }
        public List<App_Nationality> App_Nationalities(string whereCondition = "", string orderBy = "", bool isCache = true)
        {
            return this.GetTable<App_Nationality>(ClientDbTableNames.App_Nationality, whereCondition, orderBy, isCache);
        }
        public List<App_Sale> App_Sales(string whereCondition = "", string orderBy = "", bool isCache = true)
        {
            return this.GetTable<App_Sale>(ClientDbTableNames.App_Sale, whereCondition, orderBy, isCache);
        }
        public List<App_TaskList> App_TaskLists(string whereCondition = "", string orderBy = "", bool isCache = true)
        {
            return this.GetTable<App_TaskList>(ClientDbTableNames.App_TaskList, whereCondition, orderBy, isCache);
        }
        public List<PS_DefectHeader> PS_DefectHeaders(string whereCondition = "", string orderBy = "", bool isCache = true)
        {
            return this.GetTable<PS_DefectHeader>(ClientDbTableNames.PS_DefectHeader, whereCondition, orderBy, isCache);
        }
        public List<PS_DefectItem> PS_DefectItems(string whereCondition = "", string orderBy = "", bool isCache = true)
        {
            return this.GetTable<PS_DefectItem>(ClientDbTableNames.PS_DefectItem, whereCondition, orderBy, isCache);
        }
        public List<CF_Document> CF_Documents(string whereCondition = "", string orderBy = "", bool isCache = true)
        {
            return this.GetTable<CF_Document>(ClientDbTableNames.CF_Document, whereCondition, orderBy, isCache);
        }
        public List<PS_DefectItemFollowUp> PS_DefectItemFollowUps(string whereCondition = "", string orderBy = "", bool isCache = true)
        {
            return this.GetTable<PS_DefectItemFollowUp>(ClientDbTableNames.PS_DefectItemFollowUp, whereCondition, orderBy, isCache);
        }
        public List<App_DtsType> App_DtsTypes(string whereCondition = "", string orderBy = "", bool isCache = true)
        {
            return this.GetTable<App_DtsType>(ClientDbTableNames.App_DtsType, whereCondition, orderBy, isCache);
        }
        public List<vw_App_Dts> vw_App_Dts(string whereCondition = "", string orderBy = "", bool isCache = true)
        {
            return this.GetTable<vw_App_Dts>(ClientDbTableNames.vw_App_Dts, whereCondition, orderBy, isCache);
        }
        public List<CF_Activity> Activities(string whereCondition = "", string orderBy = "", bool isCache = true)
        {
            return this.GetTable<CF_Activity>(ClientDbTableNames.CF_Activity, whereCondition, orderBy, isCache);
        }
        public List<VIEW_CF_Activity_Mobile> vw_Activities(string whereCondition = "", string orderBy = "", bool isCache = true)
        {
            return this.GetTable<VIEW_CF_Activity_Mobile>(ClientDbTableNames.VIEW_CF_Activity_Mobile, whereCondition, orderBy, isCache);
        }
        public List<EmployeeProfile> EmployeeProfiles(string whereCondition = "", string orderBy = "", bool isCache = true)
        {
            return this.GetTable<EmployeeProfile>(ClientDbTableNames.EmployeeProfile, whereCondition, orderBy, isCache);
        }
        public List<App_vResourceKeyValue> App_vResourceKeyValues(string whereCondition = "", string orderBy = "", bool isCache = true)
        {
            return this.GetTable<App_vResourceKeyValue>(ClientDbTableNames.App_vResourceKeyValue, whereCondition, orderBy, isCache);
        }

    }

    public class ClientDbTableNames
    {
        public const string User = "dbo.Users";
        public const string Employee = "dbo.CF_Employee";
        public const string vw_User = "MobileApp.vw_Users";
        public const string vw_Opportunity = "dbo.vw_Opportunity";
        public const string vw_Property = "MobileApp.vw_Property";
        public const string vw_Phase = "MobileApp.vw_Phase";
        public const string vw_Block = "MobileApp.vw_Block";
        public const string vw_Unit = "MobileApp.vw_Unit";
        public const string BookUnit = "dbo.BookUnit";
        public const string vw_PS_Prospect = "MobileApp.vw_PS_Prospect";
        public const string Currency = "dbo.CF_Currency";
        
        public const string vw_App_UserToken = "MobileApp.vw_App_UserToken";
        public const string vw_BankAccount = "MobileApp.vw_BankAccount";
        public const string App_SaleAgent = "dbo.App_SaleAgent";
        public const string App_Prospect = "dbo.App_Prospect";
        public const string App_ProspectFollowUp = "dbo.App_ProspectFollowUp";
        public const string vw_PS_PaymentHistory = "MobileApp.vw_PS_PaymentHistory";
        public const string vw_UnitActiveAgg = "MobileApp.vw_UnitActiveAgg";
        
        public const string App_Gender = "dbo.App_Gender";
        public const string App_Identity = "dbo.App_Identity";
        public const string vw_PS_AgentSale = "MobileApp.vw_PS_AgentSale";
        public const string App_Nationality = "dbo.App_Nationality";
        public const string App_Sale = "dbo.App_Sale";
        public const string App_TaskList = "dbo.App_TaskList";

        public const string PS_DefectHeader = "dbo.PS_DefectHeader";
        public const string PS_DefectItem = "dbo.PS_DefectItem";
        public const string CF_Document = "dbo.CF_Document";
        public const string PS_DefectItemFollowUp = "dbo.PS_DefectItemFollowUp";

        public const string App_DtsType = "MobileApp.App_DtsType";
        public const string vw_App_Dts = "MobileApp.vw_App_Dts";

        public const string CF_Activity = "dbo.CF_Activity";
        public const string VIEW_CF_Activity_Mobile = "dbo.VIEW_CF_Activity_Mobile";

        public const string EmployeeProfile = "MobileApp.EmployeeProfile";
        public const string App_vResourceKeyValue = "MobileApp.App_vResourceKeyValue";

    }
}
