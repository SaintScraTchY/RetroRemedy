using Microsoft.EntityFrameworkCore;
using RetroRemedy.Core.Entities.LabelEntities;
using RetroRemedy.Infrastructure.Common;

namespace RetroRemedy.Infrastructure.Repositories;

public class GameTagRepository(RetroContext dbContext):BaseRepository<GameTag>(dbContext),IGameTagRepository
{
    private readonly RetroContext _context = dbContext;

}