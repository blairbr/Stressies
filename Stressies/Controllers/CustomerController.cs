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
    public class CustomerController : ControllerBase
    {

    //does the file as a whole take a route attribute? []
        private ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet("/customer/{id}")]
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


        [HttpPost("/customer")]
        public async Task<IActionResult> AddCustomer([FromBody]Customer customer) 
        {
            try
            {
                await customerService.AddCustomer(customer);
                return Ok(customer);
            }
            catch (Exception exception)
            {
                throw exception; //fix this later
            }
        }

        [HttpDelete("/customer/{id}")]
        //convert to int? or is it a string?
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

        [HttpPut("/customer")]
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