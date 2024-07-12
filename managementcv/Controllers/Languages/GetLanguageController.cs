using managementcv.App.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace managementcv.Controllers.Languages
{
    public class GetLanguageController : Controller
    {
        public readonly ILanguage _service;
        public GetLanguageController(ILanguage service)
        {
            _service = service;
        }
        
    }
}