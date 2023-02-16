using Bidding.API.Entities;
using Bidding.API.Models;
using AutoMapper;

namespace Bidding.API.Profiles
{
    public class PublicBiddingLotProfile : Profile
    {
        public PublicBiddingLotProfile()
        {

            CreateMap<PublicBiddingLot, PublicBiddingLotResponseModel>();
            /*
                .ForMember(dest => dest.Guid, opt => opt.MapFrom(src => src.Guid != Guid.Empty))
                //   .ForMember(dest => dest.RepresentativeGuid, opt => opt.MapFrom(src => src.RepresentativeGuid))
                .ForMember(dest => dest.LotGuid, opt => opt.MapFrom(src => src.LotGuid != Guid.Empty))
                .ForMember(dest => dest.LotNumber, opt => opt.MapFrom(src => src.LotNumber));
            // CreateMap<PublicBiddingUpdateModel, PublicBidding>()

            */
            CreateMap<PublicBiddingLot, PublicBiddingLotNewResponseModel>()
                .ForMember(dest => dest.Guid, opt => opt.MapFrom(src => src.Guid != Guid.Empty))
                .ForMember(dest=>dest.publicBiddingGuid,opt=>opt.MapFrom(src=>src.PublicBiddingGuid))
                //   .ForMember(dest => dest.RepresentativeGuid, opt => opt.MapFrom(src => src.RepresentativeGuid))
                .ForMember(dest => dest.lotGuid, opt => opt.MapFrom(src => src.LotGuid))
                .ForMember(dest => dest.LotNumber, opt => opt.MapFrom(src => src.LotNumber));

            CreateMap<PublicBiddingLotUpdateModel, PublicBiddingLot>()
                // .ForMember(dest => dest.Guid, opt => opt.Ignore())
       .ForMember(dest => dest.LotGuid, opt => opt.Condition(src => src.LotGuid != Guid.Empty))
       .ForMember(dest => dest.PublicBiddingGuid, opt => opt.Condition(src => src.PublicBiddingGuid != Guid.Empty))
       .ForMember(dest => dest.LotNumber, opt => opt.Condition(src => src.LotNumber > 0));

            CreateMap<PublicBiddingLotRequestModel, PublicBiddingLot>()
                 .ForMember(dest => dest.LotGuid, opt => opt.Condition(src => src.LotGuid != Guid.Empty))
       .ForMember(dest => dest.PublicBiddingGuid, opt => opt.Condition(src => src.PublicBiddingGuid != Guid.Empty))
       .ForMember(dest => dest.LotNumber, opt => opt.Condition(src => src.LotNumber > 0));


        }
    }
}
