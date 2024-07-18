using ManagementSystemCV.App.Interfaces;
using ManagementSystemCV.Models;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystemCV.Controllers.Users
{
    public class RegisterController : Controller
    {
        private readonly IUser _service;

        public RegisterController(IUser service)
        {
            _service = service;
        }

        // GET: /Users/Register (mostrar formulario)
        public IActionResult Register()
        {
            return View();
        }

        // POST: /Users/Register (procesar formulario)
        [HttpPost("Register")]
        public async Task<IActionResult> Register(User user)
        {
            if (ModelState.IsValid)
            {
                await _service.RegisterUserAsync(user);
                return RedirectToAction("Login", "Auth");
            }
            return View(user);
        }
    }
}
