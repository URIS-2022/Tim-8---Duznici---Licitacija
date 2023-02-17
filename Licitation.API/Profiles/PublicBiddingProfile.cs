using AutoMapper;
using Licitation.API.Entities;
using Licitation.API.Models.Licitation;

namespace Licitation.API.Profiles;

public class PublicBiddingProfile : Profile
{
    public PublicBiddingProfile()
    {
        CreateMap<PublicBidding, LicitationPublicBiddingLicitationResponseModel>()
            .ForMember(dest => dest.Guid, opt => opt.MapFrom(src => src.PublicBiddingGuid));

    }
}
