using ManagementSystemCV.App.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystemCV.Controllers.Curriculums
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