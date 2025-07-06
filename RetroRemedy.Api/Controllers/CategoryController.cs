using Microsoft.AspNetCore.Mvc;
using RetroRemedy.Common.Contracts.CategoryContracts;
using System.Net.Mime;
using RetroRemedy.Core.Common;
using RetroRemedy.Services.IService;

namespace RetroRemedy.Api.Controllers;

/// <summary>
/// Handles operations related to category creation, updating, listing, and deletion.
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    /// <summary>
    /// Creates a new category with the provided data.
    /// </summary>
    /// <param name="model">Category creation model.</param>
    /// <param name="userId">User ID of the creator.</param>
    /// <returns>Status of creation.</returns>
    [HttpPost("create")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromForm] CreateCategoryModel model, [FromQuery] long userId)
    {
        var result = await _categoryService.CreateCategory(model, userId);
        return result.Match<IActionResult>(
            _ => CreatedAtAction(nameof(GetDetailById), new { id = model.Name }, null),
            error => Problem()
        );
    }

    /// <summary>
    /// Updates an existing category.
    /// </summary>
    /// <param name="model">Updated category data.</param>
    /// <param name="userId">User ID performing the update.</param>
    /// <returns>Status of update.</returns>
    [HttpPut("update")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update([FromForm] UpdateCategoryModel model, [FromQuery] long userId)
    {
        var result = await _categoryService.UpdateCategory(model, userId);
        return result.Match<IActionResult>(
            _ => NoContent(),
            error => Problem()
        );
    }

    /// <summary>
    /// Deletes a category by ID.
    /// </summary>
    /// <param name="id">Category ID to delete.</param>
    /// <param name="userId">User ID requesting deletion.</param>
    /// <returns>Status of deletion.</returns>
    [HttpDelete("{id:long}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete(long id, [FromQuery] long userId)
    {
        var result = await _categoryService.RemoveCategoryBy(id, userId);
        return result.Match<IActionResult>(
            _ => NoContent(),
            error => Problem()
        );
    }

    /// <summary>
    /// Retrieves the details of a specific category.
    /// </summary>
    /// <param name="id">Category ID.</param>
    /// <returns>Category details.</returns>
    [HttpGet("{id:long}")]
    [ProducesResponseType(typeof(UpdateCategoryModel), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetDetailById(long id)
    {
        var result = await _categoryService.GetCategoryDetailBy(id);
        return result.Match<IActionResult>(
            model => Ok(model),
            error => Problem()
        );
    }

    /// <summary>
    /// Retrieves a paginated list of categories for admin view.
    /// </summary>
    /// <param name="model">Search parameters.</param>
    /// <returns>Paginated list of categories.</returns>
    [HttpPost("admin-list")]
    [ProducesResponseType(typeof(PaginatedResult<CategoryViewModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAdminList([FromBody] SearchCategoryModel model)
    {
        var result = await _categoryService.GetCategoryAdminListBy(model);
        return result.Match<IActionResult>(
            list => Ok(list),
            error => Problem()
        );
    }

    /// <summary>
    /// Retrieves a list of categories for public view.
    /// </summary>
    /// <returns>List of categories.</returns>
    [HttpGet("list")]
    [ProducesResponseType(typeof(PaginatedResult<QueryCategoryModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetPublicList()
    {
        var result = await _categoryService.GetCategoryList();
        return result.Match<IActionResult>(
            list => Ok(list),
            error => Problem()
        );
    }
}
