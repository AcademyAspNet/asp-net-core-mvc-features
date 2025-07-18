using WebApplication7.Data.Models;

namespace WebApplication7.Services
{
    public interface IProductService
    {
        IList<Product> GetProducts();
        Product? GetProductById(int id);
    }
}
