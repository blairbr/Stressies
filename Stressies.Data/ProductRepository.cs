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
        private string connectionString = "Data Source = (LocalDb)\\MSSQLLocalDB; Initial Catalog = Stressies; Integrated Security = True;";

        private const string insertStatement =
            @"Insert into Products (Name, Description, QuantityInStock, Price)
            OUTPUT INSERTED.[Id], INSERTED.[Name], INSERTED.[Description], INSERTED.[QuantityInStock], INSERTED.[Price]
            VALUES (@Name, @Description, @QuantityInStock, @Price)";

        private const string selectAllProductsStatement =
            @"Select * from Products";

        private const string selectProductByIdStatement =
            @"Select * FROM Products WHERE Id = @Id";

        private const string deleteProductByIdStatement =
            @"DELETE FROM Products WHERE Id = @Id";

        private const string updateProductStatement =
            @"UPDATE Products
                SET Name = @Name, 
                    Description = @Description, 
                    QuantityInStock = @QuantityInStock, 
                    Price = @Price
              OUTPUT 
                    INSERTED.[Id], 
                    INSERTED.[Name], 
                    INSERTED.[Description], 
                    INSERTED.[QuantityInStock], 
                    INSERTED.[Price]
              WHERE Id = @Id";

        //  https://www.sqlservercentral.com/articles/the-output-clause-for-insert-and-delete-statements
        public async Task<Product> AddProduct(Product product)
        {
            //if you throw an exception here, it 'bubbles up' and is caught in the controller, and then you can control what is sent back to the client, for instance a 500 code ISE with some message
         //   throw new Exception("Exception in add product method");

            using (var connection = new SqlConnection(connectionString))
            {
                var returnedProduct = await connection.QuerySingleAsync<Product>(insertStatement, product);
                return returnedProduct;
                //why query single instead of query?
            }
        }
        //to return the object just inserted,
        //add OUTPUT to hard coded statements and then change the Execute Async to Query

        public async Task<IEnumerable<Product>> GetProducts() 
        {
            using (var connection = new SqlConnection(connectionString)) 
            {
                var products = await connection.QueryAsync<Product>(selectAllProductsStatement); //by default returns an ienumerable
                return products;
            }
        }

        public async Task<Product> GetProductById(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var product = await connection.QuerySingleAsync<Product>(selectProductByIdStatement, new { @Id = id }); 
                return product;
            }
        }

        public async Task DeleteProduct(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.ExecuteAsync(deleteProductByIdStatement, new { @Id = id });
            }
        }

        public async Task<Product> UpdateProduct(Product product) 
        { 
        //call into db

            using (var connection = new SqlConnection(connectionString))
            {
                var updatedProduct = await connection.QuerySingleAsync<Product>(updateProductStatement, product);
                return updatedProduct;
            }
        }
    }
}
