using Bidding.API.Entities;
using Bidding.API.Models;
using AutoMapper;

namespace Bidding.API.Profiles
{
    public class RepresentativeProfile : Profile
    {
        public RepresentativeProfile()
        {
            CreateMap<Representative, RepresentativeResponseModel>();
            CreateMap<RepresentativeRequestModel, Representative>();
            CreateMap<RepresentativeUpdateModel, Representative>()
           .ForMember(dest => dest.FirstName, opt => opt.Condition(src => src.FirstName != null))
           .ForMember(dest => dest.LastName, opt => opt.Condition(src => src.LastName != null))
           .ForMember(dest => dest.IdentificationNumber, opt => opt.Condition(src => src.IdentificationNumber != null))
           .ForMember(dest => dest.address, opt => opt.Condition(src => src.address != null))
           .ForMember(dest => dest.NumberOfBoard, opt => opt.Condition(src => src.NumberOfBoard.HasValue))
           .ForMember(dest => dest.PublicBiddingGuid, opt => opt.Condition(src => src.PublicBidding != Guid.Empty));
           //.ForMember(dest => dest.BuyerRepresentatives, opt => opt.Condition(src => src.BuyerRepresentatives != null))
        }
    }
}
