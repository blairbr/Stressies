using Stressies.Domain;
using System.Threading.Tasks;

namespace Stressies.Data
{
    public interface IProductRepository
    {
        public Task<Product> AddProduct(Product product);
    }
}