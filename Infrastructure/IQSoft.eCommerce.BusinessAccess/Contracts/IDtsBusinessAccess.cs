using IQSoft.eCommerce.Entities.Dts;
using System.Collections.Generic;

namespace IQSoft.eCommerce.BusinessAccess.Contracts
{
    public interface IDtsBusinessAccess
    {
        List<vw_User> GetAllUsers();
        List<vw_App_Dts> GetOpenDefectsByProjectId(int projectId, int phaseId);
        DtsConsolidated GetOpenDefectsByProjectIdWithItems(int projectId, int phaseId);
        List<vw_App_Dts> GetClosedDefectsByProjectId(int projectId, int phaseId);
        DtsConsolidated GetClosedDefectsByProjectIdWithItems(int projectId, int phaseId);
        List<App_DtsType> GetDtsTypes(int projectId);
        List<DefectStatus> GetDefectStatuses();
        Defect SaveDefect(App_Defect defect);
        void AddDocument(DefectItem item);
        List<DefectItemDocument> ViewDocuments(int defectItemId);
        void AddItem(DefectItem item);
        void AddItemFollowUp(DefectItem item);
        void AssignDefectItem(DefectItem item);
        void ReOpenDefectItem(DefectItem item);
        void RateAndCloseDefectItem(DefectItem item);
        void UpdateDefectStatus(DefectItem item);
        void UpdateDefectItemStatus(DefectItem item);
        Defect GetDefect(int defectHeaderID);
    }
}
