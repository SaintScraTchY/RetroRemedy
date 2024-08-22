using Microsoft.EntityFrameworkCore;
using RetroRemedy.Core.Entities.Categories;
using RetroRemedy.Infrastructure.Common;

namespace RetroRemedy.Infrastructure.Repositories;

public class CategoryRepository(RetroContext dbContext):BaseRepository<Category>(dbContext),ICategoryRepository
{
    private readonly RetroContext _context = dbContext;

}