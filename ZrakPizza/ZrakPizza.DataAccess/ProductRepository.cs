﻿using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using ZrakPizza.DataAccess.Entities;

namespace ZrakPizza.DataAccess
{
    public class ProductRepository : IProductRepository
    {
        private readonly ConnectionString _connectionString;

        public ProductRepository(ConnectionString connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<Product>> GetAll(bool includeProductOptions = true)
        {
            using (var connection = new SqlConnection(_connectionString.Value))
            {
                if (includeProductOptions)
                {
                    var sql = "[Products_GetAllWithProductOptions]";

                    var dic = new Dictionary<string, Product>();

                    var result = await connection.QueryAsync<Product, ProductOption, Product>(sql, (p, po) =>
                    {
                        if (!dic.TryGetValue(p.Id, out Product product)) dic.Add(p.Id, product = p);

                        product.ProductOptions.Add(po);

                        return p;
                    });

                    return dic.Values;
                }
                else
                {
                    var sql = "[Products_GetAll]";

                    var result = await connection.QueryAsync<Product>(sql);

                    return result;
                }
            }
        }
    }
}
