using IQSoft.eCommerce.Entities.Operations;
using IQSoft.eCommerce.Entities.Security;
using IQSoft.eCommerce.ResourceAccess.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data;

namespace IQSoft.eCommerce.ResourceAccess.Implementation
{
    public class ActivityDataAccess : DataAccess, IActivityDataAccess
    {
        public ActivityDataAccess(UserContext userContext)
            : base(userContext)
        {

        }

        public List<VIEW_CF_Activity_Mobile> GetTasksByUserId(int projectId, int userId)
        {
            return this.clientDbContext.vw_Activities($"ProjectID = {projectId} AND (AssignedToID = {userId} OR CreateUserID = {userId})");
        }
        public List<VIEW_CF_Activity_Mobile> GetTasksByUserIdwithDueDate(int projectId, int userId, int dueId)
        {
            var todayDate = DateTime.Now.ToString("dd-MMM-yyyy");
            var dueDateCodition = (dueId == 1) ? $"DueDate <= '{todayDate}'" : $"DueDate > '{todayDate}'";
            return this.clientDbContext.vw_Activities($"ProjectID = {projectId} AND (AssignedToID = {userId} OR CreateUserID = {userId}) AND ({dueId} = 0 OR {dueDateCodition})");
        }

        public List<VIEW_CF_Activity_Mobile> GetTasksByUnitId(int unitId)
        {
            return this.clientDbContext.vw_Activities($"RefTable = 'PS_Unit' AND RefRecordID = {unitId} AND (a.AssignedToID = {this.userContext.LoggedInUserId} OR CreateUserID = {this.userContext.LoggedInUserId})");
        }

        public List<VIEW_CF_Activity_Mobile> GetTasksByProspectId(int prospectId)
        {
            return this.clientDbContext.vw_Activities($"RefTable = 'PS_Prospect' AND RefRecordID = {prospectId} AND (AssignedToID = {this.userContext.LoggedInUserId} OR CreateUserID = {this.userContext.LoggedInUserId})");
        }

        public CF_Activity GetActivityById(int activityId)
        {
            return this.clientDbContext.Activities($"ActivityID = {activityId}").FirstOrDefault();
        }

        public bool SaveActivity(CF_Activity activity)
        {
            if (activity.ActivityID == default(int))
            {
                activity.RecordStatus = "Active";
            }

            var parmsCollection = new ParmsCollection();
            var dataSet = this.clientDbContext.ExecuteQueryOrStoredProcedure_ToDataSet("[MobileApp].[saveActivity]",
                            parmsCollection
                            .AddParm("@ActivityID", SqlDbType.Int, activity.ActivityID)
                            .AddParm("@ActivityTypeID", SqlDbType.Int, activity.ActivityTypeID)
                            .AddParm("@Title", SqlDbType.NVarChar, activity.Title)
                            .AddParm("@Description", SqlDbType.NVarChar, activity.Description)

                            .AddParm("@AssignedToID", SqlDbType.Int, activity.AssignedToID)
                            .AddParm("@RefTable", SqlDbType.NVarChar, activity.RefTable)
                            .AddParm("@RefRecordID", SqlDbType.Int, activity.RefRecordID)

                            .AddParm("@PlannedDate", SqlDbType.DateTime, activity.PlannedDate)
                            .AddParm("@ActualDate", SqlDbType.DateTime, activity.ActualDate)
                            .AddParm("@CompletedDate", SqlDbType.DateTime, activity.CompletedDate)
                            .AddParm("@DueDate", SqlDbType.DateTime, activity.DueDate)
                            .AddParm("@PriorityID", SqlDbType.Int, activity.PriorityID)
                            .AddParm("@NextScheduleDate", SqlDbType.DateTime, activity.NextScheduleDate)

                            .AddParm("@Remark", SqlDbType.NVarChar, activity.Remark)
                            .AddParm("@RecordStatus", SqlDbType.NVarChar, activity.RecordStatus)

                            .AddParm("@CreateUserID", SqlDbType.Int, userContext.LoggedInUserId)
                            .AddParm("@ModifyUserID", SqlDbType.Int, userContext.LoggedInUserId)
                            );

            return true;
        }
    }
}
