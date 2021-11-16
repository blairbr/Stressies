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
    public class CustomerController : Controller
    {
        //CRUD
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

        public async Task<IActionResult> DeleteCustomer(Customer customer) 
        {
            await customerService.DeleteCustomer(customer);
            return Ok();

        }
    }
}