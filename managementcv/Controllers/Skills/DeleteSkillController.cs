using managementcv.App.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace managementcv.Controllers.Skills
{
    public class DeleteSkillController : Controller
    {
        public readonly ISkill _service;
        public DeleteSkillController(ISkill service)
        {
            _service = service;
        }

    }
}