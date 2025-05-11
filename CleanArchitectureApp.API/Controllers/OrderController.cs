using CleanArchitectureApp.Application.Features.Orders.Commands.CreateOrder;
using CleanArchitectureApp.Application.Features.Orders.Queries;
using CleanArchitectureApp.Application.Features.Orders.Queries.GetOrderDetail;
using CleanArchitectureApp.Application.Features.Orders.Queries.GetOrderList;

namespace CleanArchitectureApp.API.Controllers
{
    [Route("api/order")]
    [Produces("application/json")]
    [ApiController]
    public class OrderController : AppControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(BaseResponse<Guid>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(BaseResponse<List<string>>), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(BaseResponse<object>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponse<object>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] CreateOrderCommand command, CancellationToken cancellationToken)
        {
            return CustomResult(await Mediator.Send(command, cancellationToken));
        }

        [HttpGet]
        [ProducesResponseType(typeof(PagedResponse<OrderDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponse<object>), StatusCodes.Status400BadRequest)] // Bad input
        [ProducesResponseType(typeof(BaseResponse<object>), StatusCodes.Status404NotFound)] // Not found
        [ProducesResponseType(typeof(BaseResponse<object>), StatusCodes.Status500InternalServerError)] // Server errors
        public async Task<IActionResult> GetAll([FromQuery] GetAllOrdersQuery query, CancellationToken cancellationToken)
        {
            return CustomResult(await Mediator.Send(query, cancellationToken));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BaseResponse<OrderDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponse<object>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BaseResponse<object>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            return CustomResult(await Mediator.Send(new GetOrderByIdQuery(id), cancellationToken));
        }
    }
}
