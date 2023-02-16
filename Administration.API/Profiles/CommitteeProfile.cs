using Administration.API.Entities;
using Administration.API.Models.Committee;
using AutoMapper;

namespace Administration.API.Profiles;

public class CommitteeProfile : Profile
{
    public CommitteeProfile()
    {
        CreateMap<Committee, CommitteeGetResponseModel>()
            .ForMember(dest => dest.CommitteeMembers, opt => opt.MapFrom(src => src.CommitteeMembers));
        CreateMap<Committee, CommitteePostResponseModel>()
            .ForMember(dest => dest.CommitteeMembers, opt => opt.MapFrom(src => src.CommitteeMembers));
        CreateMap<Committee, CommitteePatchResponseModel>()
            .ForMember(dest => dest.CommitteeMembers, opt => opt.MapFrom(src => src.CommitteeMembers));
        CreateMap<CommitteePostRequestModel, Committee>();
        CreateMap<CommitteePatchRequestModel, Committee>();
    }
}