using AutoMapper;
using Licitation.API.Entities;
using Licitation.API.Models.Licitation;

namespace Licitation.API.Profiles;

public class LicitationProfile : Profile
{
    public LicitationProfile()
    {
        CreateMap<Entities.Licitation, LicitationResponseModel>();
        CreateMap<LicitationRequestModel, Entities.Licitation>();
        CreateMap<LicitationUpdateModel, Entities.Licitation>()
            .ForMember(dest => dest.Stage, opt => opt.Condition(src => src.Stage != null))
            .ForMember(dest => dest.Date, opt => opt.Condition(src => src.Date != null))
            .ForMember(dest => dest.Year, opt => opt.Condition(src => src.Year != null))
            .ForMember(dest => dest.Constarint, opt => opt.Condition(src => src.Constarint != null))
            .ForMember(dest => dest.BidIncrement, opt => opt.Condition(src => src.BidIncrement != null))
            .ForMember(dest => dest.ApplicationDeadline, opt => opt.Condition(src => src.ApplicationDeadline != null));
            //.ForMember(dest => dest.LandGuids, opt => opt.Condition(src => src.LandGuids != Guid.Empty)); // kako ovoooo
    }
}
