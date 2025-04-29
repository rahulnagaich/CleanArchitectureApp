using CleanArchitectureApp.API.Base;
using CleanArchitectureApp.Application.Features.Orders.Commands.CreateOrder;
using CleanArchitectureApp.Application.Features.Orders.Queries.GetOrderDetail;
using CleanArchitectureApp.Application.Features.Orders.Queries.GetOrderList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureApp.API.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController(IMediator mediator) : AppControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrderCommand command)
        {
            return CustomResult(await Mediator.Send(command));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return CustomResult(await Mediator.Send(new GetAllOrdersQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return CustomResult(await Mediator.Send(new GetOrderByIdQuery(id)));
        }
    }
}
