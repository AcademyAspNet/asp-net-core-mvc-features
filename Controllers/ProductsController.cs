using Microsoft.AspNetCore.Mvc;
using WebApplication7.Models.Entities;
using WebApplication7.Models.Utils;
using WebApplication7.Services;

namespace WebApplication7.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            List<Product> products = _productService.GetProducts();

            ViewBag.Breadcrumb = new List<BreadcrumbItem>()
            {
                new BreadcrumbItem("Список товаров", "Products", "Index")
            };

            return View(products);
        }
    }
}
