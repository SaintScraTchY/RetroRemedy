using Microsoft.EntityFrameworkCore;
using RetroRemedy.Core.Entities.GameTags;
using RetroRemedy.Infrastructure.Common;

namespace RetroRemedy.Infrastructure.Repositories;

public class GameTagRepository(DbContext dbContext):BaseRepository<GameTag>(dbContext),IGameTagRepository
{
    private readonly DbContext _context = dbContext;

}