using ManagementSystemCV.App.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace ManagementSystemCV.Controllers.Skills
{
    public class PutSkillController : Controller
    {
        public readonly ISkill _service;
        public PutSkillController(ISkill service)
        {
            _service = service;
        }
        
    }
}