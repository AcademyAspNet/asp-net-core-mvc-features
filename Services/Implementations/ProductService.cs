using WebApplication7.Data.Repositories;
using WebApplication7.Models.Entities;

namespace WebApplication7.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly ProductRepository _productRepository;

        public ProductService(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IList<Product> GetProducts()
        {
            return _productRepository.GetAll();
        }

        public Product? GetProductById(int id)
        {
            return _productRepository.GetById(id);
        }
    }
}
