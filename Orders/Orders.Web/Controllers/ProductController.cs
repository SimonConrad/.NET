using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Orders.Dal;
using Orders.Dal.Dbos;
using Orders.Web.RequestModels;

namespace Orders.Web.Controllers
{
    // TODO Obsługa [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]  // INFO idempotenta i bezpieczna
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async ValueTask<IActionResult> Get()
        {
            IEnumerable<ProductDbo> resTemp = await _productRepository.Get();

            return Ok();
        }

        [HttpGet("{id}")] // INFO idempotenta i bezpieczna
        [ProducesResponseType(StatusCodes.Status200OK)] // INFO, Dla Swagger-a
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async ValueTask<IActionResult> Get(long id)
        {
            ProductDbo resTemp = await _productRepository.Get(id);

            if (resTemp == null)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPost] // INFO nieidempotenta i niebezpieczna
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async ValueTask<IActionResult> Post([FromBody] ProductReqModel productReqModel)
        { 
            long id = await _productRepository.Create(new ProductDbo());

           return CreatedAtAction(nameof(Get), new { id = id });
        }

        [HttpPut("{id}")] // INFO idempotenta i niebezpieczna
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async ValueTask<IActionResult> Put(long id, [FromBody] ProductReqModel productReqMode)
        {
            if (!(await _productRepository.Exists(id)))
            {
                return NotFound();
            }

            await _productRepository.Update(id, new ProductDbo());

            return NoContent();
        }

        [HttpDelete("{id}")] // INFO idempotenta i niebezpieczna
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async ValueTask<IActionResult> Delete(long id)
        {
            if (!(await _productRepository.Exists(id)))
            {
                return NotFound();
            }

            await _productRepository.Delete(id);

            return NoContent();
        }
    }
}