using CleanArchitectureApp.Application.Features.Customers.Commands.CreateCustomer;
using CleanArchitectureApp.Application.Features.Customers.Queries;
using CleanArchitectureApp.Application.Features.Customers.Queries.GetCustomerDetail;
using CleanArchitectureApp.Application.Features.Customers.Queries.GetCustomerList;

namespace CleanArchitectureApp.API.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class CustomerController : AppControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(BaseResponse<Guid>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(BaseResponse<List<string>>), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(BaseResponse<object>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponse<object>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] CreateCustomerCommand command, CancellationToken cancellationToken)
        {
            return CustomResult(await Mediator.Send(command, cancellationToken));
        }

        [HttpGet]
        [ProducesResponseType(typeof(PagedResponse<CustomerDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponse<object>), StatusCodes.Status400BadRequest)] // Bad input
        [ProducesResponseType(typeof(BaseResponse<object>), StatusCodes.Status404NotFound)] // Not found
        [ProducesResponseType(typeof(BaseResponse<object>), StatusCodes.Status500InternalServerError)] // Server errors
        public async Task<IActionResult> GetAll([FromBody] GetAllCustomersQuery query, CancellationToken cancellationToken)
        {
            return CustomResult(await Mediator.Send(query, cancellationToken));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BaseResponse<CustomerDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponse<object>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BaseResponse<object>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            return CustomResult(await Mediator.Send(new GetCustomerByIdQuery(id),cancellationToken));
        }
    }
}
