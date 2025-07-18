using WebApplication7.Models.Entities;

namespace WebApplication7.Services
{
    public interface IProductService
    {
        IList<Product> GetProducts();
        Product? GetProductById(int id);
    }
}
