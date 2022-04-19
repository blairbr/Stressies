using Stressies.Data.Customers;
using Stressies.Domain;
using System;
using System.Threading.Tasks;

namespace Stressies.Services
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer> GetCustomerById(string id)
        {
           var customer = await _customerRepository.GetCustomerById(id);
           return customer;
        }

        public async Task DeleteCustomer(int id) 
        {
            await _customerRepository.DeleteCustomer(id);
        }

        public async Task<Customer> AddCustomer(Customer customer)
        {
            if (string.IsNullOrWhiteSpace(customer.FirstName)) {
                throw new ArgumentException("First name cannot be empty.");
            }
            var addedCustomer = await _customerRepository.AddCustomer(customer);
            return addedCustomer;
        }

        public async Task<Customer> UpdateCustomer(Customer customer) 
        {
            //add error handling
           var result =  await _customerRepository.UpdateCustomer(customer);
            return result;
        }
    }
}
