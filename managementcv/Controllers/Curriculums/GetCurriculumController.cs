using managementcv.App.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace managementcv.Controllers.Curriculums
{
    public class GetCurriculumController : Controller
    {
        public readonly ICurriculum _service;
        public GetCurriculumController(ICurriculum service)
        {
            _service = service;
        }
        
    }
}