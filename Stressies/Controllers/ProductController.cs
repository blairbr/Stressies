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

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody]Product product)
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
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
            //In the UI you could have an if statement to catch the 500 and display some nice error message
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var returnedProducts = await _productService.GetProducts();
            return Ok(returnedProducts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById([FromRoute]int id)
        {
            var product = await _productService.GetProductById(id);
            return Ok(product);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody]Product product)
        {
            var updatedProduct = await _productService.UpdateProduct(product);
            return Ok(updatedProduct);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute]int id) 
        {
            await _productService.DeleteProduct(id);
            return Ok();
        }

    }
}