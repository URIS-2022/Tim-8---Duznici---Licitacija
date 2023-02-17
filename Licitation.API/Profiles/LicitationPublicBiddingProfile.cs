using AutoMapper;
using Licitation.API.Entities;
using Licitation.API.Models.LicitationPB;
using Licitation.API.Models.LicitationPBResponse;

namespace Licitation.API.Profiles;

public class LicitationPublicBiddingProfile : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PublicBidding"/> class and sets up mappings between
    /// <see cref="PublicBidding"/> and its corresponding response/request models.
    /// </summary>
    public LicitationPublicBiddingProfile()
    {
        CreateMap<PublicBiddingPostRequestModel, PublicBidding>()
        .ForMember(dest => dest.PublicBiddingGuid, opt => opt.MapFrom(src => src.PublicBiddingGuid));


        CreateMap<PublicBidding, LicitationPublicBiddingResponse>()
            .ForMember(dest => dest.PublicBiddingGuid, opt => opt.MapFrom(src => src.PublicBiddingGuid));

    }
}
