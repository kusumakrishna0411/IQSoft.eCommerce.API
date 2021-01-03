using IQSoft.eCommerce.BusinessAccess.Contracts;
using IQSoft.eCommerce.Entities.Operations;
using IQSoft.eCommerce.Entities.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace IQSoft.eCommerce.API.Controllers
{
    [Route("[controller]")]
    [Authorize]
    public class ActivityController : IQSoftController
    {
        private IActivityBusinessAccess activityBusinessAccess = default(IActivityBusinessAccess);

        public ActivityController(UserContext userContext, IActivityBusinessAccess activityBusinessAccess)
        {
            this.userContext = userContext;
            this.activityBusinessAccess = activityBusinessAccess;
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult GetTasksByUserId(int projectId, int userId = 0)
        {
            userId = (userId == 0) ? this.userContext.LoggedInUserId : userId;

            return Ok(activityBusinessAccess.GetTasksByUserId(projectId, userId));
        }
        [Route("[action]")]
        [HttpGet]
        public IActionResult GetTasksByUserIdwithDueDate(int projectId, int userId = 0, int dueId = 0)
        {
            userId = (userId == 0) ? this.userContext.LoggedInUserId : userId;

            return Ok(activityBusinessAccess.GetTasksByUserIdwithDueDate(projectId, userId, dueId));
        }

        [Route("[action]/{unitId:int}")]
        [HttpGet]
        public IActionResult GetTasksByUnitId(int unitId)
        {
            return Ok(activityBusinessAccess.GetTasksByUnitId(unitId));
        }

        [Route("[action]/{prospectId:int}")]
        [HttpGet]
        public IActionResult GetTasksByProspectId(int prospectId)
        {
            return Ok(activityBusinessAccess.GetTasksByProspectId(prospectId));
        }

        [Route("[action]/{activityId:int}")]
        [HttpGet]
        public IActionResult GetActivityById(int activityId)
        {
            return Ok(activityBusinessAccess.GetActivityById(activityId));
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult SaveActivity([FromBody]CF_Activity activity)
        {
            activity.CreateUserID = this.userContext.LoggedInUserId;
            activity.CreateDate = DateTime.Now;

            activity.ModifyUserID = this.userContext.LoggedInUserId;
            activity.ModifyDate = DateTime.Now;

            return Ok(activityBusinessAccess.SaveActivity(activity));
        }


    }
}
