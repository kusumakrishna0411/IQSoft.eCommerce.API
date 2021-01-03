using IQSoft.eCommerce.BusinessAccess.Contracts;
using IQSoft.eCommerce.Entities.Operations;
using IQSoft.eCommerce.Entities.Security;
using IQSoft.eCommerce.ResourceAccess.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace IQSoft.eCommerce.BusinessAccess.Implementation
{
    public class ActivityBusinessAccess : IActivityBusinessAccess
    {
        private IActivityDataAccess activityDataAccess;
        public ActivityBusinessAccess(UserContext userContext, IActivityDataAccess activityDataAccess)
        {
            this.activityDataAccess = activityDataAccess;
        }

        public List<VIEW_CF_Activity_Mobile> GetTasksByUserId(int projectId, int userId)
        {
            return this.activityDataAccess.GetTasksByUserId(projectId, userId);
        }
        public List<VIEW_CF_Activity_Mobile> GetTasksByUserIdwithDueDate(int projectId, int userId , int dueId)
        {
            return this.activityDataAccess.GetTasksByUserIdwithDueDate(projectId, userId,dueId);
        }

        public List<VIEW_CF_Activity_Mobile> GetTasksByUnitId(int unitId)
        {
            return this.activityDataAccess.GetTasksByUnitId(unitId);
        }
        public List<VIEW_CF_Activity_Mobile> GetTasksByProspectId(int prospectId)
        {
            return this.activityDataAccess.GetTasksByProspectId(prospectId);
        }

        public CF_Activity GetActivityById(int activityId)
        {
            return this.activityDataAccess.GetActivityById(activityId);
        }

        public bool SaveActivity(CF_Activity activity)
        {
            return this.activityDataAccess.SaveActivity(activity);
        }
    }
}
