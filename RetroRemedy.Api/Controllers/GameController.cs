using Microsoft.AspNetCore.Mvc;
using RetroRemedy.Common.Contracts.GameContracts;
using System.Net.Mime;
using RetroRemedy.Core.Common;
using RetroRemedy.Services.IService;

namespace RetroRemedy.Api.Controllers;

/// <summary>
/// Handles operations related to game creation, updating, retrieval, and deletion.
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class GameController : ControllerBase
{
    private readonly IGameService _gameService;

    public GameController(IGameService gameService)
    {
        _gameService = gameService;
    }

    /// <summary>
    /// Creates a new game with the provided information.
    /// </summary>
    /// <param name="model">Game creation data.</param>
    /// <param name="userId">User ID of the creator.</param>
    /// <returns>Status of creation.</returns>
    [HttpPost]
    [Route("create")]
    [ProducesResponseType(typeof(void), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromForm] CreateGameModel model, [FromQuery] long userId)
    {
        var result = await _gameService.CreateGame(model, userId);
        return result.Match<IActionResult>(
            _ => CreatedAtAction(nameof(GetDetailById), new { id = model.Title }, null),
            error => Problem()
        );
    }

    /// <summary>
    /// Updates an existing game.
    /// </summary>
    /// <param name="model">Game update data.</param>
    /// <param name="userId">User ID of the editor.</param>
    /// <returns>Status of update.</returns>
    [HttpPut]
    [Route("update")]
    [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update([FromForm] UpdateGameModel model, [FromQuery] long userId)
    {
        var result = await _gameService.UpdateGame(model, userId);
        return result.Match<IActionResult>(
            _ => NoContent(),
            error => Problem()
        );
    }

    /// <summary>
    /// Deletes a game by its ID.
    /// </summary>
    /// <param name="id">ID of the game to delete.</param>
    /// <param name="userId">User ID performing the deletion.</param>
    /// <returns>Status of deletion.</returns>
    [HttpDelete("{id:long}")]
    [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete(long id, [FromQuery] long userId)
    {
        var result = await _gameService.RemoveGameBy(id, userId);
        return result.Match<IActionResult>(
            _ => NoContent(),
            error => Problem()
        );
    }

    /// <summary>
    /// Gets detailed information about a specific game.
    /// </summary>
    /// <param name="id">ID of the game.</param>
    /// <returns>Game details.</returns>
    [HttpGet("{id:long}")]
    [ProducesResponseType(typeof(UpdateGameModel), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetDetailById(long id)
    {
        var result = await _gameService.GetGameDetailBy(id);
        return result.Match<IActionResult>(
            game => Ok(game),
            error => Problem()
        );
    }

    /// <summary>
    /// Retrieves a paginated list of games for admin.
    /// </summary>
    /// <param name="model">Search parameters.</param>
    /// <returns>Paginated list of admin games.</returns>
    [HttpPost("admin-list")]
    [ProducesResponseType(typeof(PaginatedResult<GameViewModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAdminList([FromBody] SearchGameModel model)
    {
        var result = await _gameService.GetGameAdminListBy(model);
        return result.Match<IActionResult>(
            list => Ok(list),
            error => Problem()
        );
    }

    /// <summary>
    /// Retrieves a public-facing list of games.
    /// </summary>
    /// <param name="model">Search parameters.</param>
    /// <returns>Paginated list of games for public view.</returns>
    [HttpPost("list")]
    [ProducesResponseType(typeof(PaginatedResult<GameQueryViewModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetPublicList([FromBody] SearchGameModel model)
    {
        var result = await _gameService.GetGameListBy(model);
        return result.Match<IActionResult>(
            list => Ok(list),
            error => Problem()
        );
    }
}
