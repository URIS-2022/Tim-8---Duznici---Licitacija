using Bidding.API.Entities;
using Bidding.API.Models;
using AutoMapper;

namespace Bidding.API.Profiles
{

    /// <summary>
    /// Mapping profile for  entities and their corresponding models.
    /// </summary>
    public class PublicBiddingLotProfile : Profile
    {
        public PublicBiddingLotProfile()
        {
            // Map a PublicBiddingLot entity to a PublicBiddingLotResponseModel
            CreateMap<PublicBiddingLot, PublicBiddingLotResponseModel>();

            // Map a PublicBiddingLot entity to a PublicBiddingLotNewResponseModel, with additional conditions
            CreateMap<PublicBiddingLot, PublicBiddingLotNewResponseModel>()
                .ForMember(dest => dest.Guid, opt => opt.MapFrom(src => src.Guid != Guid.Empty))
                .ForMember(dest=>dest.publicBiddingGuid,opt=>opt.MapFrom(src=>src.PublicBiddingGuid))
                
                .ForMember(dest => dest.lotGuid, opt => opt.MapFrom(src => src.LotGuid))
                .ForMember(dest => dest.LotNumber, opt => opt.MapFrom(src => src.LotNumber));

            // Map a PublicBiddingLotUpdateModel to a PublicBiddingLot entity, with additional conditions
            CreateMap<PublicBiddingLotUpdateModel, PublicBiddingLot>()
                
       .ForMember(dest => dest.LotGuid, opt => opt.Condition(src => src.LotGuid != Guid.Empty))
       .ForMember(dest => dest.PublicBiddingGuid, opt => opt.Condition(src => src.PublicBiddingGuid != Guid.Empty))
       .ForMember(dest => dest.LotNumber, opt => opt.Condition(src => src.LotNumber > 0));

            // Map a PublicBiddingLotRequestModel to a PublicBiddingLot entity, with additional conditions
            CreateMap<PublicBiddingLotRequestModel, PublicBiddingLot>()
                 .ForMember(dest => dest.LotGuid, opt => opt.Condition(src => src.LotGuid != Guid.Empty))
       .ForMember(dest => dest.PublicBiddingGuid, opt => opt.Condition(src => src.PublicBiddingGuid != Guid.Empty))
       .ForMember(dest => dest.LotNumber, opt => opt.Condition(src => src.LotNumber > 0));


        }
    }
}
