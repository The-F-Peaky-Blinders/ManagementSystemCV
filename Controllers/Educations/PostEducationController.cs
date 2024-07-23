using ManagementSystemCV.App.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystemCV.Controllers.Educations
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