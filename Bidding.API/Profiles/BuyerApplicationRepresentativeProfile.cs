using AutoMapper;
using Bidding.API.Entities;
using Bidding.API.Models;

namespace Bidding.API.Profiles
{
    public class BuyerApplicationRepresentativeProfile : Profile
    {
        public BuyerApplicationRepresentativeProfile()
        {
            CreateMap<Representative, BuyerApplicationRepresentativeResponseModel>()
                .ForMember(dest => dest.Guid, opt => opt.MapFrom(src => src.Guid))

                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.IdentificationNumber, opt => opt.MapFrom(src => src.IdentificationNumber))
                .ForMember(dest => dest.AdressGuid, opt => opt.MapFrom(src => src.AddressGuid))
                .ForMember(dest => dest.NumberOfBoard, opt => opt.MapFrom(src => src.NumberOfBoard))
                .ForMember(dest => dest.PublicBiddingGuid, opt => opt.MapFrom(src => src.PublicBiddingGuid));



        }
    }
}
