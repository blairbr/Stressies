using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stressies.Data;
using Stressies.Domain;

namespace Stressies.Controllers
{
    [Route("api/[controller]")] //change this
    [ApiController]
    public class ProductController : ControllerBase
    {
        public ProductController(ProductRepository productRepository)
        {
    
        }

        public async Task<Customer> AddCustomer(Customer customer)
        {
            using (var connection = new SqlConnection(connectionString))
                //call the stored proc
                await connection.ExecuteAsync(insertStatement, customer);
            return customer;
        }

        public async Task<Customer> AddCustomer(Customer customer)
        {
            using (var connection = new SqlConnection(connectionString))
                //call the stored proc
                await connection.ExecuteAsync(insertStatement, customer);
            return customer;
        }

        [HttpPost]
        [Route("/product")]
        public Task<Product> AddProductAsync(Product product) { 
            using (var connection = new SqlConnection(connectionString))
        }

        [HttpGet]


        [HttpPut]


        [HttpDelete]

    }
}