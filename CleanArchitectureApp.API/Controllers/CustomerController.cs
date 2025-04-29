using CleanArchitectureApp.API.Base;
using CleanArchitectureApp.Application.Features.Customers.Commands.CreateCustomer;
using CleanArchitectureApp.Application.Features.Customers.Queries.GetCustomerDetail;
using CleanArchitectureApp.Application.Features.Customers.Queries.GetCustomerList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : AppControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCustomerCommand command)
        {
            return CustomResult(await Mediator.Send(command));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return CustomResult(await Mediator.Send(new GetAllCustomersQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return CustomResult(await Mediator.Send(new GetCustomerByIdQuery(id)));
        }
    }
}
