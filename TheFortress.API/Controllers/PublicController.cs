using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheFortress.API.Attributes;

namespace TheFortress.API.Controllers
{
    [NTypewriterIgnore]
    [ApiController]
    [Route("api/[controller]")]
    public class PublicController : ControllerBase
    {
        private readonly ILogger<PublicController> _logger;

        public PublicController(ILogger<PublicController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(new { date = DateTime.UtcNow.ToString() });
        }
    }
}
