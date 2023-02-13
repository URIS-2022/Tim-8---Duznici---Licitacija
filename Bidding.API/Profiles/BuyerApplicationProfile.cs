using Bidding.API.Entities;
using Bidding.API.Models;
using AutoMapper;

namespace Bidding.API.Profiles
{
    public class BuyerApplicationProfile : Profile
    {
        public BuyerApplicationProfile()
        {
            CreateMap<BuyerApplication, BuyerApplicationResponseModel>();
            CreateMap<BuyerApplicationRequestModel, BuyerApplication>();
            CreateMap<BuyerApplicationUpdateModel, BuyerApplication>()
           .ForMember(dest => dest.RepresentativeGuid, opt => opt.Condition(src => src.RepresentativeGuid != Guid.Empty))
           .ForMember(dest => dest.Amount, opt => opt.Condition(src => src.Amount.HasValue));
        }
    }
}
