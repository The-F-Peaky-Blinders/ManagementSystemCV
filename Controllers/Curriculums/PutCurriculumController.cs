using ManagementSystemCV.App.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystemCV.Controllers.Curriculums
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