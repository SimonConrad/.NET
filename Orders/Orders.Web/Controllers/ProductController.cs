using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Orders.Web.RequestModels;

namespace Orders.Web.Controllers
{
    // TODO Obsługa [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]  // INFO idempotenta i bezpieczna
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpGet("{id}")] // INFO idempotenta i bezpieczna
        [ProducesResponseType(StatusCodes.Status200OK)] // INFO, Dla Swagger-a
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            return Ok();
        }

        [HttpPost] // INFO nieidempotenta i niebezpieczna
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] ProductReqModel productReqModel)
        {
            return Ok();
        }

        [HttpPut("{id}")] // INFO idempotenta i niebezpieczna
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Put(int id, [FromBody] ProductReqModel productReqMode)
        {
            return NoContent();
        }

        [HttpDelete("{id}")] // INFO idempotenta i niebezpieczna
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }
    }
}