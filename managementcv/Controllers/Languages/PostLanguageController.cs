using managementcv.App.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace managementcv.Controllers.Languages
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