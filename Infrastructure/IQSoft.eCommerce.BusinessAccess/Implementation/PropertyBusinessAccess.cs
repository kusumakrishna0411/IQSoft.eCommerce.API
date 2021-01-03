using IQSoft.eCommerce.BusinessAccess.Contracts;
using IQSoft.eCommerce.Entities.Core;
using IQSoft.eCommerce.Entities.Operations;
using IQSoft.eCommerce.Entities.Security;
using IQSoft.eCommerce.ResourceAccess.Contracts;
using System.Collections.Generic;

namespace IQSoft.eCommerce.BusinessAccess.Implementation
{
    public class PropertyBusinessAccess : IPropertyBusinessAccess
    {
        private IPropertyDataAccess propertyDataAccess;
        public PropertyBusinessAccess(UserContext userContext, IPropertyDataAccess propertyDataAccess)
        {
            this.propertyDataAccess = propertyDataAccess;
        }
        public PropertyMetaData GetPropertyMetaDataById(int propertyId)
        {
            return this.propertyDataAccess.GetPropertyMetaDataById(propertyId);
        }

        public bool AddAppProspect(App_Prospect prospect)
        {
            return this.propertyDataAccess.AddAppProspect(prospect);
        }

        public bool AddAppSale(App_Sale sale)
        {
            return this.propertyDataAccess.AddAppSale(sale);
        }

        public List<vw_Property> GetAllProperties()
        {
            return this.propertyDataAccess.GetAllProperties();
        }

        public List<vw_Phase> GetAllPhases()
        {
            return this.propertyDataAccess.GetAllPhases();
        }

        public List<App_Gender> GetAppGenders()
        {
            return this.propertyDataAccess.GetAppGenders();
        }

        public List<App_Identity> GetApp_Identities()
        {
            return this.propertyDataAccess.GetApp_Identities();
        }

        public List<App_Nationality> GetApp_Nationalities()
        {
            return this.propertyDataAccess.GetApp_Nationalities();
        }

        public List<vw_Unit> GetApp_SaleAgentByProjectId(int projectId)
        {
            return this.propertyDataAccess.GetApp_SaleAgentByProjectId(projectId);
        }

        public List<vw_PS_Prospect> GetPS_ProspectsByCreatedUserId(int projectId, int createdUserId)
        {
            return this.propertyDataAccess.GetPS_ProspectsByCreatedUserId(projectId, createdUserId);
        }

        public List<vw_PS_Prospect> GetPS_ProspectsByProjectId(int projectId)
        {
            return this.propertyDataAccess.GetPS_ProspectsByProjectId(projectId);
        }

        public List<vw_PS_Prospect> GetAllAccounts(string searchText, bool includeNew)
        {
            return this.propertyDataAccess.GetAllAccounts(searchText, includeNew);
        }

        public List<AgentSale> GetSalesByAgentId(int agentId)
        {
            return this.propertyDataAccess.GetSalesByAgentId(agentId);
        }
        public List<vw_Unit> GetSalesByProjectId(int projectId, int phaseId)
        {
            return this.propertyDataAccess.GetSalesByProjectId(projectId, phaseId);
        }

        public List<YearSale> GetAllSales()
        {
            return this.propertyDataAccess.GetAllSales();
        }

        public List<App_TaskList> GetApp_TaskListsBySaleId(int saleId)
        {
            return this.propertyDataAccess.GetApp_TaskListsBySaleId(saleId);
        }
        public List<vw_PS_PaymentHistory> GetPaymentHistoryByUnitId(int unitId)
        {
            return this.propertyDataAccess.GetPaymentHistoryByUnitId(unitId);
        }
        public List<App_ProspectFollowUp> GetProspectFollowUps(string prospectNo)
        {
            return this.propertyDataAccess.GetProspectFollowUps(prospectNo);
        }

        public bool AddAppProspectFollowUp(App_ProspectFollowUp prospect)
        {
            return this.propertyDataAccess.AddAppProspectFollowUp(prospect);
        }

        public List<App_SaleAgent> GetSaleAgents()
        {
            return this.propertyDataAccess.GetSaleAgents();
        }
        public bool TransferProspect(App_ProspectTransfer prospectTransfer)
        {
            return this.propertyDataAccess.TransferProspect(prospectTransfer);
        }

        public bool UpdateAppTaskItem(App_TaskList taskList)
        {
            return this.propertyDataAccess.UpdateAppTaskItem(taskList);
        }

        public bool IsDuplicateProspect(App_Prospect prospect)
        {
            return this.propertyDataAccess.IsDuplicateProspect(prospect);
        }
        public List<vw_UnitActiveAgg> GetAvailableUnitsCount(int projectId, int phaseId, int blockId)
        {
            return this.propertyDataAccess.GetAvailableUnitsCount(projectId, phaseId, blockId);
        }
        public List<vw_Unit> GetAvailableUnits(int projectId, int phaseId, int blockId, string floorName, int unitTypeId)
        {
            return this.propertyDataAccess.GetAvailableUnits(projectId, phaseId, blockId, floorName, unitTypeId);
        }

        public bool CancelBooking(App_Sale saleRequest)
        {
            return this.propertyDataAccess.CancelBooking(saleRequest);
        }

        public bool ConvertToSale(App_Sale saleRequest)
        {
            return this.propertyDataAccess.ConvertToSale(saleRequest);
        }

        public bool ConvertToBook(App_Sale saleRequest)
        {
            return this.propertyDataAccess.ConvertToBook(saleRequest);
        }

        public List<Currency> GetCurrencies()
        {
            return this.propertyDataAccess.GetCurrencies();
        }
        public List<App_UserToken> GetNotifications()
        {
            return this.propertyDataAccess.GetNotifications();
        }
        public List<vw_BankAccount> GetBankAccounts(int unitId, int currencyId)
        {
            return this.propertyDataAccess.GetBankAccounts(unitId, currencyId);
        }

        public List<DashboardData> GetDashboardData(string teamOrAgent = "", int teamId = 0, int agentId = 0, int selectedProjectId = 0, bool showAll = false)
        {
            return this.propertyDataAccess.GetDashboardData(teamOrAgent, teamId, agentId, selectedProjectId, showAll);
        }

        public List<PropertyData> GetPropertyData()
        {
            return this.propertyDataAccess.GetPropertyData();
        }

        public List<TeamData> GetTeamData(string teamOrAgent = "")
        {
            return this.propertyDataAccess.GetTeamData(teamOrAgent);
        }

        public List<ProspectData> GetProspectData()
        {
            return this.propertyDataAccess.GetProspectData();
        }
    }
}
