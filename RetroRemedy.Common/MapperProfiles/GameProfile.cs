using AutoMapper;
using RetroRemedy.Common.Contracts.GameContracts;
using RetroRemedy.Core.Entities.Games;

namespace RetroRemedy.Common.MapperProfiles;

public class GameProfile : Profile
{
    public GameProfile()
    {
        CreateMap<Game, UpdateGameModel>();

        CreateMap<Game, GameViewModel>()
            .ForMember(dest => dest.Publisher, 
                opt => opt.MapFrom(src => src.Publisher.Name))
            .ForMember(dest => dest.CreatedBy, 
                opt => opt.MapFrom(src => src.CreatedBy.UserName))
            .ForMember(dest => dest.CreatedDateTime, 
                opt => opt.MapFrom(src => src.CreateDateTime.ToShortDateString()))
            .ForMember(dest => dest.UpdatedBy, 
                opt => opt.MapFrom(src => src.UpdatedBy.UserName ?? ""))
            .ForMember(dest => dest.UpdateDateTime, 
                opt => opt.MapFrom(src => src.UpdateDateTime.Value.ToShortDateString() ?? ""));
        
        
    }
}