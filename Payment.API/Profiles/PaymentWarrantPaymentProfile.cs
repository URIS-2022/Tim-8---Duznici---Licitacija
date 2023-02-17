using AutoMapper;
using Payment.API.Entities;
using Payment.API.Models.PaymentWarrantModel;

namespace Payment.API.Profiles;

public class PaymentWarrantPaymentProfile : Profile
{
    public PaymentWarrantPaymentProfile()
    {

        CreateMap<PaymentWarrant, PaymentWarrantPaymentResponseModel>()
                    .ForMember(dest => dest.Guid, opt => opt.MapFrom(src => src.Guid))
                    .ForMember(dest => dest.PayerGuid, opt => opt.MapFrom(src => src.PayerGuid))
                    .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src => src.TotalAmount))
                    .ForMember(dest => dest.PublicBiddingGuid, opt => opt.MapFrom(src => src.PublicBiddingGuid));
    }
}

