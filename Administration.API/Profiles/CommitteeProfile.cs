using Administration.API.Entities;
using Administration.API.Models.Committee;
using AutoMapper;

namespace Administration.API.Profiles;

/// <summary>
/// AutoMapper profile for mapping between entities and response/request models for committees.
/// </summary>
public class CommitteeProfile : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CommitteeProfile"/> class and sets up mappings between
    /// <see cref="Committee"/> and its corresponding response/request models.
    /// </summary>
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