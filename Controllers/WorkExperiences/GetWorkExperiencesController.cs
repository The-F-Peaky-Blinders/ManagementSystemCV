using managementcv.App.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace managementcv.Controllers.WorkExperiences
{
    public class GetWorkExperiencesController : Controller
    {
        public readonly IWorkExperience _service;
        public GetWorkExperiencesController(IWorkExperience service)
        {
            _service = service;
        }
        
    }
}