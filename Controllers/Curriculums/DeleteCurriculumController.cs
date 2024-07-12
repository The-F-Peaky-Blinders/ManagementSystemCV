using managementcv.App.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace managementcv.Controllers.Curriculums
{
    public class DeleteCurriculumController : Controller
    {
        public readonly ICurriculum _service;
        public DeleteCurriculumController(ICurriculum service)
        {
            _service = service;
        }
        
    }
}