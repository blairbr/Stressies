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

        public async Task<IActionResult> AddCustomer(Customer customer) 
        {
            await customerService.AddCustomer(customer);
            return Ok(customer);
        } 
    }
}