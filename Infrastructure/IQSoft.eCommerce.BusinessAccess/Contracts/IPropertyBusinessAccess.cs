using IQSoft.eCommerce.Entities.Core;
using IQSoft.eCommerce.Entities.Operations;
using System.Collections.Generic;

namespace IQSoft.eCommerce.BusinessAccess.Contracts
{
    public interface IPropertyBusinessAccess
    {
        List<vw_Property> GetAllProperties();
        List<vw_Phase> GetAllPhases();
        PropertyMetaData GetPropertyMetaDataById(int propertyId);

        List<App_Gender> GetAppGenders();
        List<App_Identity> GetApp_Identities();
        List<App_Nationality> GetApp_Nationalities();

        List<vw_PS_Prospect> GetPS_ProspectsByProjectId(int projectId);
        List<vw_PS_Prospect> GetAllAccounts(string searchText, bool includeNew);
        List<vw_Unit> GetApp_SaleAgentByProjectId(int projectId);
        List<vw_PS_Prospect> GetPS_ProspectsByCreatedUserId(int projectId, int createdUserId);

        List<AgentSale> GetSalesByAgentId(int agentId);
        List<vw_Unit> GetSalesByProjectId(int projectId, int phaseId);
        List<YearSale> GetAllSales();
        List<App_TaskList> GetApp_TaskListsBySaleId(int saleId);
        List<App_ProspectFollowUp> GetProspectFollowUps(string prospectNo);
        List<vw_PS_PaymentHistory> GetPaymentHistoryByUnitId(int unitId);

        List<vw_UnitActiveAgg> GetAvailableUnitsCount(int projectId, int phaseId, int blockId);
        List<vw_Unit> GetAvailableUnits(int projectId, int phaseId, int blockId, string floorName, int unitTypeId);

        bool AddAppProspect(App_Prospect prospect);
        bool AddAppProspectFollowUp(App_ProspectFollowUp prospect);
        
        List<App_SaleAgent> GetSaleAgents();
        bool TransferProspect(App_ProspectTransfer prospectTransfer);

        bool UpdateAppTaskItem(App_TaskList taskList);
        bool IsDuplicateProspect(App_Prospect prospect);
        bool AddAppSale(App_Sale sale);

        bool CancelBooking(App_Sale saleRequest);
        bool ConvertToSale(App_Sale saleRequest);
        bool ConvertToBook(App_Sale saleRequest);

        List<Currency> GetCurrencies();
        List<App_UserToken> GetNotifications();
        
        List<vw_BankAccount> GetBankAccounts(int unitId, int currencyId);
        List<DashboardData> GetDashboardData(string teamOrAgent = "", int teamId = 0, int agentId = 0, int selectedProjectId = 0, bool showAll=false);
        List<PropertyData> GetPropertyData();
        List<TeamData> GetTeamData(string teamOrAgent = "");
        List<ProspectData> GetProspectData();
    }
}
