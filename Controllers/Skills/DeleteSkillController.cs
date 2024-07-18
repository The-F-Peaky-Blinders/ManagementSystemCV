using ManagementSystemCV.App.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystemCV.Controllers.Skills
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