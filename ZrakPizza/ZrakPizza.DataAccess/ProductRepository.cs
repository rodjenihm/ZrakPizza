using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
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

        public async Task<IEnumerable<Product>> GetAll(bool includeVariants = true)
        {
            using (var connection = new SqlConnection(_connectionString.Value))
            {
                if (includeVariants)
                {
                    var sql = "[Products_GetAllWithVariants]";

                    var dic = new Dictionary<string, Product>();

                    var result = await connection.QueryAsync<Product, VariantOption, Product>(sql, (p, v) =>
                    {
                        if (!dic.TryGetValue(p.Id, out Product product)) dic.Add(p.Id, product = p);

                        product.VariantOptions.Add(v);

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
