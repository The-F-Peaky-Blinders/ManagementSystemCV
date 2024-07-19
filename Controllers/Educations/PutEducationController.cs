using ManagementSystemCV.App.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystemCV.Controllers.Educations
{
    public class PutEducationController : Controller
    {
        public readonly IEducation _service;
        public PutEducationController(IEducation service)
        {
            _service = service;
        }
        
    }
}