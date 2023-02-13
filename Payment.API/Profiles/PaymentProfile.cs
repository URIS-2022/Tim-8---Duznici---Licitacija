using AutoMapper;
using Payment.API.Entities;
using Payment.API.Models.PaymentModel;
using Payment.API.Models.PaymentModels;

namespace Payment.API.Profiles;

public class PaymentProfile : Profile
{
    public PaymentProfile()
    {
        CreateMap<PaymentEntity, PaymentResponseModel>();
        CreateMap<PaymentRequestModel, PaymentEntity>();
        CreateMap<PaymentUpdateModel, PaymentEntity>()
            .ForMember(dest => dest.AccountNumber, opt => opt.Condition(src => src.AccountNumber != null))
            .ForMember(dest => dest.ReferenceNumber, opt => opt.Condition(src => src.ReferenceNumber != null))
            .ForMember(dest => dest.TotalAmount, opt => opt.Condition(src => src.TotalAmount != null))
            .ForMember(dest => dest.PaymentTitle, opt => opt.Condition(src => src.PaymentTitle != null))
            .ForMember(dest => dest.PaymentDate, opt => opt.Condition(src => src.PaymentDate != null));
    }
}
