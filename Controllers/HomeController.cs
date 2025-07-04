using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text;
using WebApplication7.Models.Utils;

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
