using ManagementSystemCV.App.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystemCV.Controllers.Users
{
    public class DeleteUserController : Controller
    {
        public readonly IUser _service;
        public DeleteUserController(IUser service)
        {
            _service = service;
        }
        
    }
}