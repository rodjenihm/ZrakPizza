using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using ZrakPizza.DataAccess.Entities;

namespace ZrakPizza.DataAccess
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly ConnectionString _connectionString;

        public UserRoleRepository(ConnectionString connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<Role>> GetRolesForUser(string userId)
        {
            using (var connection = new SqlConnection(_connectionString.Value))
            {
                var sql = "[UserRoles_GetRolesForUser] @UserId";

                var result = await connection.QueryAsync<Role>(sql, new { UserId = userId });

                return result;
            }
        }
    }
}
