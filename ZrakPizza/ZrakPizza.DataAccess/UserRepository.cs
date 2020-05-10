using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZrakPizza.DataAccess.Entities;
using Dapper;
using System.Data.SqlClient;
using System.Linq;

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

        public async Task<User> GetByUsername(string username)
        {
            using (var connection = new SqlConnection(_connectionString.Value))
            {
                var user = (await connection.QueryAsync<User>("[Users_GetByUsername] @UserName",
                    new { UserName = username }))
                    .FirstOrDefault();

                return user;
            }
        }
    }
}
