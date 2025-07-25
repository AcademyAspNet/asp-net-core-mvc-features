using Microsoft.AspNetCore.Mvc;
using WebApplication7.Data.Models;
using WebApplication7.Models.DTO;
using WebApplication7.Models.Utils;
using WebApplication7.Services;

namespace WebApplication7.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Authorization()
        {
            ViewBag.Breadcrumb = new List<BreadcrumbItem>()
            {
                new BreadcrumbItem("Авторизация", "Auth", "Authorization")
            };

            return View(new UserCredentialsDto());
        }

        [HttpPost]
        public IActionResult LogIn([FromForm] UserCredentialsDto userCredentialsDto)
        {
            if (!ModelState.IsValid)
                return View("Authorization", userCredentialsDto);

            User? user = _authService.GetUserByCredentials(userCredentialsDto);

            if (user is null)
            {
                ViewBag.ErrorMessage = "Неправильный адрес электронной почты или пароль.";
                return View("Authorization", userCredentialsDto);
            }

            HttpContext.Session.SetInt32("UserId", user.Id);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Registration()
        {
            ViewBag.Breadcrumb = new List<BreadcrumbItem>()
            {
                new BreadcrumbItem("Регистрация", "Auth", "Registration")
            };

            return View(new NewUserDto());
        }

        [HttpPost]
        public IActionResult SignUp([FromForm] NewUserDto newUserDto)
        {
            if (!ModelState.IsValid)
                return View("Registration", newUserDto);

            try
            {
                _authService.CreateUser(newUserDto);
            }
            catch (Exception)
            {
                ViewBag.ErrorMessage = "Что-то пошло не так.";
                return View("Registration", newUserDto);
            }

            return RedirectToAction("Authorization");
        }
    }
}
