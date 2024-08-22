using RetroRemedy.Core.Entities.UploadMedias;
using RetroRemedy.Infrastructure.Common;

namespace RetroRemedy.Infrastructure.Repositories;

public class UploadFileRepository(RetroContext context) : BaseRepository<UploadFile>(context),IUploadFileRepository
{
    private readonly RetroContext _context = context;
}