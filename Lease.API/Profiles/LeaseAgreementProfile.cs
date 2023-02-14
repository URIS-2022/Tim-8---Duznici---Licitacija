using Lease.API.Entities;
using Lease.API.Models;
using AutoMapper;

namespace Lease.API.Profiles;

public class LeaseAgreementProfile : Profile
{
    public LeaseAgreementProfile()
    {
        CreateMap<LeaseAgreement, LeaseAgreementResponseModel>();
        CreateMap<LeaseAgreementRequestModel, LeaseAgreement>();
        CreateMap<LeaseAgreementUpdateModel, LeaseAgreement>()
            .ForMember(dest => dest.GuaranteeType, opt => opt.Condition(src => src.GuaranteeType != null))
            .ForMember(dest => dest.ReferenceNumber, opt => opt.Condition(src => src.ReferenceNumber != null))
            .ForMember(dest => dest.DateRecording, opt => opt.Condition(src => src.DateRecording != null))
            .ForMember(dest => dest.MinisterGuid, opt => opt.Condition(src => src != null))
            .ForMember(dest => dest.PlaceOfSigning, opt => opt.Condition(src => src.PlaceOfSigning != null))
            .ForMember(dest => dest.DateOfSigning, opt => opt.MapFrom(src => src.DateOfSigning != null))
            .ForMember(dest => dest.BiddingGuid, opt => opt.Condition(src => src.PublicBiddingGuid != null))
            .ForMember(dest => dest.PersonGuid, opt => opt.Condition(src => src.PersonGuid != null))
            .ForMember(dest => dest.DocumentStatus, opt => opt.Condition(src => src.DocumentStatus != null))
            .ForMember(dest => dest.DueDate, opt => opt.Condition(src => src.DueDate != null));


    }
}
