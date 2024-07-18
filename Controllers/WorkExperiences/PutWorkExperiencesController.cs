using ManagementSystemCV.App.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystemCV.Controllers.WorkExperiences
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