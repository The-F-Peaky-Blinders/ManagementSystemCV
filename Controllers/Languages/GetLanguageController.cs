using ManagementSystemCV.App.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystemCV.Controllers.Languages
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