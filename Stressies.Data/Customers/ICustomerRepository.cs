using Stressies.Domain;
using System.Threading.Tasks;

namespace Stressies.Data.Customers
{
    public interface ICustomerRepository
    {
        Task AddCustomer(Customer customer);
    }
}