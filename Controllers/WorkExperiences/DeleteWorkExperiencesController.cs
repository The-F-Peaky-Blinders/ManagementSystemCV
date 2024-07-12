using managementcv.App.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace managementcv.Controllers.WorkExperiences
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