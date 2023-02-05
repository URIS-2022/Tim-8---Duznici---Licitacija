using Auth.API.Entities;
using Auth.API.Models;
using AutoMapper;

namespace Auth.API.Profiles
{
    public class SystemUserModels : Profile
    {
        public SystemUserModels()
        {
            CreateMap<SystemUser, SystemUserResponseModel>();
            CreateMap<SystemUserRequestModel, SystemUser>();
        }
    }
}
