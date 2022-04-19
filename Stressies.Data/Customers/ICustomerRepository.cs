using Stressies.Domain;
using System.Threading.Tasks;

namespace Stressies.Data.Customers
{
    public interface ICustomerRepository
    {
        Task<Customer> AddCustomer(Customer customer);
        Task DeleteCustomer(int customerId);
        Task<Customer> GetCustomerById(string id);
        Task<Customer> UpdateCustomer(Customer customer);
    }
}