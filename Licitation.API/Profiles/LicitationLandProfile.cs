using AutoMapper;
using Licitation.API.Entities;
using Licitation.API.Models.Licitation;

namespace Licitation.API.Profiles;

public class LicitationLandProfile : Profile
{
    public LicitationLandProfile()
    {
        CreateMap<LicitationLand, LicitationLandLicitationResponseModel>()
            .ForMember(dest => dest.Guid, opt => opt.MapFrom(src => src.LandGuid));

    }
}
