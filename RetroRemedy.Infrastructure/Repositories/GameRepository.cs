using Microsoft.EntityFrameworkCore;
using RetroRemedy.Core.Entities.Games;
using RetroRemedy.Infrastructure.Common;

namespace RetroRemedy.Infrastructure.Repositories;

public class GameRepository(RetroContext context) : BaseRepository<Game>(context), IGameRepository
{
    private readonly RetroContext _context = context;
}