using AutoMapper;
using Licitation.API.Entities;
using Licitation.API.Models.Licitation;

namespace Licitation.API.Profiles;
/// <summary>
/// Represents a profile that contains information specific to a lands of licitation.
/// </summary>
public class LicitationLandProfile : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LicitationLandProfile"/> class.
    /// </summary>
    public LicitationLandProfile()
    {
        CreateMap<LicitationLand, LicitationLandLicitationResponseModel>()
            .ForMember(dest => dest.Guid, opt => opt.MapFrom(src => src.LandGuid));

    }
}
