using CasCap.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasCap.Controllers
{
    public class AboutController : Controller
    {
        private readonly ILogger<AboutController> _logger;
        private readonly IDITestService _diTestSvc;

        public AboutController(ILogger<AboutController> logger, IDITestService diTestSvc)
        {
            _logger = logger;
            _diTestSvc = diTestSvc;
        }

        public IActionResult Index()
        {
            var vm = new IndexViewModel
            {
                SomeIntValues = _diTestSvc.GetIntValues(),
                SomeStringValues = _diTestSvc.GetStringValues()
            };
            return View(vm);
        }
    }
}