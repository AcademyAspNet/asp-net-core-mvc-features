using Microsoft.AspNetCore.Mvc;
using WebApplication7.Models.DTO;
using WebApplication7.Models.Entities;
using WebApplication7.Models.Utils;
using WebApplication7.Models.Views;
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
            IList<Product> products = _productService.GetProducts();

            ViewBag.Breadcrumb = new List<BreadcrumbItem>()
            {
                new BreadcrumbItem("Список товаров", "Products", "Index")
            };

            return View(products);
        }

        public IActionResult GetById([FromRoute] int? id)
        {
            if (id is null)
                return RedirectToAction("Index");

            Product? product = _productService.GetProductById((int) id);

            if (product is null)
                return RedirectToAction("Index");

            ProductViewModel model = new ProductViewModel()
            {
                Product = product,
                Review = new ReviewDTO()
            };

            ViewBag.Breadcrumb = new List<BreadcrumbItem>()
            {
                new BreadcrumbItem("Список товаров", "Products", "Index"),
                new BreadcrumbItem(product.Name, "Products", "GetById")
            };

            return View(model);
        }
    }
}
