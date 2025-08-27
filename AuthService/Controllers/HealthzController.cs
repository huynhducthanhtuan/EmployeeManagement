using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers
{
    [ApiController]
    [Route("Healthz")]
    public class HealthzController : ControllerBase
    {
        private readonly ILogger<HealthzController> _logger;

        public HealthzController(ILogger<HealthzController> logger)
        {
            _logger = logger;
        }

        [HttpGet("")]
        public async Task<IActionResult> HealthCheck()
        {
            return Ok("Service is alive!");
        }
    }
}
