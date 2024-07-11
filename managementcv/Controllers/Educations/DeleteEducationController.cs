using managementcv.App.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace managementcv.Controllers.Educations
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