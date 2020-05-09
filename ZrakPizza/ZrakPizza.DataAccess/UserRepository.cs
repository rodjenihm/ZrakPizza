using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZrakPizza.DataAccess.Entities;
using Dapper;
using System.Data.SqlClient;

namespace ZrakPizza.DataAccess
{
    public class UserRepository : IUserRepository
    {
        private readonly ConnectionString _connectionString;

        public UserRepository(ConnectionString connectionString)
        {
            _connectionString = connectionString;
        }


        public async Task Create(User user)
        {
            using (var connection = new SqlConnection(_connectionString.Value))
            {
                var sql = @"[Users_Create] @Id, @UserName, @Name, @PasswordHash";
                var result = await connection.ExecuteAsync(sql, user);
            }
        }
    }
}
