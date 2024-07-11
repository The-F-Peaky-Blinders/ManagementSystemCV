using managementcv.App.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace managementcv.Controllers.Educations
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