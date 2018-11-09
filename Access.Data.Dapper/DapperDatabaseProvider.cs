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
        public async Task<bool> CallStoredProcedure(string schema, string procedureName, object parameters)
        {
            using (var connection = new SqlConnection(_config.GetConnectionString("Default")))
            {
                await connection.OpenAsync();
                await connection.QueryAsync("[" + schema + "].[" + procedureName + "]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);
                return true;
            }
        }
    }
}
