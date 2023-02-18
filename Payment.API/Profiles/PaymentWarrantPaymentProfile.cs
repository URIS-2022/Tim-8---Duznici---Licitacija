using AutoMapper;
using Payment.API.Entities;
using Payment.API.Models.PaymentWarrantModel;

namespace Payment.API.Profiles;

/// <summary>
/// AutoMapper profile for PaymentWarrant related classes.
/// </summary>
public class PaymentWarrantPaymentProfile : Profile
{
    /// <summary>
    /// Initializes a new instance of the PaymentWarrantPaymentProfile class.
    /// </summary>
    public PaymentWarrantPaymentProfile()
    {

        CreateMap<PaymentWarrant, PaymentWarrantPaymentResponseModel>()
                    .ForMember(dest => dest.Guid, opt => opt.MapFrom(src => src.Guid))
                    .ForMember(dest => dest.PayerGuid, opt => opt.MapFrom(src => src.PayerGuid))
                    .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src => src.TotalAmount))
                    .ForMember(dest => dest.PublicBiddingGuid, opt => opt.MapFrom(src => src.PublicBiddingGuid));
    }
}

