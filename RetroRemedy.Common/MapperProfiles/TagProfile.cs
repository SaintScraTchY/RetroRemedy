using AutoMapper;
using RetroRemedy.Common.Contracts.TagContracts;
using RetroRemedy.Core.Entities.Tags;

namespace RetroRemedy.Common.MapperProfiles;

public class TagProfile : Profile
{
    public TagProfile()
    {
        CreateMap<Tag, UpdateTagModel>();
        
        CreateMap<Tag,TagViewModel>()
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