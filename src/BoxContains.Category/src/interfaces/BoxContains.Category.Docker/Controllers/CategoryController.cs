using BoxContains.Category.Application.Features.Commands.CreateCategory;
using BoxContains.Category.Application.Features.Queries.GetAllCategories;
using BoxContains.Category.Application.Features.Queries.GetCategoryById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;


namespace BoxContains.Category.Docker.Controllers;

/// <summary>
/// This is the controller for Categories.
/// </summary>
[Route("[controller]/[action]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly IMediator _mediator;

    /// <summary>
    /// Constructer for CategoryController
    /// </summary>
    public CategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Creates a new Category
    /// </summary>
    /// <param name="createCategoryCommand"></param>
    /// <returns>CreateCategoryDto</returns>
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [Produces("application/json")]
    [HttpPost(Name = "CreateCategory")]
    public async Task<ActionResult<CreateCategoryDto>> CreateCategory([FromBody] CreateCategoryCommand createCategoryCommand)
    {
        var response = await _mediator.Send(createCategoryCommand);
        return Ok(response);
    }

    /// <summary>
    /// List all Categories
    /// </summary>
    /// <returns>List of Categories</returns>
    [HttpGet(Name = "ListAllCategories")]
    [SwaggerOperation(Summary = "List All Categories")]
    [SwaggerResponse(StatusCodes.Status200OK, "All Categories", typeof(GetAllCategoriesResponse))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Not Found")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetAllCategoriesResponse>> ListAllCategories()
    {
        var result = await _mediator.Send(new GetAllCategoriesQuery());
        return Ok(result);
    }

    /// <summary>
    /// Get Category By ID
    /// </summary>
    /// <param name="getCategoryByIdQuery"></param>
    /// <returns>Category</returns>
    [HttpPut(Name = "GetCategoryById")]
    [Consumes("application/json")]
    [SwaggerOperation(Summary = "List All Categories")]
    [SwaggerResponse(StatusCodes.Status200OK,"Category Details", typeof(GetAllCategoriesResponse))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Not Found")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetAllCategoriesResponse>> GetCategoryById([FromBody] GetCategoryByIdQuery getCategoryByIdQuery)
    {
        var result = await _mediator.Send(getCategoryByIdQuery);
        if (result == null || result.Category == null  )
        {
            return NotFound();
        } else if (result.Success == true)
        {
            return Ok(result);
        } else
        {
            return StatusCode(500, result);
        }
    }
}
