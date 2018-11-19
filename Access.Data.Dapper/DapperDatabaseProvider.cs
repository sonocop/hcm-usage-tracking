using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Access.Data.Dapper
{
    public class DapperDatabaseProvider : IDatabaseProvider
    {
        public readonly IConfiguration _config;
        public DapperDatabaseProvider(IConfiguration config) {
            _config = config;
        }
        public void CallStoredProcedure(string schema, string procedureName, object parameters)
        {
            using (var connection = new SqlConnection(_config.GetConnectionString("defaultConnection")))
            {
                connection.Open();
                connection.Query("[" + schema + "].[" + procedureName + "]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}
