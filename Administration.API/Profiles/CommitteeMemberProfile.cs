﻿using Administration.API.Entities;
using Administration.API.Models;
using AutoMapper;

namespace Administration.API.Profiles;

public class CommitteeMemberProfile : Profile
{
    public CommitteeMemberProfile()
    {
        CreateMap<CommitteeMember, CommitteeMemberCommitteeGetResponseModel>()
            .ForMember(dest => dest.Guid, opt => opt.MapFrom(src => src.Member.Guid))
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Member.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Member.LastName))
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role));
        CreateMap<CommitteeMember, CommitteeMemberCommitteePatchResponseModel>()
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Member.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Member.LastName))
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role));

        CreateMap<CommitteeMember, CommitteeMemberMemberGetResponseModel>()
            .ForMember(dest => dest.Guid, opt => opt.MapFrom(src => src.Committee.Guid))
            .ForMember(dest => dest.DateAssembled, opt => opt.MapFrom(src => src.Committee.DateAssembled))
            .ForMember(dest => dest.MemberRole, opt => opt.MapFrom(src => src.Role));
        CreateMap<CommitteeMember, CommitteeMemberMemberPatchResponseModel>()
            .ForMember(dest => dest.DateAssembled, opt => opt.Condition(src => src.Committee?.DateAssembled != null))
            .ForMember(dest => dest.MemberRole, opt => opt.Condition(src => src.Role != null));
    }
}