using IQSoft.eCommerce.Entities.Core;
using IQSoft.eCommerce.Utilities.Helpers;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using IQSoft.eCommerce.Utilities.Extensions;

namespace IQSoft.eCommerce.ResourceAccess
{
    public class BaseDbContext
    {
        public BaseDbContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public string ConnectionString { get; set; }

        #region Cache
        private string GetTableCacheKey(string tableName, string whereCondition = "", string orderBy = "")
        {
            return (tableName + "_"
                + (string.IsNullOrWhiteSpace(whereCondition) ? string.Empty : whereCondition) + "_"
                + (string.IsNullOrWhiteSpace(orderBy) ? string.Empty : orderBy)
                );
        }
        public List<T> GetFromCache<T>(string tableName, string whereCondition = "", string orderBy = "") where T : new()
        {
            var cacheKey = GetTableCacheKey(tableName, whereCondition, orderBy);

            return CacheHelper.Instance.Get<List<T>>(cacheKey);
        }

        public void PutInCache<T>(List<T> value, string tableName, string whereCondition = "", string orderBy = "", int clientId = 0) where T : new()
        {
            var cacheKey = GetTableCacheKey(tableName, whereCondition, orderBy);

            CacheHelper.Instance.Set<List<T>>(cacheKey, value, clientId);
        }
        #endregion

        #region Stored Procedures
        public List<T> ExecuteStoredProcedure_ToList<T>(string procedureName, List<SqlParameter> parms = null) where T : new()
        {
            var result = this.ExecuteQueryOrStoredProcedure_ToDataSet(procedureName, parms, CommandType.StoredProcedure);            
            return (result.Tables.Count > 0) ? result.Tables[0].ToList<T>() : new List<T>();
        }

        public DataTable ExecuteStoredProcedure_ToDataTable(string procedureName, List<SqlParameter> parms = null)
        {
            var result = this.ExecuteQueryOrStoredProcedure_ToDataSet(procedureName, parms, CommandType.StoredProcedure);
            return (result.Tables.Count > 0) ? result.Tables[0] : null;
        }

        public DataSet ExecuteQueryOrStoredProcedure_ToDataSet(string queryOrProcedure, List<SqlParameter> parms = null, CommandType commandType = CommandType.StoredProcedure)
        {
            var result = new DataSet();
            using (var sqlConnection = new SqlConnection(this.ConnectionString))
            {
                try
                {
                    sqlConnection.Open();
                    using (var sqlCommand = new SqlCommand(queryOrProcedure, sqlConnection))
                    {
                        sqlCommand.CommandType = commandType;
                        sqlCommand.CommandTimeout = ConfigSettings.Instance.Data.CommandTimeout;

                        if (parms != null && parms.Count > 0)
                        {
                            for (int i = 0; i < parms.ToArray().Length; i++)
                            {
                                sqlCommand.Parameters.Add(parms[i]);
                            }
                        }
                        var sqlAdapter = new SqlDataAdapter(sqlCommand);
                        sqlAdapter.Fill(result);
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
                finally
                {
                    try
                    {
                        sqlConnection.Close();
                    }
                    catch { }
                }
            }

            return result;
        }

        public int ExecuteNonQuery(string queryOrProcedure, List<SqlParameter> parms = null, CommandType commandType = CommandType.StoredProcedure)
        {
            var result = default(int);
            using (var sqlConnection = new SqlConnection(this.ConnectionString))
            {
                try
                {
                    sqlConnection.Open();
                    using (var sqlCommand = new SqlCommand(queryOrProcedure, sqlConnection))
                    {
                        sqlCommand.CommandType = commandType;
                        sqlCommand.CommandTimeout = ConfigSettings.Instance.Data.CommandTimeout;

                        if (parms != null && parms.Count > 0)
                        {
                            for (int i = 0; i < parms.ToArray().Length; i++)
                            {
                                sqlCommand.Parameters.Add(parms[i]);
                            }
                        }
                        result = sqlCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
                finally
                {
                    try
                    {
                        sqlConnection.Close();
                    }
                    catch { }
                }
            }

            return result;
        }

        public string ExecuteScalar(string queryOrProcedure, List<SqlParameter> parms = null, CommandType commandType = CommandType.Text)
        {
            var result = default(string);
            using (var sqlConnection = new SqlConnection(this.ConnectionString))
            {
                try
                {
                    sqlConnection.Open();
                    using (var sqlCommand = new SqlCommand(queryOrProcedure, sqlConnection))
                    {
                        sqlCommand.CommandType = commandType;
                        sqlCommand.CommandTimeout = ConfigSettings.Instance.Data.CommandTimeout;

                        if (parms != null && parms.Count > 0)
                        {
                            for (int i = 0; i < parms.ToArray().Length; i++)
                            {
                                sqlCommand.Parameters.Add(parms[i]);
                            }
                        }
                        var rawResult = sqlCommand.ExecuteScalar();

                        if (rawResult != null && rawResult != DBNull.Value)
                        {
                            result = rawResult.ToString();
                        }

                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
                finally
                {
                    try
                    {
                        sqlConnection.Close();
                    }
                    catch { }
                }
            }

            return result;
        }

        #endregion

        #region Query
        public List<T> ExecuteQuery_ToList<T>(string query, List<SqlParameter> parms = null) where T : new()
        {
            var result = this.ExecuteQueryOrStoredProcedure_ToDataSet(query, parms, CommandType.Text);
            return (result.Tables.Count > 0) ? result.Tables[0].ToList<T>() : new List<T>();
        }

        public List<T> GetTable<T>(string tableName, string whereCondition = "", string orderBy = "", bool isCache = false) where T : new()
        {
            var result = default(List<T>);
            if (!string.IsNullOrWhiteSpace(whereCondition))
            {
                whereCondition = " WHERE " + whereCondition;
            }

            if (!string.IsNullOrWhiteSpace(orderBy))
            {
                orderBy = " ORDER BY " + orderBy;
            }

            if (isCache)
            {
                result = this.GetFromCache<T>(tableName, whereCondition, orderBy);
            }
            if (result == null || result.Count == 0)
            {
                var query = $"SELECT * FROM {tableName} {whereCondition} {orderBy}";
                result = this.ExecuteQuery_ToList<T>(query);

                if (isCache && result.Count > 0)
                {
                    this.PutInCache<T>(result, tableName, whereCondition, orderBy);
                }
            }

            return result;
        }

        public DataTable ExecuteQuery_ToDataTable(string query, List<SqlParameter> parms = null)
        {
            var result = this.ExecuteQueryOrStoredProcedure_ToDataSet(query, parms, CommandType.Text);
            return (result.Tables.Count > 0) ? result.Tables[0] : null;
        }

        #endregion

        #region Commented for EF
        /*
        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }
        */
        #endregion
    }
}
