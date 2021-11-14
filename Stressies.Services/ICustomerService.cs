using Stressies.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Stressies.Services
{
    public interface ICustomerService
    {
        Task<Customer> AddCustomer(Customer customer);

    }
}
