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
        //Cx R U D
        private ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
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


    }
}