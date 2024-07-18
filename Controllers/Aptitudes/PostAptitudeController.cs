using ManagementSystemCV.App.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystemCV.Controllers.Aptitudes
{
    public class PostAptitudeController  : Controller
    {
        public readonly IAptitude _service;
        public PostAptitudeController(IAptitude service)
        {
            _service = service;
        }
    
    }
}