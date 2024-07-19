using ManagementSystemCV.App.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ManagementSystemCV.Models;

namespace ManagementSystemCV.Controllers.Users
{
    public class GetUserController : Controller
    {
        public readonly IUser _service;
        public GetUserController(IUser service)
        {
            _service = service;
        }   

        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _service.GetAllUsersAsync();
            return Ok(users);
        } 
        
    }
}