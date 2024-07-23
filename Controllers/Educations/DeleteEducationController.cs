using ManagementSystemCV.App.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystemCV.Controllers.Educations
{
    public class DeleteEducationController : Controller
    {
        public readonly IEducation _service;
        public DeleteEducationController(IEducation service)
        {
            _service = service;
        }
        
    }
}