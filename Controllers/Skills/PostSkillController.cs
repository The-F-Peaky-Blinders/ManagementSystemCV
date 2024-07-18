using ManagementSystemCV.App.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace ManagementSystemCV.Controllers.Skills
{
    public class PostSkillController : Controller
    {
        public readonly ISkill _service;
        public PostSkillController(ISkill service)
        {
            _service = service;
        }
        
    }
}