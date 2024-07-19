using ManagementSystemCV.App.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystemCV.Controllers.Languages
{
    public class PostLanguageController : Controller
    {
        public readonly ILanguage _service;
        public PostLanguageController(ILanguage service)
        {
            _service = service;
        }
        
    }
}