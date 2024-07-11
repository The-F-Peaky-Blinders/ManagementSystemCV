using managementcv.App.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace managementcv.Controllers.WorkExperiences
{
    public class PutWorkExperiencesController : Controller
    {
        public readonly IWorkExperience _service;
        public PutWorkExperiencesController(IWorkExperience service)
        {
            _service = service;
        }
        
    }
}