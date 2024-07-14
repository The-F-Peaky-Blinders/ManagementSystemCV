using managementcv.App.Interfaces;
using managementcv.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace managementcv.Controllers.Users
{
    public class PostUserController : Controller
    {
        private readonly IUser _service;

        public PostUserController(IUser service)
        {
            _service = service;
        }

        // GET: /Users/Register (mostrar formulario)
        public IActionResult Register()
        {
            return View();
        }

        // POST: /Users/Register (procesar formulario)
        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            if (ModelState.IsValid)
            {
                await _service.RegisterUserAsync(user);
                return RedirectToAction("Index", "Home");
            }
            return View(user);
        }
    }
}
