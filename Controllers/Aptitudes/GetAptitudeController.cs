using ManagementSystemCV.App.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystemCV.Controllers.Aptitudes
{
    public class GetAptitudeController : Controller
    {
        public readonly IAptitude _service;
        public GetAptitudeController(IAptitude service)
        {
            _service = service;
        }
    
    }
}