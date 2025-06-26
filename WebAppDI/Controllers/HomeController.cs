using CasCap.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasCap.Controllers
{
    public class HomeController : Controller
    {
        readonly ILogger<HomeController> _logger;
        readonly IDITestService _diTestSvc;

        public HomeController(ILogger<HomeController> logger, IDITestService diTestSvc)
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}