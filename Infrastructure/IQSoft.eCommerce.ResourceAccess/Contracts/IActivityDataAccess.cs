using IQSoft.eCommerce.Entities.Operations;
using System;
using System.Collections.Generic;
using System.Text;

namespace IQSoft.eCommerce.ResourceAccess.Contracts
{
    public interface IActivityDataAccess
    {
        List<VIEW_CF_Activity_Mobile> GetTasksByUserId(int projectId, int userId);
        List<VIEW_CF_Activity_Mobile> GetTasksByUserIdwithDueDate(int projectId, int userId , int dueId);
        List<VIEW_CF_Activity_Mobile> GetTasksByUnitId(int unitId);
        List<VIEW_CF_Activity_Mobile> GetTasksByProspectId(int prospectId);
        CF_Activity GetActivityById(int activityId);
        bool SaveActivity(CF_Activity activity);
    }
}
