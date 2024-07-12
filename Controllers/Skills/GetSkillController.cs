using managementcv.App.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace managementcv.Controllers.Skills
{
    public class GetSkillController : Controller
    {
        public readonly ISkill _service;
        public GetSkillController(ISkill service)
        {
            _service = service;
        }
        
    }
}