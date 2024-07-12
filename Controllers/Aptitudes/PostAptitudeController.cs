using managementcv.App.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace managementcv.Controllers.Aptitudes
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