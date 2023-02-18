using AutoMapper;
using Bidding.API.Entities;
using Bidding.API.Models;

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

            CreateMap<BuyerApplication, BuyerApplicationResponseModel>()
                .ForMember(dest => dest.representative, opt => opt.MapFrom(src => src.representative));

            CreateMap<BuyerApplicationRequestModel, BuyerApplication>();


            CreateMap<BuyerApplicationUpdateModel, BuyerApplication>()
           .ForMember(dest => dest.RepresentativeGuid, opt => opt.Condition(src => src.RepresentativeGuid != Guid.Empty))
           .ForMember(dest => dest.Amount, opt => opt.Condition(src => src.Amount.HasValue));
        }
    }
}
