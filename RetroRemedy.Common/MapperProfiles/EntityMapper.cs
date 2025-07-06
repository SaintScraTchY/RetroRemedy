using RetroRemedy.Common.Contracts.GameContracts;
using RetroRemedy.Common.Contracts.TagContracts;
using RetroRemedy.Core.Entities.GameCategories;
using RetroRemedy.Core.Entities.LabelEntities;
using Riok.Mapperly.Abstractions;

namespace RetroRemedy.Common.MapperProfiles;

[Mapper]
public partial class EntityMapper : IEntityMapper
{
    public partial UpdateGameModel MapUpdateGameModel(Game game);
    public partial IList<GameViewModel> MapGameViewModels(IEnumerable<Game> games);
    public partial UpdateTagModel MapUpdateTagModel(Tag tag);
    public partial IEnumerable<TagViewModel> MapTagViewModels(IEnumerable<Tag> tags);
}