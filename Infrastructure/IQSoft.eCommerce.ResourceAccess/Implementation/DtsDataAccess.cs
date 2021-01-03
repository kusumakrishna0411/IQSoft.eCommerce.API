using IQSoft.eCommerce.Entities.Core;
using IQSoft.eCommerce.Entities.Dts;
using IQSoft.eCommerce.Entities.Security;
using IQSoft.eCommerce.ResourceAccess.Contracts;
using IQSoft.eCommerce.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace IQSoft.eCommerce.ResourceAccess.Implementation
{
    public class DtsDataAccess : DataAccess, IDtsDataAccess
    {
        public DtsDataAccess(UserContext userContext)
            : base(userContext)
        {

        }

        public List<vw_User> GetAllUsers()
        {
            return this.clientDbContext.vw_Users();
        }

        public List<vw_App_Dts> GetOpenDefectsByProjectId(int projectId, int phaseId)
        {
            var query = "";
            if (phaseId == 0)
                query = $"select * from MobileApp.vw_App_Dts where ProjectID = {projectId} and RecordStatus IN ( 'Active', 'WIP')";
            else
                query = $"select * from MobileApp.vw_App_Dts where ProjectID = {projectId} and PhaseID = {phaseId} and RecordStatus IN ( 'Active', 'WIP')";

            return this.clientDbContext.ExecuteQuery_ToList<vw_App_Dts>(query);
        }

        public DtsConsolidated GetOpenDefectsByProjectIdWithItems(int projectId, int phaseId)
        {
            var query = "";
            if (phaseId == 0)
                query = $"select * from MobileApp.vw_App_Dts where ProjectID = {projectId} and RecordStatus IN ( 'Active', 'WIP')";
            else
                query = $"select * from MobileApp.vw_App_Dts where ProjectID = {projectId} and PhaseID = {phaseId} and RecordStatus IN ( 'Active', 'WIP')";

            var dataTable = this.clientDbContext.ExecuteQuery_ToDataTable(query);

            var result = new DtsConsolidated();
            result.Headers = dataTable.ToList<vw_App_Dts>();

            if (result.Headers == null)
            {
                result.Headers = new List<vw_App_Dts>();
                result.Items = new List<PS_DefectItem>();
            }
            else
            {
                var headerIds = result.Headers.Select(h => h.DefectHeaderID).ToArray().ToCommaSeperated();
                var condition = $"DefectHeaderID in ({headerIds})";
                result.Items = this.clientDbContext.PS_DefectItems(condition);
            }
            return result;
        }


        public List<vw_App_Dts> GetClosedDefectsByProjectId(int projectId, int phaseId)
        {
            var query = "";
            if (phaseId == 0)
                query = $"select * from MobileApp.vw_App_Dts where ProjectID = {projectId} and RecordStatus NOT IN ( 'Active', 'WIP')";
            else
                query = $"select * from MobileApp.vw_App_Dts where ProjectID = {projectId} and PhaseID = {phaseId} and RecordStatus NOT IN ( 'Active', 'WIP')";

            return this.clientDbContext.ExecuteQuery_ToList<vw_App_Dts>(query);
        }

        public DtsConsolidated GetClosedDefectsByProjectIdWithItems(int projectId, int phaseId)
        {
            var query = "";
            if (phaseId == 0)
                query = $"select * from MobileApp.vw_App_Dts where ProjectID = {projectId} and RecordStatus NOT IN ( 'Active', 'WIP')'";
            else
                query = $"select * from MobileApp.vw_App_Dts where ProjectID = {projectId} and PhaseID = {phaseId} and RecordStatus NOT IN ( 'Active', 'WIP')'";

            var dataTable = this.clientDbContext.ExecuteQuery_ToDataTable(query);

            var result = new DtsConsolidated();
            result.Headers = dataTable.ToList<vw_App_Dts>();

            if (result.Headers == null)
            {
                result.Headers = new List<vw_App_Dts>();
                result.Items = new List<PS_DefectItem>();
            }
            else
            {
                var headerIds = result.Headers.Select(h => h.DefectHeaderID).ToArray().ToCommaSeperated();                
                var condition = $"DefectHeaderID in ({headerIds})";
                result.Items = this.clientDbContext.PS_DefectItems(condition);
            }
            return result;
        }

        public List<App_DtsType> GetDtsTypes(int projectId)
        {
            var dtsTypes = this.clientDbContext.App_DtsTypes("", "StringEN").Distinct().ToList();

            var contractors = dtsTypes.Where(dt => dt.PopupLstID == 0 && dt.ParentPopupLstElementID == projectId).Distinct().ToList();

            var result = new List<App_DtsType>();
            result.AddRange(dtsTypes.Where(dt => dt.PopupLstID != 0));

            if (contractors.Count > 0)
            {
                result.AddRange(contractors);
            }
            return result;
        }
        public List<DefectStatus> GetDefectStatuses()
        {
            return new List<DefectStatus>
            {
                new DefectStatus{  Title="Active" },
                new DefectStatus{  Title="WIP" },
                new DefectStatus{  Title="Completed" },
                new DefectStatus{  Title="Close" },
                new DefectStatus{  Title="Inactive" }
            };
        }

        public Defect SaveDefect(App_Defect defect)
        {
            var result = new Defect();
            var parmsCollection = new ParmsCollection();
            result.Header = this.clientDbContext.ExecuteStoredProcedure_ToList<PS_DefectHeader>("[MobileApp].[addApp_Dts]",
                            parmsCollection
                            .AddParm("@UnitId", SqlDbType.Int, defect.UnitId)
                            .AddParm("@ReportDate", SqlDbType.DateTime, (defect.ReportDate == default(DateTime)) ? DateTime.Now : defect.ReportDate)
                            .AddParm("@TargetDate", SqlDbType.DateTime, ((defect.ReportDate == default(DateTime)) ? DateTime.Now : defect.ReportDate).AddDays(5))
                            .AddParm("@ReportedBy", SqlDbType.Int, defect.ReportedBy)

                            .AddParm("@Summary", SqlDbType.NVarChar, defect.Summary)
                            .AddParm("@Description", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(defect.Description) ? defect.Summary : defect.Description)

                            .AddParm("@DefectTypeID", SqlDbType.Int, defect.DefectTypeID)
                            .AddParm("@Type", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(defect.Type) ? "Common Defects" : defect.Type)

                            .AddParm("@LocationID", SqlDbType.Int, defect.LocationID)
                            .AddParm("@Contractor1ID", SqlDbType.Int, defect.Contractor1ID)
                            ).FirstOrDefault();

            return result;
        }

        public void AddItemFollowUp(DefectItem item)
        {
            var parmsCollection = new ParmsCollection();
            this.clientDbContext.ExecuteStoredProcedure_ToList<PS_DefectHeader>("[MobileApp].[dts_AddItemFollowUp]",
                           parmsCollection
                           .AddParm("@DefectItemID", SqlDbType.Int, item.DefectItemID)
                           .AddParm("@IsCompleted", SqlDbType.Bit, item.IsCompleted)
                           .AddParm("@Remark", SqlDbType.NVarChar, item.Remark)
                           .AddParm("@CreatedBy", SqlDbType.Int, item.CreatedBy)
                           ).FirstOrDefault();
        }

        public void AddItem(DefectItem item)
        {
            var parmsCollection = new ParmsCollection();
            this.clientDbContext.ExecuteStoredProcedure_ToList<PS_DefectHeader>("[MobileApp].[dts_AddItem]",
                           parmsCollection
                           .AddParm("@DefectHeaderID", SqlDbType.Int, item.DefectHeaderID)
                           .AddParm("@DefectItemID", SqlDbType.Int, item.DefectItemID)
                           .AddParm("@DefectTypeID", SqlDbType.Int, item.DefectTypeID)
                           .AddParm("@Remark", SqlDbType.NVarChar, item.Remark)
                           .AddParm("@CreatedBy", SqlDbType.Int, item.CreatedBy)
                           .AddParm("@Contractor1ID", SqlDbType.Int, item.Contractor1ID)
                           .AddParm("@LocationID", SqlDbType.Int, item.LocationID)
                           ).FirstOrDefault();
        }

        public List<DefectItemDocument> ViewDocuments(int defectItemId)
        {
            var query = $"select 'https://images.IQSoft.com.vn/' + DocumentName as DocumentName, RefRecordID, Keyword, Description from CF_Document where RefTable = 'PS_DefectItem' and RefRecordID = {defectItemId}";
            return this.clientDbContext.ExecuteQuery_ToList<DefectItemDocument>(query);
        }
        public void AddDocument(DefectItem item)
        {
            item.DocumentName = $"{Guid.NewGuid()}.jpeg";

            if (!string.IsNullOrWhiteSpace(item.ImageData))
            {
                var filePath = Path.Combine(ConfigSettings.Instance.FileSettings.DocumentsFolder, item.DocumentName);
                byte[] imageBytes = Convert.FromBase64String(item.ImageData);
                File.WriteAllBytes(filePath, imageBytes);

                var parmsCollection = new ParmsCollection();
                this.clientDbContext.ExecuteStoredProcedure_ToList<PS_DefectHeader>("[MobileApp].[dts_AddDocument]",
                               parmsCollection
                               .AddParm("@RefRecordID", SqlDbType.Int, item.DefectItemID)
                               .AddParm("@DocumentName", SqlDbType.VarChar, item.DocumentName)
                               .AddParm("@Keyword", SqlDbType.VarChar, item.Keyword)
                               .AddParm("@Remark", SqlDbType.NVarChar, item.Remark)
                               .AddParm("@CreatedBy", SqlDbType.Int, this.userContext.LoggedInUserId)
                               ).FirstOrDefault();
            }
        }

        public void UpdateDefectStatus(DefectItem item)
        {
            var parmsCollection = new ParmsCollection();
            this.clientDbContext.ExecuteStoredProcedure_ToList<PS_DefectHeader>("[MobileApp].[dts_UpdateDefectStatus]",
                           parmsCollection
                           .AddParm("@DefectHeaderID", SqlDbType.Int, item.DefectHeaderID)
                           .AddParm("@Status", SqlDbType.VarChar, item.Status)
                           .AddParm("@CreatedBy", SqlDbType.Int, item.CreatedBy)
                           ).FirstOrDefault();
        }

        public void AssignDefectItem(DefectItem item)
        {
            var parmsCollection = new ParmsCollection();
            this.clientDbContext.ExecuteStoredProcedure_ToList<PS_DefectHeader>("[MobileApp].[dts_AssignDefectItem]",
                           parmsCollection
                           .AddParm("@DefectItemID", SqlDbType.Int, item.DefectItemID)
                           .AddParm("@Contractor1ID", SqlDbType.Int, item.Contractor1ID)
                           .AddParm("@Contractor2ID", SqlDbType.Int, item.Contractor2ID)
                           .AddParm("@Remark", SqlDbType.NVarChar, item.Remark)
                           .AddParm("@InternalUserID", SqlDbType.Int, item.InternalUserID)
                           .AddParm("@AssignDate", SqlDbType.DateTime, (item.AssignDate ?? DateTime.Now).Date)
                           .AddParm("@CreatedBy", SqlDbType.Int, item.CreatedBy)
                           ).FirstOrDefault();
        }

        public void ReOpenDefectItem(DefectItem item)
        {
            var parmsCollection = new ParmsCollection();
            this.clientDbContext.ExecuteStoredProcedure_ToList<PS_DefectHeader>("[MobileApp].[dts_ReOpenDefectItem]",
                           parmsCollection
                           .AddParm("@DefectItemID", SqlDbType.Int, item.DefectItemID)
                           .AddParm("@Remark", SqlDbType.NVarChar, item.Remark)
                           .AddParm("@CreatedBy", SqlDbType.Int, item.CreatedBy)
                           ).FirstOrDefault();
        }

        public void RateAndCloseDefectItem(DefectItem item)
        {
            var parmsCollection = new ParmsCollection();
            this.clientDbContext.ExecuteStoredProcedure_ToList<PS_DefectHeader>("[MobileApp].[dts_RateAndCloseDefectItem]",
                           parmsCollection
                           .AddParm("@DefectItemID", SqlDbType.Int, item.DefectItemID)
                           .AddParm("@FeedbackRateId", SqlDbType.Int, item.FeedbackRateId)
                           .AddParm("@Remark", SqlDbType.NVarChar, item.Remark)
                           .AddParm("@CreatedBy", SqlDbType.Int, item.CreatedBy)
                           ).FirstOrDefault();
        }

        public void UpdateDefectItemStatus(DefectItem item)
        {
            var parmsCollection = new ParmsCollection();
            this.clientDbContext.ExecuteStoredProcedure_ToList<PS_DefectHeader>("[MobileApp].[dts_UpdateDefectItemStatus]",
                           parmsCollection
                           .AddParm("@DefectItemID", SqlDbType.Int, item.DefectItemID)
                           .AddParm("@Status,", SqlDbType.VarChar, item.Status)
                           .AddParm("@CreatedBy", SqlDbType.Int, item.CreatedBy)
                           ).FirstOrDefault();
        }

        public Defect GetDefect(int defectHeaderID)
        {
            var result = new Defect();


            var query = $"select * from MobileApp.vw_App_Dts where DefectHeaderID = {defectHeaderID} ";
            var defectData = this.clientDbContext.ExecuteQuery_ToList<vw_App_Dts> (query);

            result.Header = this.clientDbContext.PS_DefectHeaders($"DefectHeaderID = {defectHeaderID}").FirstOrDefault();
            result.Items = this.clientDbContext.PS_DefectItems($"DefectHeaderID = {defectHeaderID}");
            result.Documents = this.clientDbContext.CF_Documents($"RefTable = 'PS_DefectHeader' AND RefRecordID = {defectHeaderID}");

            var dtsTypes = this.GetDtsTypes(defectData.Count > 0 ? defectData[0].ProjectID : 0);

            foreach (var item in result.Items)
            {
                item.DefectType = dtsTypes.Any(dt => dt.PopupLstElementID == item.DefectTypeID) ? dtsTypes.First(dt => dt.PopupLstElementID == item.DefectTypeID).StringEN : "n/a";
            }

            var itemIds = result.Items.Select(dh => dh.DefectItemID).ToArray().ToCommaSeperated();
            if (itemIds.Length > 0)
            {
                result.FollowUps = this.clientDbContext.PS_DefectItemFollowUps($"DefectItemID in ({itemIds})");
            }
            else
            {
                result.FollowUps = new List<PS_DefectItemFollowUp>();
            }


            return result;
        }

    }
}
