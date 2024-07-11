using managementcv.App.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace managementcv.Controllers.Skills
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