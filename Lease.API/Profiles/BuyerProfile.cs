
using AutoMapper;
using Lease.API.Entities;
using Lease.API.Models;
using Lease.API.Models.Buyer;

namespace Lease.API.Profiles;

public class BuyerProfile : Profile
{
    public BuyerProfile()
    {
        CreateMap<Buyer, BuyerGetResponseModel>();
        CreateMap<Buyer, BuyerPostResponseModel>();
        CreateMap<Buyer, BuyerPatchResponseModel>();
        CreateMap<BuyerPostRequestModel, Buyer>();
        CreateMap<BuyerPatchRequestModel, Buyer>()
            .ForMember(dest => dest.RealisedArea, opt => opt.Condition(src => src.RealisedArea != null))
            .ForMember(dest => dest.PaymentGuid, opt => opt.Condition(src => src.PaymentGuid != null))
            .ForMember(dest => dest.Ban, opt => opt.Condition(src => src.Ban != null))
            .ForMember(dest => dest.StartDateOfBan, opt => opt.Condition(src => src.StartDateOfBan != null))
            .ForMember(dest => dest.BanDuration, opt => opt.Condition(src => src.BanDuration != null))
            .ForMember(dest => dest.BanEndDate, opt => opt.Condition(src => src.BanEndDate != null))
            .ForMember(dest => dest.BiddingGuid, opt => opt.Condition(src => src.BiddingGuid != null))
            .ForMember(dest => dest.PersonGuid, opt => opt.Condition(src => src.PersonGuid != null));



    }
}


