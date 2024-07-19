using ManagementSystemCV.App.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystemCV.Controllers.Curriculums
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