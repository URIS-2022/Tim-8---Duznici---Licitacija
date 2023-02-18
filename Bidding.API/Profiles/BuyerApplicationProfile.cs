using Bidding.API.Entities;
using Bidding.API.Models;
using AutoMapper;

namespace Bidding.API.Profiles
{
    /// <summary>
    /// Profile for mapping BuyerApplication entities to and from BiddingOffer response/request models.
    /// </summary>
    public class BuyerApplicationProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the  class.
        /// </summary>
        public BuyerApplicationProfile()
        {
            // Map BuyerApplication entity to BuyerApplication response model
            CreateMap<BuyerApplication, BuyerApplicationResponseModel>()
                .ForMember(dest => dest.representative, opt => opt.MapFrom(src => src.representative));
            /// <summary>
            /// Creates a mapping between the source type and destination type, which can be used by the AutoMapper library for object mapping.
            /// </summary>
            CreateMap<BuyerApplicationRequestModel, BuyerApplication>();

            /// <summary>
            /// Creates a mapping between the source type and destination type, which can be used by the AutoMapper library for object mapping.
            /// </summary>
            CreateMap<BuyerApplicationUpdateModel, BuyerApplication>()
           .ForMember(dest => dest.RepresentativeGuid, opt => opt.Condition(src => src.RepresentativeGuid != Guid.Empty))
           .ForMember(dest => dest.Amount, opt => opt.Condition(src => src.Amount.HasValue));
        }
    }
}
