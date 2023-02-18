using Bidding.API.Entities;
using Bidding.API.Models;
using AutoMapper;

namespace Bidding.API.Profiles
{
    public class PublicBiddingProfile : Profile
    {
        public PublicBiddingProfile()
        {
            CreateMap<PublicBidding, PublicBiddingResponseModel>()
            .ForMember(dest => dest.PublicBiddingLots, opt => opt.MapFrom(src => src.PublicBiddingLots))
            .ForMember(dest => dest.Addres, opt => opt.MapFrom(src => src.Address));
            CreateMap<PublicBiddingRequestModel, PublicBidding>();
            CreateMap<PublicBiddingUpdateModel, PublicBidding>()
    .ForMember(dest => dest.Date, opt => opt.Condition(src => src.Date != null))
    .ForMember(dest => dest.StartDate, opt => opt.Condition(src => src.StartDate != null))
    .ForMember(dest => dest.EndDate, opt => opt.Condition(src => src.EndDate != null))
    .ForMember(dest => dest.StartPricePerHectar, opt => opt.Condition(src => src.StartPricePerHectar != null))
    .ForMember(dest => dest.Expected, opt => opt.Condition(src => src.Expected != null))
    .ForMember(dest => dest.municipality, opt => opt.Condition(src => src.municipality != null))
    .ForMember(dest => dest.AuctionedPrice, opt => opt.Condition(src => src.AuctionedPrice != null))
    .ForMember(dest => dest.BestBuyerGuid, opt => opt.Condition(src => src.BestBuyerGuid !=null ))
    .ForMember(dest => dest.public_bidding_type, opt => opt.Condition(src => src.public_bidding_type != null))
    .ForMember(dest => dest.AddresGuid, opt => opt.Condition(src => src.AddressGuid !=null)) // ne valja
    .ForMember(dest => dest.LeasePeriod, opt => opt.Condition(src => src.LeasePeriod != null))
    .ForMember(dest => dest.DepositReplenishmentAmount, opt => opt.Condition(src => src.DepositReplenishmentAmount != null))
    .ForMember(dest => dest.Round, opt => opt.Condition(src => src.Round != null))
    .ForMember(dest => dest.biddingStatus, opt => opt.Condition(src => src.biddingStatus != null));
     /* .ForMember(dest => dest.municipality, opt => opt.MapFrom(src => src.municipality))
      .ForMember(dest => dest.public_bidding_type, opt => opt.MapFrom(src => src.public_bidding_type))
      .ForMember(dest => dest.biddingStatus, opt => opt.MapFrom(src => src.biddingStatus)); */







            CreateMap<PublicBiddingUpdateModel, PublicBidding>()
    .ForMember(dest => dest.Date, opt => opt.Condition(src => src.Date != null))
    .ForMember(dest => dest.StartDate, opt => opt.Condition(src => src.StartDate != null))
    .ForMember(dest => dest.EndDate, opt => opt.Condition(src => src.EndDate != null))
    .ForMember(dest => dest.StartPricePerHectar, opt => opt.Condition(src => src.StartPricePerHectar != null))
    .ForMember(dest => dest.Expected, opt => opt.Condition(src => src.Expected != null))
    .ForMember(dest => dest.municipality, opt => opt.Condition(src => src.municipality != null))
    .ForMember(dest => dest.AuctionedPrice, opt => opt.Condition(src => src.AuctionedPrice != null))
    .ForMember(dest => dest.BestBuyerGuid, opt => opt.Condition(src => src.BestBuyerGuid != Guid.Empty))
    .ForMember(dest => dest.public_bidding_type, opt => opt.Condition(src => src.public_bidding_type != null))
    .ForMember(dest => dest.AddresGuid, opt => opt.Condition(src => src.AddressGuid != Guid.Empty)) // ne valja
    .ForMember(dest => dest.LeasePeriod, opt => opt.Condition(src => src.LeasePeriod != null))
    .ForMember(dest => dest.DepositReplenishmentAmount, opt => opt.Condition(src => src.DepositReplenishmentAmount != null))
    .ForMember(dest => dest.Round, opt => opt.Condition(src => src.Round != Guid.Empty))
    .ForMember(dest => dest.biddingStatus, opt => opt.Condition(src => src.biddingStatus != null))
      .ForMember(dest => dest.municipality, opt => opt.MapFrom(src => src.municipality))
      .ForMember(dest => dest.public_bidding_type, opt => opt.MapFrom(src => src.public_bidding_type))
      .ForMember(dest => dest.biddingStatus, opt => opt.MapFrom(src => src.biddingStatus));
        }
    }
}
