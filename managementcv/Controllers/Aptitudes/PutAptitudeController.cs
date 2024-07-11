using managementcv.App.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace managementcv.Controllers.Aptitudes
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