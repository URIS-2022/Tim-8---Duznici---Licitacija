using Bidding.API.Entities;
using Bidding.API.Models;
using AutoMapper;

namespace Bidding.API.Profiles
{

    /// <summary>
    /// Profile for mapping BiddingOffer entities to and from BiddingOffer response/request models.
    /// </summary>
    public class BiddingOfferProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the  class.
        /// </summary>
        public BiddingOfferProfile()
        {
            // Map BiddingOffer entity to BiddingOffer response model
            CreateMap<BiddingOffer, BiddingOfferResponseModel>();

            // Map BiddingOffer request model to BiddingOffer entity
            CreateMap<BiddingOfferRequestModel, BiddingOffer>();

            // Map BiddingOffer update model to BiddingOffer entity
            CreateMap<BiddingOfferUpdateModel, BiddingOffer>()
                .ForMember(dest => dest.RepresentativeGuid, opt => opt.Condition(src => src.RepresentativeGuid != Guid.Empty))
                .ForMember(dest => dest.PublicBiddingGuid, opt => opt.Condition(src => src.PublicBiddingGuid != Guid.Empty))
                .ForMember(dest => dest.Date, opt => opt.Condition(src => src.Date.HasValue))
                .ForMember(dest => dest.Offer, opt => opt.Condition(src => src.Offer.HasValue))
                .ForMember(dest => dest.BuyerGuid, opt => opt.Condition(src => src.BuyerGuid != Guid.Empty));
        }
    }
}
