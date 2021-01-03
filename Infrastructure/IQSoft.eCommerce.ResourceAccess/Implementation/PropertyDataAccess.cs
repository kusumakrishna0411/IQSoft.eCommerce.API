using IQSoft.eCommerce.Entities.Core;
using IQSoft.eCommerce.Entities.Operations;
using IQSoft.eCommerce.Entities.Security;
using IQSoft.eCommerce.ResourceAccess.Contracts;
using IQSoft.eCommerce.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IQSoft.eCommerce.ResourceAccess.Implementation
{
    public class PropertyDataAccess : DataAccess, IPropertyDataAccess
    {
        public PropertyDataAccess(UserContext userContext)
            : base(userContext)
        {

        }
        public List<vw_Property> GetAllProperties()
        {
            return this.clientDbContext.Properties();
        }

        public List<vw_Phase> GetAllPhases()
        {
            return this.clientDbContext.Phases();
        }

        public PropertyMetaData GetPropertyMetaDataById(int propertyId)
        {
            var result = new PropertyMetaData();

            var parmsCollection = new ParmsCollection();
            var dataSet = this.clientDbContext.ExecuteQueryOrStoredProcedure_ToDataSet("[MobileApp].[getPropertyDetails]",
                            parmsCollection
                            .AddParm("@projectId", SqlDbType.Int, propertyId)
                            );

            result.Property = dataSet.Tables[0].ToList<vw_Property>().FirstOrDefault();
            result.Phases = dataSet.Tables[1].ToList<vw_Phase>();
            result.Blocks = dataSet.Tables[2].ToList<vw_Block>();
            result.Units = dataSet.Tables[3].ToList<vw_Unit>();

            return result;
        }
        public List<vw_PS_Prospect> GetPS_ProspectsByProjectId(int projectId)
        {
            return this.clientDbContext.vw_PS_Prospects($"ProjectID = {projectId}");
        }
        public List<vw_PS_Prospect> GetAllAccounts(string searchText, bool includeNew)
        {
            var result = new List<vw_PS_Prospect>();
            //if (includeNew)
            //{
            //    result.Add(new vw_PS_Prospect
            //    {
            //        AccountID = 0,
            //        Name = "--New--",
            //        IdentityNo = "Create new account"
            //    });
            //}
            //var query = $"select top 100 * from [MobileApp].[vw_PS_Prospect_Account]";

            //if (!string.IsNullOrWhiteSpace(searchText))
            //{
            //    query = query + $" where Name like N'%{searchText.Trim()}%' OR AccountNo like '%{searchText.Trim()}%' OR IdentityNo like '%{searchText.Trim()}%' OR MobilePhone like '%{searchText.Trim()}%'  OR Email like '%{searchText.Trim()}%'";
            //}

            //query = query + " ORDER BY Name";

            //var dataTable = this.clientDbContext.ExecuteQuery(query);

            //return dataTable.ToList<vw_PS_Prospect>();


            var query = $"select * from [MobileApp].[vw_PS_Prospect_Account]";
            var prospects = this.clientDbContext.ExecuteQuery_ToList<vw_PS_Prospect>(query);

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                searchText = NormalizeString(searchText.Trim());

                var rawResult = prospects.Where(p =>
                    NormalizeString(p.Name).Contains(searchText, StringComparison.OrdinalIgnoreCase)
                    || NormalizeString(p.AccountNo).Contains(searchText, StringComparison.OrdinalIgnoreCase)
                    || NormalizeString(p.IdentityNo).Contains(searchText, StringComparison.OrdinalIgnoreCase)
                    || NormalizeString(p.MobilePhone).Contains(searchText, StringComparison.OrdinalIgnoreCase)
                    || NormalizeString(p.Email).Contains(searchText, StringComparison.OrdinalIgnoreCase)
                ).OrderBy(p => p.Name).Take(100).ToList();

                if (rawResult.Count > 0)
                {
                    result.AddRange(rawResult);
                }
            }
            else
            {
                var rawResult = prospects.OrderBy(p => p.Name).Take(100).ToList();

                if (rawResult.Count > 0)
                {
                    result.AddRange(rawResult);
                }
            }

            return result;

        }

        private string NormalizeString(string inputWord)
        {
            if (string.IsNullOrWhiteSpace(inputWord)) return "";

            StringBuilder stringBuilder = new StringBuilder();
            foreach (char c in inputWord.Trim().ToCharArray())
            {
                string normalizedChar = c.ToString()
                    .Normalize(NormalizationForm.FormD).Substring(0, 1);

                stringBuilder.Append(normalizedChar);
            }

            return stringBuilder.ToString().ToLower();
        }

        public List<vw_PS_Prospect> GetPS_ProspectsByCreatedUserId(int projectId, int createdUserId)
        {
            var saleAgent = this.clientDbContext.App_SaleAgents($"UserID = {createdUserId}").FirstOrDefault();

            if (saleAgent != null)
            {
                var saleAgentId = saleAgent.SaleAgentID;

                return this.clientDbContext.vw_PS_Prospects($"ProjectID = {projectId} AND (CreateUserID = {createdUserId} OR SaleAgentID = {saleAgentId})");
            }
            else
            {
                return this.clientDbContext.vw_PS_Prospects($"ProjectID = {projectId} AND (CreateUserID = {createdUserId})");                
            }
        }
        public List<vw_Unit> GetApp_SaleAgentByProjectId(int projectId)
        {
            return this.clientDbContext.Units($"ProjectID = {projectId} AND RecordStatus <> 'Avail'");
        }

        public List<AgentSale> GetSalesByAgentId(int agentId)
        {
            return this.clientDbContext.AgentSales($"SoldBy = {agentId}");
        }

        public List<vw_Unit> GetSalesByProjectId(int projectId, int phaseId)
        {
            var rawResult = this.clientDbContext.Units($"ProjectID = {projectId} AND RecordStatus <> 'Avail' AND IsSupplement <> 'Y'");
            if (phaseId > 0)
            {
                rawResult = rawResult.Where(r => r.PhaseID == phaseId).ToList();
            }
            return rawResult;
        }

        public List<YearSale> GetAllSales()
        {
            var result = new List<YearSale>();
            var properties = this.GetAllProperties().OrderBy(p => p.ProjectName);

            var query = $"select * from [MobileApp].[vw_PS_AgentSale_Source] where SaleDate >= '{DateTime.Now.Date.AddYears(-1).ToString("dd-MMM-yyyy")}'";
            var fromDate = DateTime.Now.Date.AddYears(-1);
            var sales = this.clientDbContext.ExecuteQuery_ToList<AgentSale>(query);

            foreach (var item in properties)
            {
                var projectItem = new YearSale
                {
                    Property = item
                };

                var projectSales = sales.Where(s => s.ProjectID == item.ProjectID).Select(s => s.SaleDate).Distinct().ToList().OrderBy(s => s).ToList();
                foreach (var saleDate in projectSales)
                {
                    projectItem.DaySales.Add(new DaySale { SaleDate = (saleDate ?? DateTime.Now.Date), Count = sales.Where(s => s.ProjectID == item.ProjectID && s.SaleDate == saleDate).Count(), Amount = sales.Where(s => s.ProjectID == item.ProjectID && s.SaleDate == saleDate).Sum(s => s.TotalPriceInMillion) });
                }

                foreach (var saleDate in projectSales.Where(ps => ps >= DateTime.Now.Date.AddMonths(-1)))
                {
                    projectItem.M1Sales.Add(new DaySale { SaleDate = (saleDate ?? DateTime.Now.Date), Count = sales.Where(s => s.ProjectID == item.ProjectID && s.SaleDate == saleDate).Count(), Amount = sales.Where(s => s.ProjectID == item.ProjectID && s.SaleDate == saleDate).Sum(s => s.TotalPriceInMillion) });
                }

                foreach (var saleDate in projectSales.Where(ps => ps >= DateTime.Now.Date.AddMonths(-3)))
                {
                    projectItem.M3Sales.Add(new DaySale { SaleDate = (saleDate ?? DateTime.Now.Date), Count = sales.Where(s => s.ProjectID == item.ProjectID && s.SaleDate == saleDate).Count(), Amount = sales.Where(s => s.ProjectID == item.ProjectID && s.SaleDate == saleDate).Sum(s => s.TotalPriceInMillion) });
                }

                foreach (var saleDate in projectSales.Where(ps => ps >= DateTime.Now.Date.AddMonths(-6)))
                {
                    projectItem.M6Sales.Add(new DaySale { SaleDate = (saleDate ?? DateTime.Now.Date), Count = sales.Where(s => s.ProjectID == item.ProjectID && s.SaleDate == saleDate).Count(), Amount = sales.Where(s => s.ProjectID == item.ProjectID && s.SaleDate == saleDate).Sum(s => s.TotalPriceInMillion) });
                }

                foreach (var saleDate in projectSales.Where(ps => ps >= DateTime.Now.Date.AddMonths(-9)))
                {
                    projectItem.M9Sales.Add(new DaySale { SaleDate = (saleDate ?? DateTime.Now.Date), Count = sales.Where(s => s.ProjectID == item.ProjectID && s.SaleDate == saleDate).Count(), Amount = sales.Where(s => s.ProjectID == item.ProjectID && s.SaleDate == saleDate).Sum(s => s.TotalPriceInMillion) });
                }

                result.Add(projectItem);
            }


            return result;
        }

        public List<App_TaskList> GetApp_TaskListsBySaleId(int saleId)
        {
            var taskList = this.clientDbContext.App_TaskLists($"SaleId = {saleId}");
            foreach (var item in taskList)
            {
                item.DaysDelayed = ((item.CompletedDate ?? DateTime.Now.Date) - item.DueDate).Days;
            }
            //if (taskList.Count == 0)
            //{
            //    var parmsCollection = new ParmsCollection();
            //    var dataSet = this.clientDbContext.ExecuteDataSet("[MobileApp].[addSalesTasks]",
            //                parmsCollection
            //                .AddParm("@SaleId", SqlDbType.Int, saleId)
            //                );

            //    taskList = this.clientDbContext.App_TaskLists.Where(p => p.SaleId >= saleId).ToList();
            //}
            return taskList;
        }

        public bool UpdateAppTaskItem(App_TaskList taskList)
        {
            var parmsCollection = new ParmsCollection();
            var dataSet = this.clientDbContext.ExecuteQueryOrStoredProcedure_ToDataSet("[MobileApp].[updateApp_TaskItem]",
                            parmsCollection
                            .AddParm("@RowID", SqlDbType.Int, taskList.RowID)
                            .AddParm("@SaleId", SqlDbType.Int, taskList.SaleId)
                            .AddParm("@DueDate", SqlDbType.DateTime, taskList.DueDate)
                            .AddParm("@CompletedDate", SqlDbType.DateTime, taskList.CompletedDate)
                            .AddParm("@DaysDelayed", SqlDbType.Int, (!taskList.CompletedDate.HasValue || taskList.CompletedDate <= taskList.DueDate) ? 0 : (taskList.CompletedDate.Value - taskList.DueDate).Days)
                            .AddParm("@TaskName", SqlDbType.NVarChar, taskList.TaskName)
                            .AddParm("@Remarks", SqlDbType.NVarChar, taskList.Remarks)
                            .AddParm("@CreateUserID", SqlDbType.Int, userContext.LoggedInUserId)
                            .AddParm("@CreateDate", SqlDbType.DateTime, DateTime.Now)
                            .AddParm("@ModifyUserID", SqlDbType.Int, userContext.LoggedInUserId)
                            .AddParm("@ModifyDate", SqlDbType.DateTime, DateTime.Now)
                            );

            return true;
        }

        public bool IsDuplicateProspect(App_Prospect prospect)
        {
            prospect.Name = string.IsNullOrWhiteSpace(prospect.Name) ? "" : prospect.Name.Trim();
            prospect.IdentityNo = string.IsNullOrWhiteSpace(prospect.IdentityNo) ? "" : prospect.IdentityNo.Trim();

            var prospectDb = default(vw_PS_Prospect);

            if (prospect.RowID == default(int))
                prospectDb = this.clientDbContext.vw_PS_Prospects($"Name = '{prospect.Name}'").FirstOrDefault();
            else
                prospectDb = this.clientDbContext.vw_PS_Prospects($"RowID <> {prospect.RowID} AND Name = '{prospect.Name}'").FirstOrDefault();

            if (prospectDb == null)
            {
                return false;
            }
            else
            {
                if (prospect.RowID == default(int))
                    prospectDb = this.clientDbContext.vw_PS_Prospects($"Name = '{prospect.Name}' AND IdentityTypeID = {prospect.IdentityTypeID} AND IdentityNo = '{prospect.IdentityNo}'").FirstOrDefault();
                else
                    prospectDb = this.clientDbContext.vw_PS_Prospects($"RowID = {prospect.RowID} AND Name = '{prospect.Name}' AND IdentityTypeID = {prospect.IdentityTypeID} AND IdentityNo = '{prospect.IdentityNo}'").FirstOrDefault();

                if (prospectDb == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public bool AddAppProspect(App_Prospect prospect)
        {
            var parmsCollection = new ParmsCollection();
            var dataSet = this.clientDbContext.ExecuteQueryOrStoredProcedure_ToDataSet("[MobileApp].[addApp_Prospect]",
                            parmsCollection
                            .AddParm("@RowID", SqlDbType.Int, prospect.RowID)
                            .AddParm("@AppProspectID", SqlDbType.VarChar, prospect.AppProspectID)
                            .AddParm("@AccountID", SqlDbType.Int, prospect.AccountID)
                            .AddParm("@Address", SqlDbType.NVarChar, prospect.Address)
                            .AddParm("@Name", SqlDbType.NVarChar, prospect.Name)
                            .AddParm("@SexID", SqlDbType.Int, prospect.SexID)
                            .AddParm("@Birthday", SqlDbType.DateTime,
                                    (prospect.Birthday <= new DateTime(1947, 1, 1) || !prospect.Birthday.HasValue) ? DateTime.Now.Date : prospect.Birthday.Value.Date)
                            .AddParm("@NationalityID", SqlDbType.Int, prospect.NationalityID)
                            .AddParm("@MobilePhone", SqlDbType.VarChar, prospect.MobilePhone)
                            .AddParm("@Email", SqlDbType.VarChar, prospect.Email)
                            .AddParm("@IdentityTypeID", SqlDbType.Int, (prospect.IdentityTypeID == default(int)) ? 179 : prospect.IdentityTypeID)
                            .AddParm("@IdentityNo", SqlDbType.VarChar, prospect.IdentityNo)
                            .AddParm("@SaleAgentID", SqlDbType.Int, prospect.SaleAgentID)
                            .AddParm("@ProjectID", SqlDbType.Int, prospect.ProjectID)
                            .AddParm("@PhaseID", SqlDbType.Int, prospect.PhaseID)

                            .AddParm("@ProbabilityID", SqlDbType.Int, prospect.ProbabilityID)
                            .AddParm("@Remark", SqlDbType.NVarChar, prospect.Remark)

                            .AddParm("@CreateUserID", SqlDbType.Int, userContext.LoggedInUserId)
                            .AddParm("@CreateDate", SqlDbType.DateTime, DateTime.Now)
                            .AddParm("@ModifyUserID", SqlDbType.Int, userContext.LoggedInUserId)
                            .AddParm("@ModifyDate", SqlDbType.DateTime, DateTime.Now)
                            );

            return true;
        }

        public bool AddAppProspectFollowUp(App_ProspectFollowUp prospect)
        {
            var parmsCollection = new ParmsCollection();
            var dataSet = this.clientDbContext.ExecuteQueryOrStoredProcedure_ToDataSet("[MobileApp].[addApp_ProspectFollowUp]",
                            parmsCollection
                            .AddParm("@RowID", SqlDbType.Int, prospect.RowID)
                            .AddParm("@AppProspectID", SqlDbType.VarChar, prospect.AppProspectID)
                            .AddParm("@ProspectID", SqlDbType.Int, prospect.ProspectID)
                            .AddParm("@ActivityDate", SqlDbType.VarChar, prospect.ActivityDate)
                            .AddParm("@Activity", SqlDbType.NVarChar, prospect.Activity)

                            .AddParm("@CreateUserID", SqlDbType.Int, userContext.LoggedInUserId)
                            .AddParm("@CreateDate", SqlDbType.DateTime, DateTime.Now)
                            .AddParm("@ModifyUserID", SqlDbType.Int, userContext.LoggedInUserId)
                            .AddParm("@ModifyDate", SqlDbType.DateTime, DateTime.Now)
                            );

            return true;
        }

        public List<App_SaleAgent> GetSaleAgents()
        {
            return this.clientDbContext.App_SaleAgents();
        }

        public bool TransferProspect(App_ProspectTransfer prospectTransfer)
        {
            var parmsCollection = new ParmsCollection();
            var dataSet = this.clientDbContext.ExecuteQueryOrStoredProcedure_ToDataSet("[MobileApp].[addApp_ProspectTransfer]",
                            parmsCollection
                            .AddParm("@ProspectID", SqlDbType.Int, prospectTransfer.ProspectID)
                            .AddParm("@AgentId", SqlDbType.VarChar, prospectTransfer.AgentId)
                            .AddParm("@Remarks", SqlDbType.NVarChar, prospectTransfer.Remarks)

                            .AddParm("@CreateUserID", SqlDbType.Int, userContext.LoggedInUserId)
                            .AddParm("@CreateDate", SqlDbType.DateTime, DateTime.Now)
                            .AddParm("@ModifyUserID", SqlDbType.Int, userContext.LoggedInUserId)
                            .AddParm("@ModifyDate", SqlDbType.DateTime, DateTime.Now)
                            );

            return true;
        }

        public List<App_ProspectFollowUp> GetProspectFollowUps(string prospectNo)
        {
            return this.clientDbContext.App_ProspectFollowUps($"AppProspectID = '{prospectNo}'");
        }

        public bool AddAppSale(App_Sale sale)
        {
            var parmsCollection = new ParmsCollection();
            var dataSet = this.clientDbContext.ExecuteQueryOrStoredProcedure_ToDataSet("[MobileApp].[addApp_Sale]",
                            parmsCollection
                            .AddParm("@RowID", SqlDbType.Int, sale.RowID)

                            .AddParm("@AppProspectID", SqlDbType.VarChar, sale.AppProspectID)
                            .AddParm("@AccountNo", SqlDbType.VarChar, sale.AccountNo)

                            .AddParm("@ProspectID", SqlDbType.Int, sale.ProspectID)
                            .AddParm("@AccountID", SqlDbType.Int, sale.AccountID)

                            .AddParm("@CompanyID", SqlDbType.Int, sale.CompanyID)
                            .AddParm("@ProjectID", SqlDbType.Int, sale.ProjectID)
                            .AddParm("@PhaseID", SqlDbType.Int, sale.PhaseID)
                            .AddParm("@BlockID", SqlDbType.Int, sale.BlockID)
                            .AddParm("@UnitID", SqlDbType.Int, sale.UnitID)
                            .AddParm("@UnitNo", SqlDbType.VarChar, sale.UnitNo)
                            .AddParm("@CustomerName", SqlDbType.NVarChar, sale.CustomerName)
                            .AddParm("@MobilePhone", SqlDbType.NVarChar, sale.MobilePhone)
                            .AddParm("@Email", SqlDbType.VarChar, sale.Email)
                            .AddParm("@ReserveDate", SqlDbType.DateTime, (sale.ReserveDate == default(DateTime) ? DateTime.Now.Date : sale.ReserveDate.Date))
                            .AddParm("@ExpiryDate", SqlDbType.DateTime, ((sale.ExpiryDate == default(DateTime) || !sale.ExpiryDate.HasValue)
                                                                            ? ((sale.ReserveDate == default(DateTime) ? DateTime.Now.Date : sale.ReserveDate.Date)).AddDays(5)
                                                                            : sale.ExpiryDate.Value.Date))
                            .AddParm("@Remark", SqlDbType.VarChar, sale.Remark)
                            .AddParm("@SaleAgentID", SqlDbType.Int, userContext.SaleAgentId)
                            .AddParm("@ApproveByID", SqlDbType.Int, userContext.SaleAgentId)
                            .AddParm("@ApproveDate", SqlDbType.DateTime, DateTime.Now.Date)
                            .AddParm("@CreateUserID", SqlDbType.Int, userContext.LoggedInUserId)
                            .AddParm("@CreateDate", SqlDbType.DateTime, DateTime.Now)
                            .AddParm("@ModifyUserID", SqlDbType.Int, userContext.LoggedInUserId)
                            .AddParm("@ModifyDate", SqlDbType.DateTime, DateTime.Now)

                            .AddParm("@SaleType", SqlDbType.NVarChar, sale.SaleType)
                            .AddParm("@BookAmt", SqlDbType.Int, sale.BookAmt)

                            .AddParm("@ReferenceNo", SqlDbType.NVarChar, sale.ReferenceNo)
                            .AddParm("@PayMethod", SqlDbType.Int, sale.PayMethod)

                            .AddParm("@CurrencyID", SqlDbType.Int, sale.CurrencyID)
                            .AddParm("@BankAccountID", SqlDbType.Int, sale.BankAccountID)
                            );

            return true;
        }

        public List<App_Gender> GetAppGenders()
        {
            return this.clientDbContext.App_Genders();
        }

        public List<App_Identity> GetApp_Identities()
        {
            return this.clientDbContext.App_Identities();
        }

        public List<App_Nationality> GetApp_Nationalities()
        {
            return this.clientDbContext.App_Nationalities();
        }

        public List<vw_PS_PaymentHistory> GetPaymentHistoryByUnitId(int unitId)
        {
            var paymentHistory = this.clientDbContext.vw_PS_PaymentHistory($"UnitID = {unitId}");
            return paymentHistory.OrderByDescending(o => o.TransactionDate).ToList();
        }

        public List<vw_UnitActiveAgg> GetAvailableUnitsCount(int projectId, int phaseId, int blockId)
        {
            return this.clientDbContext.vw_UnitActiveAggs($"ProjectID = {projectId} AND PhaseID = {phaseId} AND BlockID = {blockId}");
        }

        public List<vw_Unit> GetAvailableUnits(int projectId, int phaseId, int blockId, string floorName, int unitTypeId)
        {
            return this.clientDbContext.Units($"ProjectID = {projectId} AND PhaseID = {phaseId} AND BlockID = {blockId} AND TypeId = {unitTypeId} AND FloorName = '{floorName}' AND IsAvailable = 1");
        }

        public bool CancelBooking(App_Sale saleRequest)
        {
            var parmsCollection = new ParmsCollection();
            var dataSet = this.clientDbContext.ExecuteQueryOrStoredProcedure_ToDataSet("[MobileApp].[cancelBooking]",
                            parmsCollection
                            .AddParm("@ReserveID", SqlDbType.Int, saleRequest.ReserveID)
                            .AddParm("@SaleID", SqlDbType.Int, saleRequest.SaleID)

                            .AddParm("@Remark", SqlDbType.NVarChar, saleRequest.Remark)

                            .AddParm("@cancelReasonId", SqlDbType.Int, saleRequest.CancelReasonId)
                            .AddParm("@createdBy", SqlDbType.Int, saleRequest.CreateUserID)
                            );

            return true;
        }

        public bool ConvertToSale(App_Sale saleRequest)
        {
            var parmsCollection = new ParmsCollection();
            var dataSet = this.clientDbContext.ExecuteQueryOrStoredProcedure_ToDataSet("[MobileApp].[convertToSale]",
                            parmsCollection
                            .AddParm("@SaleID", SqlDbType.Int, saleRequest.SaleID)
                            .AddParm("@UnitID", SqlDbType.Int, saleRequest.UnitID)
                            .AddParm("@SaleDate", SqlDbType.DateTime, saleRequest.SaleDate)

                            .AddParm("@Remark", SqlDbType.NVarChar, saleRequest.Remark)

                            .AddParm("@CreatedBy", SqlDbType.Int, saleRequest.CreateUserID)
                            );

            return true;
        }

        public bool ConvertToBook(App_Sale saleRequest)
        {
            var parmsCollection = new ParmsCollection();
            var dataSet = this.clientDbContext.ExecuteQueryOrStoredProcedure_ToDataSet("[MobileApp].[convertTobook]",
                            parmsCollection
                            .AddParm("@ReserveID", SqlDbType.Int, saleRequest.ReserveID)
                            .AddParm("@SaleID", SqlDbType.Int, saleRequest.SaleID)
                            .AddParm("@UnitID", SqlDbType.Int, saleRequest.UnitID)

                            .AddParm("@BookStartDate", SqlDbType.DateTime, saleRequest.ReserveDate)
                            .AddParm("@BookEndDate", SqlDbType.DateTime, saleRequest.ExpiryDate)

                            .AddParm("@Remark", SqlDbType.NVarChar, saleRequest.Remark)
                            .AddParm("@BookAmt", SqlDbType.Int, saleRequest.BookAmt)

                            .AddParm("@ReferenceNo", SqlDbType.NVarChar, saleRequest.ReferenceNo)
                            .AddParm("@PayMethod", SqlDbType.Int, saleRequest.PayMethod)

                            .AddParm("@CurrencyID", SqlDbType.Int, saleRequest.CurrencyID)
                            .AddParm("@BankAccountID", SqlDbType.Int, saleRequest.BankAccountID)

                            .AddParm("@CreatedBy", SqlDbType.Int, saleRequest.CreateUserID)
                            );

            return true;
        }

        public List<Currency> GetCurrencies()
        {
            return this.clientDbContext.Currencies($"IsBaseCurrency = 'Y' AND RecordStatus = 'Active'");
        }
        public List<App_UserToken> GetNotifications()
        {
            return this.clientDbContext.App_UserTokens($"UserId = {this.userContext.LoggedInUserId}");
        }
        public List<vw_BankAccount> GetBankAccounts(int unitId = 0, int currencyId = 0)
        {
            return this.clientDbContext.BankAccounts($"UnitID = {unitId} AND CurrencyID = {currencyId}");
        }

        public List<DashboardData> GetDashboardData(string teamOrAgent = "", int teamId = 0, int agentId = 0, int selectedProjectId = 0, bool showAll = false)
        {
            var parmsCollection = new ParmsCollection();
            var dataSet = this.clientDbContext.ExecuteQueryOrStoredProcedure_ToDataSet("[MobileApp].[dashboardData]",
                            parmsCollection
                            .AddParm("@userId", SqlDbType.Int, this.userContext.LoggedInUserId)
                            .AddParm("@teamOrAgent", SqlDbType.VarChar, teamOrAgent)
                            .AddParm("@teamId", SqlDbType.Int, teamId)
                            .AddParm("@agentId", SqlDbType.Int, agentId)
                            .AddParm("@selectedProjectId", SqlDbType.Int, selectedProjectId)
                            .AddParm("@showAll", SqlDbType.Bit, showAll)
                            );

            return dataSet.Tables[0].ToList<DashboardData>();
        }

        public List<PropertyData> GetPropertyData()
        {
            var parmsCollection = new ParmsCollection();
            var dataSet = this.clientDbContext.ExecuteQueryOrStoredProcedure_ToDataSet("[MobileApp].[getProjectData]",
                            parmsCollection
                            .AddParm("@userId", SqlDbType.Int, this.userContext.LoggedInUserId));

            return dataSet.Tables[0].ToList<PropertyData>();
        }

        public List<TeamData> GetTeamData(string teamOrAgent = "")
        {
            var parmsCollection = new ParmsCollection();
            var dataSet = this.clientDbContext.ExecuteQueryOrStoredProcedure_ToDataSet("[MobileApp].[getSalesPersonsData]",
                            parmsCollection
                            .AddParm("@userId", SqlDbType.Int, this.userContext.LoggedInUserId)
                            .AddParm("@teamOrAgent", SqlDbType.VarChar, teamOrAgent)
                            );

            return dataSet.Tables[0].ToList<TeamData>();
        }

        public List<ProspectData> GetProspectData()
        {
            var parmsCollection = new ParmsCollection();
            var dataSet = this.clientDbContext.ExecuteQueryOrStoredProcedure_ToDataSet("[MobileApp].[getProspectsData]",
                            parmsCollection
                            .AddParm("@userId", SqlDbType.Int, this.userContext.LoggedInUserId)
                            );

            return dataSet.Tables[0].ToList<ProspectData>();
        }

        private DataTable IntType
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("ParmValue", DbColumnType.Int);


                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }
    }
}
