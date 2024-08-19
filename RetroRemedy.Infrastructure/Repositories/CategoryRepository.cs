using Microsoft.EntityFrameworkCore;
using RetroRemedy.Core.Entities.Categories;
using RetroRemedy.Infrastructure.Common;

namespace RetroRemedy.Infrastructure.Repositories;

public class CategoryRepository(DbContext dbContext):BaseRepository<Category>(dbContext),ICategoryRepository
{
    private readonly DbContext _context = dbContext;

}