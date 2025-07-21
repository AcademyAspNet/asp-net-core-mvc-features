using Microsoft.AspNetCore.Mvc;
using WebApplication7.Data.Models;
using WebApplication7.Models.DTO;
using WebApplication7.Models.Utils;
using WebApplication7.Models.Views;
using WebApplication7.Services;

namespace WebApplication7.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly IReviewService _reviewService;

        public ProductsController(IProductService productService, IReviewService reviewService)
        {
            _productService = productService;
            _reviewService = reviewService;
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

        public IActionResult CreateReview([FromRoute] int? id, [FromForm] ReviewDTO review)
        {
            if (id is null)
                return RedirectToAction("Index");

            Product? product = _productService.GetProductById((int)id);

            if (product is null)
                return RedirectToAction("Index");

            if (!ModelState.IsValid)
            {
                ProductViewModel model = new ProductViewModel()
                {
                    Product = product,
                    Review = review
                };

                return View("~/Views/Products/GetById.cshtml", model);
            }

            _reviewService.CreateReview(product.Id, review);

            return RedirectToAction("GetById", new { id = product.Id });
        }
    }
}
