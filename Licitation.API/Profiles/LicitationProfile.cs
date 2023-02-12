using AutoMapper;
using Licitation.API.Entities;
using Licitation.API.Models.Licitation;

namespace Licitation.API.Profiles;

public class LicitationProfile : Profile
{
    public LicitationProfile()
    {
        CreateMap<LicitationEntity, LicitationResponseModel>();
        CreateMap<LicitationRequestModel, LicitationEntity>();
        CreateMap<LicitationUpdateModel, LicitationEntity>()
            .ForMember(dest => dest.Stage, opt => opt.Condition(src => src.Stage != null))
            .ForMember(dest => dest.Date, opt => opt.Condition(src => src.Date != null))
            .ForMember(dest => dest.Year, opt => opt.Condition(src => src.Year != null))
            .ForMember(dest => dest.Constarint, opt => opt.Condition(src => src.Constarint != null))
            .ForMember(dest => dest.BidIncrement, opt => opt.Condition(src => src.BidIncrement != null))
            .ForMember(dest => dest.ApplicationDeadline, opt => opt.Condition(src => src.ApplicationDeadline != null))
            .ForMember(dest => dest.LandGuids, opt => opt.Condition(src => src.LandGuids != null)); // kako ovoooo
            //.ForMember(dest => dest.Role, opt => opt.Condition(src => src.Role.HasValue))
            //.ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role!.Value));
    }
}
