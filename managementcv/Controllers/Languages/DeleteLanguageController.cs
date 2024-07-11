using managementcv.App.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace managementcv.Controllers.Languages
{
    public class DeleteLanguageController : Controller
    {
        public readonly ILanguage _service;
        public DeleteLanguageController(ILanguage service)
        {
            _service = service;
        }
        
    }
}