using managementcv.App.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace managementcv.Controllers.Curriculums
{
    public class PutCurriculumController : Controller
    {
        public readonly ICurriculum _service;
        public PutCurriculumController(ICurriculum service)
        {
            _service = service;
        }
        
    }
}