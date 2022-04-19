using Microsoft.AspNetCore.Mvc;
using Stressies.Domain;
using Stressies.Services;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Stressies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        //Return types on Controllers should be IActionResult?
        //endpoint 
        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            if (product == null)
            {
                return BadRequest("Product must not be null.");
            }

            try
            {
                var returnedProduct = await _productService.AddProduct(product);
                return Ok(returnedProduct);
            }
            catch (Exception ex)
            {
                //return BadRequest(ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
            //in the UI, an if statement to catch 500 and display some nice error message
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var returnedProducts = await _productService.GetProducts();
            return Ok(returnedProducts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productService.GetProductById(id);
            return Ok(product);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody]Product product) //the from body makes it explicit, but isn't necessary
        {
            var updatedProduct = await _productService.UpdateProduct(product);
            return Ok(updatedProduct);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id) 
        {
            await _productService.DeleteProduct(id);
            return Ok();
        }

    }
}