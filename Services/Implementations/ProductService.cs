using WebApplication7.Models.Entities;

namespace WebApplication7.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly List<Product> _products = new List<Product>()
        {
            new Product() { Id = 1, Name = "Белый хлеб", Description = "Просто белый хлеб.", Price = 15 },
            new Product() { Id = 2, Name = "Черный хлеб", Description = "Просто черный хлеб.", Price = 20 },
            new Product() { Id = 3, Name = "Продукт 3", Price = 15 },
            new Product() { Id = 4, Name = "Продукт 4", Description = "Продукт 4", Price = 20 }
        };

        public List<Product> GetProducts()
        {
            return _products;
        }

        public Product? GetProductById(int id)
        {
            foreach (Product product in _products)
            {
                if (product.Id == id)
                    return product;
            }

            return null;
        }
    }
}
