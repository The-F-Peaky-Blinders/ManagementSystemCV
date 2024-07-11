using managementcv.App.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace managementcv.Controllers.Users
{
    public class PutUserController : Controller
    {
        public readonly IUser _service;
        public PutUserController(IUser service)
        {
            _service = service;
        }
        
    }
}