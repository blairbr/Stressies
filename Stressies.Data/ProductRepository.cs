using Dapper;
using Stressies.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Stressies.Data
{
    public class ProductRepository : IProductRepository
    {
        private const string insertStatement = @"Insert into Products VALUES @ProductName = ProductName, @ProductDescription = ProductDescripton, @QuantityInStock, @ProductPrice";
        public async Task<Product> AddProduct(Product product)
        {
            using (var connection = new SqlConnection())
            {
                return await connection.QuerySingleAsync(insertStatement);
            }
        }
        //to return the object just inserted,
        //add OUTPUT to hard coded statements and then change the Execute Async to Query
    }
}
