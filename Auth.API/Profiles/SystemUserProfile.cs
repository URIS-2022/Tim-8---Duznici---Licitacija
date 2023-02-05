using Auth.API.Entities;
using Auth.API.Models;
using AutoMapper;

namespace Auth.API.Profiles;

public class SystemUserProfile : Profile
{
    public SystemUserProfile()
    {
        CreateMap<SystemUser, SystemUserResponseModel>();
        CreateMap<SystemUserRequestModel, SystemUser>();
        CreateMap<SystemUserUpdateModel, SystemUser>()
            .ForMember(dest => dest.FirstName, opt => opt.Condition(src => src.FirstName != null))
            .ForMember(dest => dest.LastName, opt => opt.Condition(src => src.LastName != null))
            .ForMember(dest => dest.Username, opt => opt.Condition(src => src.Username != null))
            .ForMember(dest => dest.Password, opt => opt.Condition(src => src.Password != null))
            .ForMember(dest => dest.Role, opt => opt.Condition(src => src.Role.HasValue))
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role!.Value));
    }
}
