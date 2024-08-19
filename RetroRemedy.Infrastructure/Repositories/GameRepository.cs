using Microsoft.EntityFrameworkCore;
using RetroRemedy.Core.Entities.Games;
using RetroRemedy.Infrastructure.Common;

namespace RetroRemedy.Infrastructure.Repositories;

public class GameRepository(DbContext context) : BaseRepository<Game>(context), IGameRepository
{
    private readonly DbContext _context = context;
}