using Administration.API.Entities;
using Administration.API.Models;
using AutoMapper;

namespace Administration.API.Profiles;

public class CommitteeProfile : Profile
{
    public CommitteeProfile()
    {
        CreateMap<Committee, CommitteeGetResponseModel>()
            .ForMember(dest => dest.CommitteeMembers, opt => opt.MapFrom(src => src.CommitteeMembers));
        CreateMap<CommitteeMember, CommitteeMemberCommitteeGetResponseModel>()
            .ForMember(dest => dest.Guid, opt => opt.MapFrom(src => src.Member.Guid))
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Member.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Member.LastName))
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role));
        CreateMap<Committee, CommitteePostResponseModel>();
        CreateMap<Committee, CommitteePatchResponseModel>();
        CreateMap<CommitteePostRequestModel, Committee>();
        CreateMap<CommitteePatchRequestModel, Committee>();
    }
}