using IQSoft.eCommerce.BusinessAccess.Contracts;
using IQSoft.eCommerce.Entities.Dts;
using IQSoft.eCommerce.Entities.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IQSoft.eCommerce.API.Controllers
{
    [Route("[controller]")]
    [Authorize]
    public class DtsController : IQSoftController
    {
        private IDtsBusinessAccess dtsBusinessAccess = default(IDtsBusinessAccess);

        public DtsController(UserContext userContext, IDtsBusinessAccess dtsBusinessAccess)
        {
            this.userContext = userContext;
            this.dtsBusinessAccess = dtsBusinessAccess;
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            return Ok(dtsBusinessAccess.GetAllUsers());
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult GetOpenDefectsByProjectId(int projectId, int phaseId)
        {
            return Ok(dtsBusinessAccess.GetOpenDefectsByProjectId(projectId, phaseId));
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult GetOpenDefectsByProjectIdWithItems(int projectId, int phaseId)
        {
            return Ok(dtsBusinessAccess.GetOpenDefectsByProjectIdWithItems(projectId, phaseId));
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult GetClosedDefectsByProjectId(int projectId, int phaseId)
        {
            return Ok(dtsBusinessAccess.GetClosedDefectsByProjectId(projectId, phaseId));
        }
        [Route("[action]")]
        [HttpGet]
        public IActionResult GetClosedDefectsByProjectIdWithItems(int projectId, int phaseId)
        {
            return Ok(dtsBusinessAccess.GetClosedDefectsByProjectIdWithItems(projectId, phaseId));
        }

        [Route("[action]/{projectId:int}")]
        [HttpGet]
        public IActionResult GetDtsTypes(int projectId = 0)
        {
            return Ok(dtsBusinessAccess.GetDtsTypes(projectId));
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult GetDefectStatuses()
        {
            return Ok(dtsBusinessAccess.GetDefectStatuses());
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult SaveDefect([FromBody] App_Defect defect)
        {
            defect.ReportedBy = this.userContext.LoggedInUserId;

            return Ok(dtsBusinessAccess.SaveDefect(defect));
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult AddDocument([FromBody] DefectItem item)
        {
            dtsBusinessAccess.AddDocument(item);
            return Ok(true);
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult AddItem([FromBody] DefectItem item)
        {
            item.CreatedBy = this.userContext.LoggedInUserId;

            dtsBusinessAccess.AddItem(item);
            return Ok(true);
        }

        [Route("[action]/{defectItemId:int}")]
        [HttpGet]
        public IActionResult ViewDocuments(int defectItemId)
        {
            return Ok(dtsBusinessAccess.ViewDocuments(defectItemId));
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult AddItemFollowUp([FromBody] DefectItem item)
        {
            item.CreatedBy = this.userContext.LoggedInUserId;

            dtsBusinessAccess.AddItemFollowUp(item);
            return Ok(true);
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult AssignDefectItem([FromBody] DefectItem item)
        {
            item.CreatedBy = this.userContext.LoggedInUserId;

            dtsBusinessAccess.AssignDefectItem(item);
            return Ok(true);
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult ReOpenDefectItem([FromBody] DefectItem item)
        {
            item.CreatedBy = this.userContext.LoggedInUserId;

            dtsBusinessAccess.ReOpenDefectItem(item);
            return Ok(true);
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult RateAndCloseDefectItem([FromBody] DefectItem item)
        {
            item.CreatedBy = this.userContext.LoggedInUserId;

            dtsBusinessAccess.RateAndCloseDefectItem(item);
            return Ok(true);
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult UpdateDefectStatus([FromBody] DefectItem item)
        {
            item.CreatedBy = this.userContext.LoggedInUserId;

            dtsBusinessAccess.UpdateDefectStatus(item);
            return Ok(true);
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult UpdateDefectItemStatus([FromBody] DefectItem item)
        {
            item.CreatedBy = this.userContext.LoggedInUserId;

            dtsBusinessAccess.UpdateDefectItemStatus(item);
            return Ok(true);
        }

        [Route("[action]/{defectHeaderID:int}")]
        [HttpGet]
        public IActionResult GetDefect(int defectHeaderID)
        {
            return Ok(dtsBusinessAccess.GetDefect(defectHeaderID));
        }

    }
}
