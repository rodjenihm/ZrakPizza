﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZrakPizza.DataAccess.Entities;

namespace ZrakPizza.DataAccess
{
    public class CartRepository : ICartRepository
    {
        private readonly ConnectionString _connectionString;

        public CartRepository(ConnectionString connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task Create(Cart cart)
        {
            using (var connection = new SqlConnection(_connectionString.Value))
            {
                var sql = "[Carts_Create] @Id, @ItemsCount, @ItemsTotalPrice";

                var result = await connection.ExecuteAsync(sql, cart);
            }
        }

        public async Task<Cart> GetById(string cartId)
        {
            using (var connection = new SqlConnection(_connectionString.Value))
            {
                var sql = "[Carts_GetById] @Id";

                var cart = (await connection.QueryAsync<Cart>(sql,
                    new { Id = cartId }))
                    .FirstOrDefault();

                return cart;
            }
        }
    }
}
