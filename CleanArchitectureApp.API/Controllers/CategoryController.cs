using CleanArchitectureApp.API.Base;
using CleanArchitectureApp.Application.Features.Categories.Commands.CreateCategory;
using CleanArchitectureApp.Application.Features.Categories.Queries.GetCategoriesList;
using CleanArchitectureApp.Application.Features.Categories.Queries.GetCategoryDetail;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CleanArchitectureApp.API.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : AppControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryCommand command)
        {
            return CustomResult(await Mediator.Send(command));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return CustomResult(await Mediator.Send(new GetAllCategoriesQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return CustomResult(await Mediator.Send(new GetCategoryByIdQuery(id)));
        }
    }
}
