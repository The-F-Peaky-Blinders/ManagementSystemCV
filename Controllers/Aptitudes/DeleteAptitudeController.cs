using ManagementSystemCV.App.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystemCV.Controllers.Aptitudes
{
    public class DeleteAptitudeController : Controller
    {
        public readonly IAptitude _service;
        public DeleteAptitudeController(IAptitude service)
        {
            _service = service;
        }
        
    }
}