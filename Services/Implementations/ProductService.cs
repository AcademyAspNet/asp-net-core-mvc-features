using WebApplication7.Data.Models;
using WebApplication7.Data.Repositories;
using WebApplication7.Data.Repositories.Implementations;

namespace WebApplication7.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;

        public ProductService(IRepository<Product> productRepository)
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
