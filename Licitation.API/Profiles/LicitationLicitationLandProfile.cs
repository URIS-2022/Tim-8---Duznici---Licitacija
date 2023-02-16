using AutoMapper;
using Licitation.API.Entities;
using Licitation.API.Models.LicitationLands;

namespace Licitation.API.Profiles;

public class LicitationLicitationLandProfile : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LicitationLand"/> class and sets up mappings between
    /// <see cref="LicitationLand"/> and its corresponding response/request models.
    /// </summary>
    public LicitationLicitationLandProfile()
    {
        CreateMap<LicitationLandPostRequestModel, LicitationLand>()
        .ForMember(dest => dest.LandGuid, opt => opt.MapFrom(src => src.LandGuid));


        CreateMap<LicitationLand, LicitationLandResponse>()
            .ForMember(dest => dest.LandGuid, opt => opt.MapFrom(src => src.LandGuid));

    }
}
