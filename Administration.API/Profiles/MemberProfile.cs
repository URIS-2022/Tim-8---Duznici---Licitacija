using Administration.API.Entities;
using Administration.API.Models;
using AutoMapper;

namespace Administration.API.Profiles;

public class MemberProfile : Profile
{
    public MemberProfile()
    {
        CreateMap<Member, MemberGetResponseModel>()
            .ForMember(dest => dest.MemberCommittees, opt => opt.MapFrom(src => src.CommitteeMembers));
        CreateMap<Member, MemberPostResponseModel>()
            .ForMember(dest => dest.MemberCommittees, opt => opt.MapFrom(src => src.CommitteeMembers));
        CreateMap<Member, MemberPatchResponseModel>()
            .ForMember(dest => dest.MemberCommittees, opt => opt.MapFrom(src => src.CommitteeMembers));
        CreateMap<MemberPostRequestModel, Member>();
        CreateMap<MemberPatchRequestModel, Member>()
            .ForMember(dest => dest.FirstName, opt => opt.Condition(src => src.FirstName != null))
            .ForMember(dest => dest.LastName, opt => opt.Condition(src => src.LastName != null));
    }
}