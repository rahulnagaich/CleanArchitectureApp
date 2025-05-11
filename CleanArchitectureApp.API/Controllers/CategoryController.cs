using CleanArchitectureApp.Application.Features.Categories.Commands.CreateCategory;
using CleanArchitectureApp.Application.Features.Categories.Commands.DeleteCategory;
using CleanArchitectureApp.Application.Features.Categories.Commands.UpdateCategory;
using CleanArchitectureApp.Application.Features.Categories.Queries;
using CleanArchitectureApp.Application.Features.Categories.Queries.GetCategoriesList;
using CleanArchitectureApp.Application.Features.Categories.Queries.GetCategoriesListWithProducts;
using CleanArchitectureApp.Application.Features.Categories.Queries.GetCategoryDetail;


namespace CleanArchitectureApp.API.Controllers
{
    [Route("api/category")]
    [Produces("application/json")]
    [ApiController]
    public class CategoryController : AppControllerBase
    {
        /// <summary>
        /// Creates a new category.
        /// </summary>
        /// <param name="command">The category details.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>The ID of the created category.</returns>
        /// <response code="201">Category created successfully.</response>
        /// <response code="400">Invalid input.</response>
        [HttpPost]
        [ProducesResponseType(typeof(BaseResponse<Guid>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(BaseResponse<List<string>>), StatusCodes.Status422UnprocessableEntity)]
        //[ProducesResponseType(typeof(BaseResponse<ValidationErrorDto>), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(BaseResponse<object>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponse<object>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] CreateCategoryCommand command, CancellationToken cancellationToken)
        {
            return CustomResult(await Mediator.Send(command, cancellationToken));
        }

        /// <summary>
        /// Gets all categories with pagination and filtering.
        /// </summary>
        /// <param name="query">Filtering and paging parameters.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Paged list of categories.</returns>
        /// <response code="200">Returns categories.</response>
        [HttpGet]
        [ProducesResponseType(typeof(BaseResponse<List<CategoryDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponse<object>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll([FromQuery]  GetAllCategoriesQuery query, CancellationToken cancellationToken)
        {
            return CustomResult(await Mediator.Send(query, cancellationToken));
        }

        /// <summary>
        /// Gets a category by its ID.
        /// </summary>
        /// <param name="id">Category ID.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>The category if found.</returns>
        /// <response code="200">Returns the category.</response>
        /// <response code="404">Category not found.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BaseResponse<CategoryDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponse<object>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BaseResponse<object>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            return CustomResult(await Mediator.Send(new GetCategoryByIdQuery(id), cancellationToken));
        }

        /// <summary>
        /// Deletes a category by its ID.
        /// </summary>
        /// <param name="id">Category ID.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>No content.</returns>
        /// <response code="204">Category deleted.</response>
        /// <response code="404">Category not found.</response>
        [HttpDelete("{id:guid}")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(BaseResponse<CategoryDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponse<object>), StatusCodes.Status404NotFound)]
       // [ProducesResponseType(typeof(BaseResponse<object>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(BaseResponse<object>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            return CustomResult(await Mediator.Send(new DeleteCategoryCommand(id), cancellationToken));
        }

        /// <summary>
        /// Updates a category.
        /// </summary>
        /// <param name="id">Category ID.</param>
        /// <param name="command">Updated category data.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>The updated category.</returns>
        /// <response code="200">Category updated.</response>
        /// <response code="400">Invalid request.</response>
        /// <response code="404">Category not found.</response>
        [HttpPut("{id:guid}")]
        [ProducesResponseType(typeof(BaseResponse<CategoryDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponse<List<string>>), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(BaseResponse<object>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponse<object>), StatusCodes.Status404NotFound)]
        //[ProducesResponseType(typeof(BaseResponse<ValidationErrorDto>), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(BaseResponse<object>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCategoryCommand command, CancellationToken cancellationToken)
        {
            var fullCommand = new UpdateCategoryCommand
            {
                CategoryId = id,
                Name = command.Name,
                Description = command.Description
            };

            return CustomResult(await Mediator.Send(fullCommand, cancellationToken));
        }

        /// <summary>
        /// Gets all categories along with their products.
        /// </summary>
        /// <param name="query">Filter and pagination parameters.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Paged list of categories with their products.</returns>
        /// <response code="200">Returns categories with products.</response>
        [HttpGet("with-products")]
        [ProducesResponseType(typeof(PagedResponse<CategoryDto>), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(BaseResponse<List<string>>), StatusCodes.Status422UnprocessableEntity)] // Validation errors
        [ProducesResponseType(typeof(BaseResponse<object>), StatusCodes.Status400BadRequest)] // Bad input
        [ProducesResponseType(typeof(BaseResponse<object>), StatusCodes.Status404NotFound)] // Not found
        //[ProducesResponseType(typeof(BaseResponse<object>), StatusCodes.Status401Unauthorized)] // Unauthorized
        [ProducesResponseType(typeof(BaseResponse<object>), StatusCodes.Status500InternalServerError)] // Server errors
        public async Task<IActionResult> GetAllWithProducts([FromQuery] GetAllCategoriesWithProductsQuery query, CancellationToken cancellationToken)
        {
            return CustomResult(await Mediator.Send(query, cancellationToken));
        }
    }
}
