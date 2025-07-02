using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text;

namespace WebApplication7.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
