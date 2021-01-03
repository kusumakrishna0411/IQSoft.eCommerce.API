using IQSoft.eCommerce.BusinessAccess.Contracts;
using IQSoft.eCommerce.Entities.Dts;
using IQSoft.eCommerce.Entities.Security;
using IQSoft.eCommerce.ResourceAccess.Contracts;
using System.Collections.Generic;

namespace IQSoft.eCommerce.BusinessAccess.Implementation
{
    public class DtsBusinessAccess : IDtsBusinessAccess
    {
        private IDtsDataAccess dtsDataAccess;
        public DtsBusinessAccess(UserContext userContext, IDtsDataAccess dtsDataAccess)
        {
            this.dtsDataAccess = dtsDataAccess;
        }

        public List<vw_User> GetAllUsers()
        {
            return this.dtsDataAccess.GetAllUsers();
        }
        public List<vw_App_Dts> GetOpenDefectsByProjectId(int projectId, int phaseId)
        {
            return this.dtsDataAccess.GetOpenDefectsByProjectId(projectId, phaseId);
        }
        public DtsConsolidated GetOpenDefectsByProjectIdWithItems(int projectId, int phaseId)
        {
            return this.dtsDataAccess.GetOpenDefectsByProjectIdWithItems(projectId, phaseId);
        }
        public List<vw_App_Dts> GetClosedDefectsByProjectId(int projectId, int phaseId)
        {
            return this.dtsDataAccess.GetClosedDefectsByProjectId(projectId, phaseId);
        }
        public DtsConsolidated GetClosedDefectsByProjectIdWithItems(int projectId, int phaseId)
        {
            return this.dtsDataAccess.GetClosedDefectsByProjectIdWithItems(projectId, phaseId);
        }
        public List<App_DtsType> GetDtsTypes(int projectId)
        {
            return this.dtsDataAccess.GetDtsTypes(projectId);
        }
        public List<DefectStatus> GetDefectStatuses()
        {
            return this.dtsDataAccess.GetDefectStatuses();
        }
        public Defect SaveDefect(App_Defect defect)
        {
            return this.dtsDataAccess.SaveDefect(defect);
        }
        public void AddDocument(DefectItem item)
        {
            this.dtsDataAccess.AddDocument(item);
        }
        public List<DefectItemDocument> ViewDocuments(int defectItemId)
        {
            return this.dtsDataAccess.ViewDocuments(defectItemId);
        }
        public void AddItem(DefectItem item)
        {
            this.dtsDataAccess.AddItem(item);
        }
        public void AddItemFollowUp(DefectItem item)
        {
            this.dtsDataAccess.AddItemFollowUp(item);
        }
        public void AssignDefectItem(DefectItem item)
        {
            this.dtsDataAccess.AssignDefectItem(item);
        }
        public void ReOpenDefectItem(DefectItem item)
        {
            this.dtsDataAccess.ReOpenDefectItem(item);
        }
        public void RateAndCloseDefectItem(DefectItem item)
        {
            this.dtsDataAccess.RateAndCloseDefectItem(item);
        }
        public void UpdateDefectStatus(DefectItem item)
        {
            this.dtsDataAccess.UpdateDefectStatus(item);
        }
        public void UpdateDefectItemStatus(DefectItem item)
        {
            this.dtsDataAccess.UpdateDefectItemStatus(item);
        }
        public Defect GetDefect(int defectHeaderID)
        {
            return this.dtsDataAccess.GetDefect(defectHeaderID);
        }
    }
}
