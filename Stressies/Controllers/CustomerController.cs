using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stressies.Domain;
using Stressies.Services;

namespace Stressies.Controllers
{
    [Route("[controller]")]  //api/Customer in this case

    public class CustomerController : ControllerBase
    {

    //does the file as a whole take a route attribute? []
        private ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet("{id}")] //dont need slash before
        public async Task<Customer> GetCustomerById(string id) 
        {
            try
            {
                var result = await customerService.GetCustomerById(id);
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
                var newCustomer = await customerService.AddCustomer(customer);
                return Ok(newCustomer);
            }
            catch (ArgumentException argumentException) {
                return BadRequest(argumentException.Message);
            }
            catch (Exception exception)
            {
                return StatusCode(500, exception.Message);
                //later add logging
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute]int id) 
        {
            try
            {
                await customerService.DeleteCustomer(id);
                return Ok();
            }
            catch (Exception exception)
            {
                throw exception; //redo this
            }
        }

        [HttpPut]
        //async method that returns a task of a customer and calls into service class

        public async Task<IActionResult> UpdateCustomer([FromBody]Customer customer) 
        {
            try
            {
                var result = await customerService.UpdateCustomer(customer);
                return Ok();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
         

    }
}