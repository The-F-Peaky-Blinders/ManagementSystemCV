using ManagementSystemCV.App.Interfaces;
using ManagementSystemCV.Models;
using ManagementSystemCV.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ManagementSystemCV.Controllers.Auth
{
    public class RegisterController : Controller
    {
        private readonly IUser _service;

        public RegisterController(IUser service)
        {
            _service = service;
        }

        // GET: /Auth/Register (mostrar formulario)
        public IActionResult Register()
        {
            return View();
        }

        // POST: /Auth/Register (procesar formulario)
        [HttpPost]
        public async Task<IActionResult> Register([FromForm] RegisterUserDTO registerUserDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (registerUserDTO.Password != registerUserDTO.ConfirmPassword)
                    {
                        return BadRequest(new { success = false, message = "Las contraseñas no coinciden." });
                    }

                    var user = new User
                    {
                        FirstName = registerUserDTO.FirstName,
                        LastName = registerUserDTO.LastName,
                        Email = registerUserDTO.Email,
                        Password = registerUserDTO.Password // Este password debe ser hasheado antes de guardarlo en la base de datos
                    };

                    await _service.RegisterUserAsync(user);
                    return Ok(new { success = true });
                }
                catch (Exception ex)
                {
                    // Log the error
                    Console.WriteLine(ex.Message);
                    return StatusCode(500, new { success = false, message = "Error al registrar el usuario: " + ex.Message });
                }
            }

            return BadRequest(new { success = false, message = "Datos inválidos." });
        }
    }
}
