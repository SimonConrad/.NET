using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Orders.Web.RequestModels;

namespace Orders.Web.Controllers
{
    // TODO Obsługa [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            _logger.LogInformation($"Hello from GET inside {nameof(OrderController)}");

            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] OrderReqModel orderReqModel)
        {
            // INFO The[ApiController] attribute makes model validation errors automatically trigger an HTTP 400 response.
            // Consequently, the following code is unnecessary in an action method:
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest("Invalid data");
            //}

            return Ok();
        }
    }
}