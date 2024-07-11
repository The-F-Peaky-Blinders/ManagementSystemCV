using managementcv.App.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace managementcv.Controllers.Skills
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