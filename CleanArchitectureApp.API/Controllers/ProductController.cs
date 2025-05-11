using CleanArchitectureApp.Application.Features.Products.Commands.CreateProduct;
using CleanArchitectureApp.Application.Features.Products.Queries;
using CleanArchitectureApp.Application.Features.Products.Queries.GetProductDetail;
using CleanArchitectureApp.Application.Features.Products.Queries.GetProductsList;

namespace CleanArchitectureApp.API.Controllers
{
    [Route("api/product")]
    [Produces("application/json")]
    [ApiController]
    public class ProductController : AppControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(BaseResponse<Guid>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(BaseResponse<List<string>>), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(BaseResponse<object>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponse<object>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] CreateProductCommand command, CancellationToken cancellationToken)
        {
            return CustomResult(await Mediator.Send(command, cancellationToken));
        }

        [HttpGet]
        [ProducesResponseType(typeof(PagedResponse<ProductDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponse<object>), StatusCodes.Status400BadRequest)] // Bad input
        [ProducesResponseType(typeof(BaseResponse<object>), StatusCodes.Status404NotFound)] // Not found
        [ProducesResponseType(typeof(BaseResponse<object>), StatusCodes.Status500InternalServerError)] // Server errors
        public async Task<IActionResult> GetAll([FromQuery] GetAllProductsQuery query, CancellationToken cancellationToken)
        {
            return CustomResult(await Mediator.Send(query, cancellationToken));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BaseResponse<ProductDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponse<object>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BaseResponse<object>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            return CustomResult(await Mediator.Send(new GetProductByIdQuery() { Id = id}, cancellationToken));
        }
    }
}
