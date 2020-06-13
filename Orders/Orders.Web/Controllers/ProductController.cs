using System.Threading.Tasks;
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
        public async Task<IActionResult> Get()
        {
            await Task.Delay(100);

            return Ok();
        }

        [HttpGet("{id}")] // INFO idempotenta i bezpieczna
        [ProducesResponseType(StatusCodes.Status200OK)] // INFO, Dla Swagger-a
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            await Task.Delay(100);

            return Ok();
        }

        [HttpPost] // INFO nieidempotenta i niebezpieczna
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] ProductReqModel productReqModel)
        {
            await Task.Delay(100);

            return Ok();
        }

        [HttpPut("{id}")] // INFO idempotenta i niebezpieczna
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(int id, [FromBody] ProductReqModel productReqMode)
        {
            await Task.Delay(100);

            return NoContent();
        }

        [HttpDelete("{id}")] // INFO idempotenta i niebezpieczna
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await Task.Delay(100);

            return NoContent();
        }
    }
}