using Stressies.Data;
using Stressies.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stressies.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<Product> AddProduct(Product product)
        {
            var addedProduct = await productRepository.AddProduct(product);
            return addedProduct;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var products = await productRepository.GetProducts();
            return products;
        }

        public async Task<Product> GetProductById(int id) 
        {
            var product = await productRepository.GetProductById(id);
            return product; 
        }

        public async Task DeleteProduct(int id) 
        {
            await productRepository.DeleteProduct(id);
        }

        public async Task<Product> UpdateProduct(Product product) 
        {
            var updatedProduct = await productRepository.UpdateProduct(product);
            return updatedProduct;
        }
    }
}
