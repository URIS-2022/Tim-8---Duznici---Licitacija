using Bidding.API.Entities;
using Bidding.API.Models;
using AutoMapper;

namespace Bidding.API.Profiles
{
    public class PublicBiddingLotProfile : Profile
    {
        public PublicBiddingLotProfile()
        {
            CreateMap<PublicBiddingLot, PublicBiddingLotResponseModel>()
                .ForMember(dest => dest.Guid, opt => opt.MapFrom(src => src.Guid))
                //   .ForMember(dest => dest.RepresentativeGuid, opt => opt.MapFrom(src => src.RepresentativeGuid))
                .ForMember(dest => dest.LotGuid, opt => opt.MapFrom(src => src.LotGuid))
                .ForMember(dest => dest.LotNumber, opt => opt.MapFrom(src => src.LotNumber));
            // CreateMap<PublicBiddingUpdateModel, PublicBidding>()
        }
    }
}
