using Microsoft.AspNetCore.Mvc;
using RetroRemedy.Common.Contracts.PublisherContracts;
using ErrorOr;
using RetroRemedy.Core.Common;
using RetroRemedy.Services.IService;

namespace RetroRemedy.Api.Controllers;

/// <summary>
/// Manages game publishers and their metadata.
/// </summary>
[Route("api/publishers")]
public sealed class PublisherController(IPublisherService _publisherService) : ApiControllerBase
{
    /// <summary>
    /// Creates a new publisher entry.
    /// </summary>
    /// <param name="model">The details of the publisher to create.</param>
    /// <param name="userId">ID of the user creating the publisher.</param>
    /// <returns>Status of the creation process.</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromForm] CreatePublisherModel model, [FromQuery] long userId)
    {
        var result = await _publisherService.CreatePublisher(model, userId);
        return result.Match(
            _ => Created(),
            Problem);
    }

    /// <summary>
    /// Updates an existing publisher.
    /// </summary>
    /// <param name="model">The new details of the publisher.</param>
    /// <param name="userId">ID of the user performing the update.</param>
    /// <returns>Status of the update operation.</returns>
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update([FromForm] UpdatePublisherModel model, [FromQuery] long userId)
    {
        var result = await _publisherService.UpdatePublisher(model, userId);
        return result.Match(
            _ => NoContent(),
            Problem);
    }

    /// <summary>
    /// Deletes a publisher by ID.
    /// </summary>
    /// <param name="id">The ID of the publisher to remove.</param>
    /// <param name="userId">ID of the user requesting the deletion.</param>
    /// <returns>Status of the deletion.</returns>
    [HttpDelete("{id:long}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(long id, [FromQuery] long userId)
    {
        var result = await _publisherService.RemovePublisherBy(id, userId);
        return result.Match(
            _ => NoContent(),
            Problem);
    }

    /// <summary>
    /// Retrieves a publisher's editable details.
    /// </summary>
    /// <param name="id">The ID of the publisher to fetch.</param>
    /// <returns>The update model for the publisher.</returns>
    [HttpGet("{id:long}")]
    [ProducesResponseType(typeof(UpdatePublisherModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetDetail(long id)
    {
        var result = await _publisherService.GetPublisherDetailBy(id);
        return result.Match(
            Ok,
            Problem);
    }

    /// <summary>
    /// Gets a paginated list of publishers for admin view.
    /// </summary>
    /// <returns>A paginated list of publisher view models.</returns>
    [HttpGet("admin-list")]
    [ProducesResponseType(typeof(PaginatedResult<PublisherViewModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAdminList()
    {
        var result = await _publisherService.GetPublisherAdminListBy();
        return result.Match(
            Ok,
            Problem);
    }
    
    /// <summary>
    /// Gets a paginated list of publishers for admin view.
    /// </summary>
    /// <returns>A paginated list of publisher view models.</returns>
    [HttpOptions]
    [ProducesResponseType(typeof(IEnumerable<PublisherViewModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetSelectList()
    {
        var result = await _publisherService.GetAllPublishers();
        return result.Match(
            Ok,
            Problem);
    }
    
}
