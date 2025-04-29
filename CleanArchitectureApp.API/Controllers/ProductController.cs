using CleanArchitectureApp.API.Base;
using CleanArchitectureApp.Application.Features.Products.Commands.CreateProduct;
using CleanArchitectureApp.Application.Features.Products.Queries.GetProductDetail;
using CleanArchitectureApp.Application.Features.Products.Queries.GetProductsList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureApp.API.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController(IMediator mediator) : AppControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductCommand command)
        {
            return CustomResult(await Mediator.Send(command));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return CustomResult(await Mediator.Send(new GetAllProductsQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return CustomResult(await Mediator.Send(new GetProductByIdQuery() { Id = id}));
        }
    }
}
