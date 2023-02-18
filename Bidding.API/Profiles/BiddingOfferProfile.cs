using Bidding.API.Entities;
using Bidding.API.Models;
using AutoMapper;

namespace Bidding.API.Profiles
{
    public class BiddingOfferProfile : Profile
    {
        public BiddingOfferProfile()
        {
            CreateMap<BiddingOffer, BiddingOfferResponseModel>();
            CreateMap<BiddingOfferRequestModel, BiddingOffer>();


            CreateMap<BiddingOfferUpdateModel, BiddingOffer>()
                .ForMember(dest => dest.RepresentativeGuid, opt => opt.Condition(src => src.RepresentativeGuid != Guid.Empty))
                .ForMember(dest => dest.PublicBiddingGuid, opt => opt.Condition(src => src.PublicBiddingGuid != Guid.Empty))
                .ForMember(dest => dest.Date, opt => opt.Condition(src => src.Date.HasValue))
                .ForMember(dest => dest.Offer, opt => opt.Condition(src => src.Offer.HasValue))
                .ForMember(dest => dest.BuyerGuid, opt => opt.Condition(src => src.BuyerGuid != Guid.Empty));
        }
    }
}
