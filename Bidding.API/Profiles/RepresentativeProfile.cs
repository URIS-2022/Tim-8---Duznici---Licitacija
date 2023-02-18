using Bidding.API.Entities;
using Bidding.API.Models;
using AutoMapper;

namespace Bidding.API.Profiles
{
    public class RepresentativeProfile : Profile
    {
        public RepresentativeProfile()
        {
            CreateMap<Representative, RepresentativeResponseModel>()
                 .ForMember(dest => dest.address, opt => opt.MapFrom(src => src.address))
                .ForMember(dest => dest.BuyerApplications, opt => opt.MapFrom(src => src.BuyerApplications))
                .ForMember(dest => dest.publicBidding, opt => opt.MapFrom(src => src.publicBidding))
                .ForMember(dest => dest.AddressGuid, opt => opt.MapFrom(src => src.AddressGuid != Guid.Empty));



            CreateMap<RepresentativeRequestModel, Representative>()
                       .ForMember(dest => dest.FirstName, opt => opt.Condition(src => src.FirstName != null))
           .ForMember(dest => dest.LastName, opt => opt.Condition(src => src.LastName != null))
           .ForMember(dest => dest.IdentificationNumber, opt => opt.Condition(src => src.IdentificationNumber != null))
           .ForMember(dest => dest.AddressGuid, opt => opt.Condition(src => src.addressGuid != Guid.Empty))

           .ForMember(dest => dest.NumberOfBoard, opt => opt.Condition(src => src.NumberOfBoard != null))
           .ForMember(dest => dest.PublicBiddingGuid, opt => opt.Condition(src => src.PublicBiddingGuid != Guid.Empty));


            CreateMap<Representative, RepresentativeRequestModel>();


            CreateMap<RepresentativeUpdateModel, Representative>()
           .ForMember(dest => dest.FirstName, opt => opt.Condition(src => src.FirstName != null))
           .ForMember(dest => dest.LastName, opt => opt.Condition(src => src.LastName != null))
           .ForMember(dest => dest.IdentificationNumber, opt => opt.Condition(src => src.IdentificationNumber != null))
           .ForMember(dest => dest.AddressGuid, opt => opt.Condition(src => src.addressGuid != Guid.Empty))

           .ForMember(dest => dest.NumberOfBoard, opt => opt.Condition(src => src.NumberOfBoard.HasValue))
           .ForMember(dest => dest.PublicBiddingGuid, opt => opt.Condition(src => src.PublicBiddingGuid != Guid.Empty));

        }
    }
}
