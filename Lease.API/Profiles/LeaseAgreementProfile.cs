using Lease.API.Entities;
using AutoMapper;
using Lease.API.Models.LeaseAgreementModels;
using Lease.API.Models;

namespace Lease.API.Profiles;

public class LeaseAgreementProfile : Profile
{
    public LeaseAgreementProfile()
    {
        CreateMap<LeaseAgreement, LeaseAgreementGetResponseModel>();
        CreateMap<LeaseAgreement, LeaseAgreementPostResponseModel>();
        CreateMap<LeaseAgreement, LeaseAgreementPatchResponseModel>();
        CreateMap<LeaseAgreementPostRequestModel, LeaseAgreement>();
        CreateMap<LeaseAgreementPatchRequestModel, LeaseAgreement>()
            .ForMember(dest => dest.GuaranteeType, opt => opt.Condition(src => src.GuaranteeType != null))
            .ForMember(dest => dest.ReferenceNumber, opt => opt.Condition(src => src.ReferenceNumber != null))
            .ForMember(dest => dest.DateRecording, opt => opt.Condition(src => src.DateRecording != null))
            .ForMember(dest => dest.MinisterGuid, opt => opt.Condition(src => src.MinisterGuid != null))
            .ForMember(dest => dest.PlaceOfSigning, opt => opt.Condition(src => src.PlaceOfSigning != null))
            .ForMember(dest => dest.DateOfSigning, opt => opt.Condition(src => src.DateOfSigning != null))
            .ForMember(dest => dest.BiddingGuid, opt => opt.Condition(src => src.BiddingGuid != null))
            .ForMember(dest => dest.PersonGuid, opt => opt.Condition(src => src.PersonGuid != null))
            .ForMember(dest => dest.DocumentStatus, opt => opt.Condition(src => src.DocumentStatus != null))
            .ForMember(dest => dest.DueDateGuid, opt => opt.Condition(src => src.DueDateGuid != null));


    }
}
