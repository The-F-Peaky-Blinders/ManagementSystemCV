using managementcv.App.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace managementcv.Controllers.Educations
{
    public class PostEducationController : Controller
    {
        public readonly IEducation _service;
        public PostEducationController(IEducation service)
        {
            _service = service;
        }
        
    }
}