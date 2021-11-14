using Stressies.Data.Customers;
using Stressies.Domain;
using System;

namespace Stressies.Services
{
    public class CustomerService
    {
        private ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async System.Threading.Tasks.Task<Customer> AddCustomer(Customer customer)
        {
            await _customerRepository.AddCustomer(customer);
            //need to change this later to map to a data entity

            return customer;
        }
    }
}
