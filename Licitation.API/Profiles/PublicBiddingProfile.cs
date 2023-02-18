using AutoMapper;
using Licitation.API.Entities;
using Licitation.API.Models.Licitation;

namespace Licitation.API.Profiles;

/// <summary>
/// Represents a profile that contains information specific to a public biddings.
/// </summary>
public class PublicBiddingProfile : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PublicBiddingProfile"/> class.
    /// </summary>
    public PublicBiddingProfile()
    {
        CreateMap<PublicBidding, LicitationPublicBiddingLicitationResponseModel>()
            .ForMember(dest => dest.Guid, opt => opt.MapFrom(src => src.PublicBiddingGuid));

    }
}
