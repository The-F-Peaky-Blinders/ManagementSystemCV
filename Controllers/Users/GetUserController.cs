using managementcv.App.Interfaces;
using managementcv.Models;
using Microsoft.AspNetCore.Mvc;

namespace managementcv.Controllers.Users
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