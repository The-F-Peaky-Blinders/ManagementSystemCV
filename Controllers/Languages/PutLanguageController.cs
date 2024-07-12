using managementcv.App.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace managementcv.Controllers.Languages
{
    public class PutLanguageController : Controller
    {
        public readonly ILanguage _service;
        public PutLanguageController(ILanguage service)
        {
            _service = service;
        }
        
    }
}