using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;
using prueba.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using System;
using managementcv.App.Interfaces;
using ManagementSystemCV.App.Interfaces;

namespace prueba.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUser _userService;
        private readonly IJwtAuthenticationService _jwtAuthenticationService;

        public HomeController(ILogger<HomeController> logger, IUser userService, IJwtAuthenticationService jwtAuthenticationService)
        {
            _logger = logger;
            _userService = userService;
            _jwtAuthenticationService = jwtAuthenticationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var user = await _userService.GetUserByEmailAsync(email);

            if (user == null || !VerifyPassword(password, user.Password))
            {
                return Unauthorized(new { message = "El correo electrónico o la contraseña son incorrectos." });
            }

            var token = _jwtAuthenticationService.GenerateJwtToken(user.Email);
            return Ok(new { token });
        }


        private bool VerifyPassword(string password, string storedPassword)
        {
            return password == storedPassword;
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}