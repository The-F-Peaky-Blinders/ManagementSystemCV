using managementcv.App.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace managementcv.Controllers.Curriculums
{
    public class PostCurriculumController : Controller
    {
        public readonly ICurriculum _service;
        public PostCurriculumController(ICurriculum service)
        {
            _service = service;
        }
        
    }
}