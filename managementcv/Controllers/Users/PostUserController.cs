using managementcv.App.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace managementcv.Controllers.Users
{
    public class PostUserController : Controller
    {
        public readonly IUser _service;
        public PostUserController(IUser service)
        {
            _service = service;
        }
        
    }
}