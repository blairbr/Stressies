using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
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
        private IProductRepository productRepository;
        public ProductController(ProductRepository _productRepository)
        {
            productRepository = _productRepository;
        }

        public async Task<Product> AddProduct(Product product)
        {
            var response = await productRepository.AddProduct(product);
            return response;
        }

        //public async Task<Customer> AddCustomer(Customer customer)
        //{
        //    using (var connection = new SqlConnection(connectionString))
        //        //call the stored proc
        //        await connection.ExecuteAsync(insertStatement, customer);
        //    return customer;
        //}

        //[HttpPost]
        //[Route("/product")]
        //public Task<Product> AddProductAsync(Product product) { 
        //    using (var connection = new SqlConnection(connectionString))
        //}

        //[HttpGet]


        //[HttpPut]


        //[HttpDelete]


    }
}