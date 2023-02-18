using AutoMapper;
using Bidding.API.Entities;
using Bidding.API.Models;

namespace Bidding.API.Profiles
{
    public class RepresentativePublicBiddingProfile : Profile
    {
        public RepresentativePublicBiddingProfile()
        {
            CreateMap<PublicBidding, RepresentativePublicBiddingResponseModel>()
                .ForMember(dest => dest.Guid, opt => opt.MapFrom(src => src.Guid))

                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
                .ForMember(dest => dest.StartPricePerHectar, opt => opt.MapFrom(src => src.StartPricePerHectar))
                .ForMember(dest => dest.Expected, opt => opt.MapFrom(src => src.Expected))
                .ForMember(dest => dest.municipality, opt => opt.MapFrom(src => src.municipality))
                .ForMember(dest => dest.AuctionedPrice, opt => opt.MapFrom(src => src.AuctionedPrice))
                .ForMember(dest => dest.BestBuyerGuid, opt => opt.MapFrom(src => src.BestBuyerGuid))
                .ForMember(dest => dest.public_bidding_type, opt => opt.MapFrom(src => src.public_bidding_type))
                .ForMember(dest => dest.AddresGuid, opt => opt.MapFrom(src => src.AddresGuid))
                .ForMember(dest => dest.LeasePeriod, opt => opt.MapFrom(src => src.LeasePeriod))
                .ForMember(dest => dest.DepositReplenishmentAmount, opt => opt.MapFrom(src => src.DepositReplenishmentAmount))
                .ForMember(dest => dest.Round, opt => opt.MapFrom(src => src.Round))
                .ForMember(dest => dest.biddingStatus, opt => opt.MapFrom(src => src.biddingStatus));


        }
    }
}
