using Administration.API.Entities;
using Administration.API.Models.Member;
using AutoMapper;

namespace Administration.API.Profiles;

/// <summary>
/// AutoMapper profile for mapping between entities and response/request models for member.
/// </summary>
public class MemberProfile : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Member"/> class and sets up mappings between
    /// <see cref="Member"/> and its corresponding response/request models.
    /// </summary>
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