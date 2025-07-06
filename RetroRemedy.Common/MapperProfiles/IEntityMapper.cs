using RetroRemedy.Common.Contracts.GameContracts;
using RetroRemedy.Common.Contracts.PublisherContracts;
using RetroRemedy.Common.Contracts.TagContracts;
using RetroRemedy.Core.Entities.GameCategories;
using RetroRemedy.Core.Entities.LabelEntities;

namespace RetroRemedy.Common.MapperProfiles;

public interface IEntityMapper
{
    public  UpdateGameModel MapUpdateGameModel(Game game);
    public IList<GameViewModel> MapGameViewModels(IEnumerable<Game> games);
    public UpdateTagModel MapUpdateTagModel(Tag tag);
    public IEnumerable<TagViewModel> MapTagViewModels(IEnumerable<Tag> tags);
    public IEnumerable<PublisherViewModel> MapPublisherViewModels(IEnumerable<Publisher> publishers);
}