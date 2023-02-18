using AutoMapper;
using Payment.API.Entities;
using Payment.API.Models.PaymentWarrantModel;

namespace Payment.API.Profiles;

/// <summary>
/// AutoMapper profile for PaymentWarrant related classes.
/// </summary>
public class PaymentWarrantProfile : Profile
{
    /// <summary>
    /// Initializes a new instance of the PaymentWarrantPaymentProfile class.
    /// </summary>
    public PaymentWarrantProfile()
    {
        CreateMap<PaymentWarrant, PaymentWarrantResponseModel>();
        CreateMap<PaymentWarrantRequestModel, PaymentWarrant>();
        CreateMap<PaymentWarrantUpdateModel, PaymentWarrant>()
            //.ForMember(dest => dest.ReferenceNumber, opt => opt.Condition(src => src.ReferenceNumber != null))
            .ForMember(dest => dest.TotalAmount, opt => opt.Condition(src => src.TotalAmount != null))
            .ForMember(dest => dest.PayerGuid, opt => opt.Condition(src => src.PayerGuid != null))
            .ForMember(dest => dest.PublicBiddingGuid, opt => opt.Condition(src => src.PublicBiddingGuid != null));
    }
}
