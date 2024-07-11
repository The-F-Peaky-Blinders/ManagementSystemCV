using managementcv.App.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace managementcv.Controllers.Educations
{
    public class GetEducationController : Controller
    {
        public readonly IEducation _service;
        public GetEducationController(IEducation service)
        {
            _service = service;
        }
        
    }
}