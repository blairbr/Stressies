using Stressies.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stressies.Data
{
    public interface IProductRepository
    {
        Task<Product> AddProduct(Product product);
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProductById(int id);
        Task DeleteProduct(int id);
        Task<Product> UpdateProduct(Product product);
    }
}