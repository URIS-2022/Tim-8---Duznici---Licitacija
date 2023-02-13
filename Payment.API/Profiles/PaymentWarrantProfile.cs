using AutoMapper;
using Payment.API.Entities;
using Payment.API.Models.PaymentWarrantModel;

namespace Payment.API.Profiles;

public class PaymentWarrantProfile : Profile
{
    public PaymentWarrantProfile()
    {
        CreateMap<PaymentWarrant, PaymentWarrantResponseModel>();
        CreateMap<PaymentWarrantRequestModel, PaymentWarrant>();
        CreateMap<PaymentWarrantUpdateModel, PaymentWarrant>()
            .ForMember(dest => dest.ReferenceNumber, opt => opt.Condition(src => src.ReferenceNumber != null))
            .ForMember(dest => dest.TotalAmount, opt => opt.Condition(src => src.TotalAmount != null));
    }
}
