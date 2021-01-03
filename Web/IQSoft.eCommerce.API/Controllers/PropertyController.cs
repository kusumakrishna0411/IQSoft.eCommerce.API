using IQSoft.eCommerce.BusinessAccess.Contracts;
using IQSoft.eCommerce.Entities.Operations;
using IQSoft.eCommerce.Entities.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace IQSoft.eCommerce.API.Controllers
{
    [Route("[controller]")]
    [Authorize]
    public class PropertyController : IQSoftController
    {
        private IPropertyBusinessAccess propertyBusinessAccess = default(IPropertyBusinessAccess);

        public PropertyController(UserContext userContext, IPropertyBusinessAccess propertyBusinessAccess)
        {
            this.userContext = userContext;
            this.propertyBusinessAccess = propertyBusinessAccess;
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult GetAllProperties()
        {
            return Ok(propertyBusinessAccess.GetAllProperties());
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult GetAllPhases()
        {
            return Ok(propertyBusinessAccess.GetAllPhases());
        }

        [Route("[action]/{propertyId:int}")]
        [HttpGet]
        public IActionResult GetPropertyMetaDataById(int propertyId)
        {
            return Ok(propertyBusinessAccess.GetPropertyMetaDataById(propertyId));
        }

        [Route("[action]/{projectId:int}")]
        [HttpGet]
        public IActionResult GetPSProspectsByProjectId(int projectId)
        {
            return Ok(propertyBusinessAccess.GetPS_ProspectsByProjectId(projectId));
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult GetAllAccounts(string searchText, bool includeNew)
        {
            return Ok(propertyBusinessAccess.GetAllAccounts(searchText, includeNew));
        }

        [Route("[action]/{projectId:int}")]
        [HttpGet]
        public IActionResult GetAppSaleAgentByProjectId(int projectId)
        {
            return Ok(propertyBusinessAccess.GetApp_SaleAgentByProjectId(projectId));
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult GetPS_ProspectsByCreatedUserId(int projectId, int createdUserId)
        {
            if (createdUserId == default(int))
            {
                createdUserId = this.userContext.LoggedInUserId;
            }
            return Ok(propertyBusinessAccess.GetPS_ProspectsByCreatedUserId(projectId, createdUserId));
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult GetAppGenders()
        {
            return Ok(propertyBusinessAccess.GetAppGenders());
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult GetAppIdentities()
        {
            return Ok(propertyBusinessAccess.GetApp_Identities());
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult GetProspectFollowUps(string prospectNo)
        {
            return Ok(propertyBusinessAccess.GetProspectFollowUps(prospectNo));
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult GetUnitStatuses()
        {
            var unitStatuses = new List<UnitStatus>
            {
                new UnitStatus{ Title ="Avail" },
                new UnitStatus{ Title ="Reserved" },
                new UnitStatus{ Title ="Book" },
                new UnitStatus{ Title ="Sale" },
                new UnitStatus{ Title ="Sign" },
                new UnitStatus{ Title ="Reg" }
            };
            return Ok(unitStatuses);
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult GetAppNationalities()
        {
            return Ok(propertyBusinessAccess.GetApp_Nationalities());
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult AddAppProspect([FromBody]App_Prospect prospect)
        {
            prospect.SaleAgentID = this.userContext.SaleAgentId;
            prospect.CreateUserID = this.userContext.LoggedInUserId;
            prospect.CreateDate = DateTime.Now;

            prospect.ModifyUserID = this.userContext.LoggedInUserId;
            prospect.ModifyDate = DateTime.Now;

            return Ok(propertyBusinessAccess.AddAppProspect(prospect));
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult AddAppProspectFollowUp([FromBody]App_ProspectFollowUp prospect)
        {
            prospect.CreateUserID = this.userContext.LoggedInUserId;
            prospect.CreateDate = DateTime.Now;

            prospect.ModifyUserID = this.userContext.LoggedInUserId;
            prospect.ModifyDate = DateTime.Now;

            return Ok(propertyBusinessAccess.AddAppProspectFollowUp(prospect));
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult GetSaleAgents()
        {
            return Ok(propertyBusinessAccess.GetSaleAgents());
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult TransferProspect([FromBody]App_ProspectTransfer prospectTransfer)
        {
            return Ok(propertyBusinessAccess.TransferProspect(prospectTransfer));
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult UpdateAppTaskItem([FromBody]App_TaskList taskList)
        {
            taskList.CreateUserID = this.userContext.LoggedInUserId;
            taskList.CreateDate = DateTime.Now;

            taskList.ModifyUserID = this.userContext.LoggedInUserId;
            taskList.ModifyDate = DateTime.Now;

            return Ok(propertyBusinessAccess.UpdateAppTaskItem(taskList));
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult IsDuplicateProspect([FromBody]App_Prospect prospect)
        {
            prospect.CreateUserID = this.userContext.LoggedInUserId;
            prospect.CreateDate = DateTime.Now;

            prospect.ModifyUserID = this.userContext.LoggedInUserId;
            prospect.ModifyDate = DateTime.Now;

            return Ok(propertyBusinessAccess.IsDuplicateProspect(prospect));
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult AddAppSale([FromBody]App_Sale sale)
        {
            sale.SaleAgentID = this.userContext.SaleAgentId;
            sale.CreateUserID = this.userContext.LoggedInUserId;
            sale.CreateDate = DateTime.Now;

            sale.ModifyUserID = this.userContext.LoggedInUserId;
            sale.ModifyDate = DateTime.Now;

            return Ok(propertyBusinessAccess.AddAppSale(sale));
        }

        [Route("[action]/{agentId:int}")]
        [HttpGet]
        public IActionResult GetSalesByAgentId(int agentId)
        {
            return Ok(propertyBusinessAccess.GetSalesByAgentId(agentId));
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult GetSalesByProjectId(int projectId, int phaseId)
        {
            return Ok(propertyBusinessAccess.GetSalesByProjectId(projectId, phaseId));
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult GetAllSales()
        {
            return Ok(propertyBusinessAccess.GetAllSales());
        }

        [Route("[action]/{saleId:int}")]
        [HttpGet]
        public IActionResult GetApp_TaskListsBySaleId(int saleId)
        {
            return Ok(propertyBusinessAccess.GetApp_TaskListsBySaleId(saleId));
        }

        [Route("[action]/{unitId:int}")]
        [HttpGet]
        public IActionResult GetPaymentHistoryByUnitId(int unitId)
        {
            return Ok(propertyBusinessAccess.GetPaymentHistoryByUnitId(unitId));
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult GetAvailableUnitsCount([FromBody]UnitFilterRequest request)
        {
            return Ok(propertyBusinessAccess.GetAvailableUnitsCount(request.ProjectId, request.PhaseId, request.BlockId));
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult GetAvailableUnits([FromBody]UnitFilterRequest request)
        {
            return Ok(propertyBusinessAccess.GetAvailableUnits(request.ProjectId, request.PhaseId, request.BlockId, request.FloorName, request.UnitTypeId));
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult CancelBooking([FromBody]App_Sale saleRequest)
        {
            saleRequest.SaleAgentID = this.userContext.SaleAgentId;
            saleRequest.CreateUserID = this.userContext.LoggedInUserId;
            saleRequest.CreateDate = DateTime.Now;

            saleRequest.ModifyUserID = this.userContext.LoggedInUserId;
            saleRequest.ModifyDate = DateTime.Now;

            return Ok(propertyBusinessAccess.CancelBooking(saleRequest));
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult ConvertToBook([FromBody]App_Sale saleRequest)
        {
            saleRequest.SaleAgentID = this.userContext.SaleAgentId;
            saleRequest.CreateUserID = this.userContext.LoggedInUserId;
            saleRequest.CreateDate = DateTime.Now;

            saleRequest.ModifyUserID = this.userContext.LoggedInUserId;
            saleRequest.ModifyDate = DateTime.Now;

            return Ok(propertyBusinessAccess.ConvertToBook(saleRequest));
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult ConvertToSale([FromBody]App_Sale saleRequest)
        {
            saleRequest.SaleAgentID = this.userContext.SaleAgentId;
            saleRequest.CreateUserID = this.userContext.LoggedInUserId;
            saleRequest.CreateDate = DateTime.Now;

            saleRequest.ModifyUserID = this.userContext.LoggedInUserId;
            saleRequest.ModifyDate = DateTime.Now;

            return Ok(propertyBusinessAccess.ConvertToSale(saleRequest));
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult GetCurrencies()
        {
            return Ok(propertyBusinessAccess.GetCurrencies());
        }
        [Route("[action]")]
        [HttpGet]
        public IActionResult GetNotifications()
        {
            return Ok(propertyBusinessAccess.GetNotifications());
        }
        [Route("[action]")]
        [HttpGet]
        public IActionResult GetBankAccounts(int unitId, int currencyId)
        {
            return Ok(propertyBusinessAccess.GetBankAccounts(unitId, currencyId));
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult GetDashboardData(string teamOrAgent, int teamId, int agentId, int selectedProjectId, bool showAll)
        {
            return Ok(propertyBusinessAccess.GetDashboardData(teamOrAgent, teamId, agentId, selectedProjectId, showAll));
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult GetPropertyData()
        {
            return Ok(propertyBusinessAccess.GetPropertyData());
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult GetTeamData(string teamOrAgent)
        {
            return Ok(propertyBusinessAccess.GetTeamData(teamOrAgent));
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult GetProspectData()
        {
            return Ok(propertyBusinessAccess.GetProspectData());
        }
    }

    public class UnitFilterRequest
    {
        public int ProjectId { get; set; }
        public int PhaseId { get; set; }
        public int BlockId { get; set; }
        public string FloorName { get; set; }
        public int UnitTypeId { get; set; }
    }
}
