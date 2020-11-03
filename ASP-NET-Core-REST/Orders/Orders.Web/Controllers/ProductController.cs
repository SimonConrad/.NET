using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public ProductController(IProductRepository productRepository, 
            IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        [HttpGet]  // INFO idempotenta i bezpieczna
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async ValueTask<IActionResult> Get()
        {
            IEnumerable<ProductDbo> resTemp = await _productRepository.Get();
            var res = resTemp.Select(x => _mapper.Map<ProductReqModel>(x));

            return Ok(res);
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

            var res = _mapper.Map<ProductReqModel>(resTemp);

            return Ok(res);
        }

        [HttpPost] // INFO nieidempotenta i niebezpieczna
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async ValueTask<IActionResult> Post([FromBody] ProductReqModel productReqModel)
        { 
            long id = await _productRepository.Create(_mapper.Map<ProductDbo>(productReqModel));

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

            await _productRepository.Update(id, _mapper.Map<ProductDbo>(productReqMode));

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