using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasCap.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StringsController : ControllerBase
    {
        readonly ILogger<StringsController> _logger;
        readonly IDITestService _diTestSvc;

        public StringsController(ILogger<StringsController> logger, IDITestService diTestSvc)
        {
            _logger = logger;
            _diTestSvc = diTestSvc;
        }

        [HttpGet("testdi")]
        public IActionResult TestDI()
        {
            _logger.LogTrace("TestDI REST endpoint fired...");
            var strings = _diTestSvc.GetStringValues();
            return Ok(strings);
        }
    }
}