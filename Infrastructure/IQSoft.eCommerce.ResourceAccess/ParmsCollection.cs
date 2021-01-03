using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;

namespace IQSoft.eCommerce.ResourceAccess
{
    public class ParmsCollection : List<SqlParameter>
    {
        public ParmsCollection AddParm(string parameterName, SqlDbType dbType, object value, string typeName = null)
        {
            var parmeter = new SqlParameter { ParameterName = parameterName, SqlDbType = dbType };

            parmeter.Value = (value != null) ? value : DBNull.Value;

            if (!string.IsNullOrWhiteSpace(typeName)) parmeter.TypeName = typeName;

            this.Add(parmeter);

            return this;
        }
    }
}
