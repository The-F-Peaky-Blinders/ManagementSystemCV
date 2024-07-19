using ManagementSystemCV.App.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystemCV.Controllers.Aptitudes
{
    public class PutAptitudeController : Controller
    {
        public readonly IAptitude _service;
        public PutAptitudeController(IAptitude service)
        {
            _service = service;
        }
        
    }
}