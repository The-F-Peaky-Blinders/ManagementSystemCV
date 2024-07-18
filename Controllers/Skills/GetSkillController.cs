using ManagementSystemCV.App.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace ManagementSystemCV.Controllers.Skills
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