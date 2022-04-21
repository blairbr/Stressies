using Microsoft.AspNetCore.Mvc;
using Stressies.Domain;
using Stressies.Services;
using System;
using System.Threading.Tasks;

namespace Stressies.Controllers
{
    [Route("api/[controller]")]

    public class CustomerController : ControllerBase
    {
        private ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
           _customerService = customerService;
        }

        [HttpGet("{id}")]
        public async Task<Customer> GetCustomerById([FromRoute]string id) 
        {
            try
            {
                var result = await _customerService.GetCustomerById(id);
                return result;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer([FromBody]Customer customer) 
        {
            try
            {
                var newCustomer = await _customerService.AddCustomer(customer);
                return Ok(newCustomer);
            }
            catch (ArgumentException argumentException) {
                return BadRequest(argumentException.Message);
            }
            catch (Exception exception)
            {
                return StatusCode(500, exception.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute]int id) 
        {
            try
            {
                await _customerService.DeleteCustomer(id);
                return Ok();
            }
            catch (Exception exception)
            {
                throw exception; //redo this
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomer([FromBody]Customer customer) 
        {
            try
            {
                var result = await _customerService.UpdateCustomer(customer);
                return Ok();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
         
    }
}