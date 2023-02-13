using AutoMapper;
using Complaint.API.Models;

namespace Complaint.API.Profiles;

public class ComplaintProfile : Profile
{
    public ComplaintProfile()
    {
        CreateMap<Entities.Complaint, ComplaintGetResponseModel>();
        CreateMap<Entities.Complaint, ComplaintPostResponseModel>();
        CreateMap<Entities.Complaint, ComplaintPatchResponseModel>();
        CreateMap<ComplaintPostRequestModel, Entities.Complaint>();
        CreateMap<ComplaintPatchRequestModel, Entities.Complaint>()
            .ForMember(dest => dest.DateSubmitted, opt => opt.Condition(src => src.DateSubmitted != null))
            .ForMember(dest => dest.BuyerGuid, opt => opt.Condition(src => src.BuyerGuid != null))
            .ForMember(dest => dest.Reason, opt => opt.Condition(src => src.Reason != null))
            .ForMember(dest => dest.Rationale, opt => opt.Condition(src => src.Rationale != null))
            .ForMember(dest => dest.ResolutionDate, opt => opt.Condition(src => src.ResolutionDate != null))
            .ForMember(dest => dest.ResolutionCode, opt => opt.Condition(src => src.ResolutionCode != null))
            .ForMember(dest => dest.SubjectGuid, opt => opt.Condition(src => src.SubjectGuid != null))
            .ForMember(dest => dest.Action, opt => opt.Condition(src => src.Action.HasValue))
            .ForMember(dest => dest.Status, opt => opt.Condition(src => src.Status.HasValue))
            .ForMember(dest => dest.Type, opt => opt.Condition(src => src.Type.HasValue))
            .ForMember(dest => dest.Action, opt => opt.MapFrom(src => src.Action!.Value))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status!.Value))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type!.Value));
    }
}