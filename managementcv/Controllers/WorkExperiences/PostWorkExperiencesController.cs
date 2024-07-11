using managementcv.App.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace managementcv.Controllers.WorkExperiences
{
    public class PostWorkExperiencesController : Controller
    {
        public readonly IWorkExperience _service;
        public PostWorkExperiencesController(IWorkExperience service)
        {
            _service = service;
        }
        
    }
}