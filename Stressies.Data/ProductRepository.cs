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
        private string const AddStatement = @"Insert into Products VALUES @ProductName = ProductName, @ProductDescription = ProductDescripton, @QuantityInStock, @ProductPrice";
        public Task<Product> AddProduct(Product product) { 
         (using SqlConnection sqlConnection) { 
            sqlConnection.
            }
        }
    }
}
