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
           return await _customerRepository.GetCustomerById(id);
        }

        public async Task DeleteCustomer(int id) 
        {
            await _customerRepository.DeleteCustomer(id);
        }

        public async Task<Customer> AddCustomer(Customer customer)
        {
            await _customerRepository.AddCustomer(customer);
            //need to change this later to map to a data entity

            return customer;
        }

        public async Task<Customer> UpdateCustomer(Customer customer) 
        {
           var result =  await _customerRepository.UpdateCustomer(customer);
            return result;
        }
    }
}
