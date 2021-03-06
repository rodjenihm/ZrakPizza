﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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

        public async Task AddVariant(string cartId, string productOptionId)
        {
            using (var connection = new SqlConnection(_connectionString.Value))
            {
                var sql = "[CartVariants_Create] @Id, @CartId, @ProductOptionId";

                var result = await connection.ExecuteAsync(sql,
                    new { Id = Guid.NewGuid().ToString("N"), CartId = cartId, @ProductOptionId = productOptionId });
            }
        }

        public async Task Create(Cart cart)
        {
            using (var connection = new SqlConnection(_connectionString.Value))
            {
                var sql = "[Carts_Create] @Id, @ItemsCount, @ItemsTotalPrice";

                var result = await connection.ExecuteAsync(sql, cart);
            }
        }
        public async Task Clear(string cartId)
        {
            using (var connection = new SqlConnection(_connectionString.Value))
            {
                var sql = "[CartVariants_DeleteAll] @CartId";

                var result = await connection.ExecuteAsync(sql,
                    new { CartId = cartId });
            }
        }

        public async Task<Cart> GetById(string cartId)
        {
            using (var connection = new SqlConnection(_connectionString.Value))
            {
                var sql = "[Carts_GetByIdWithItems] @Id";

                var dic = new Dictionary<string, Cart>();

                var result = await connection.QueryAsync<Cart, ProductVariant, Cart>(
                    sql,
                    (c, pv) =>
                    {
                        if (!dic.TryGetValue(c.Id, out Cart cart)) dic.Add(c.Id, cart = c);

                        if (pv != null) cart.Items.Add(pv);

                        return c;
                    },
                    new { Id = cartId });

                return dic.Values.FirstOrDefault();
            }
        }

        public async Task RemoveVariant(string cartId, string productOptionId)
        {
            using (var connection = new SqlConnection(_connectionString.Value))
            {
                var sql = "[CartVariants_DeleteByProductOptionId] @CartId, @ProductOptionId";

                var result = await connection.ExecuteAsync(sql,
                    new { CartId = cartId, @ProductOptionId = productOptionId });
            }
        }
    }
}
