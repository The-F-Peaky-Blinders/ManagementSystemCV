using ManagementSystemCV.App.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystemCV.Controllers.Curriculums
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