using AutoMapper;
using Landlot.API.Entities;
using Landlot.API.Models;

namespace Landlot.API.Profiles
{
    public class LandProfile : Profile
    {
        public LandProfile() 
        {
            CreateMap<Land, LandModel>();
            CreateMap<LandCreationModel, Land>();
            CreateMap<LandUpdateModel, Land>();

        }
    }
}
