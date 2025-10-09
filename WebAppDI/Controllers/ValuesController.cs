using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
namespace CasCap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        readonly ILogger<ValuesController> _logger;
        readonly IDITestService _diTestSvc;

        public ValuesController(ILogger<ValuesController> logger, IDITestService diTestSvc)
        {
            _logger = logger;
            _diTestSvc = diTestSvc;
        }

        [HttpGet("TestDI")]
        public IActionResult TestDI()
        {
            _logger.LogTrace("TestDI REST endpoint fired...");
            var ints = _diTestSvc.GetIntValues();
            return Ok(ints);
        }
    }
}
