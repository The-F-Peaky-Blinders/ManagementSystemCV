using ManagementSystemCV.App.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystemCV.Controllers.WorkExperiences
{
    public class DeleteWorkExperiencesController : Controller
    {
        public readonly IWorkExperience _service;
        public DeleteWorkExperiencesController(IWorkExperience service)
        {
            _service = service;
        }
        
    }
}