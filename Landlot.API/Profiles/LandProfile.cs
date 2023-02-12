using AutoMapper;
using Landlot.API.Entities;
using Landlot.API.Models;

namespace Landlot.API.Profiles
{
    public class LandProfile : Profile
    {
        public LandProfile() 
        {
            CreateMap<Land, LandGetResponseModel>();
            CreateMap<Land, LandPostResponseModel>();
            CreateMap<Land, LandPatchResponseModel>();
            CreateMap<LandPostRequestModel, Land>();
            CreateMap<LandPatchRequestModel, Land>()
            .ForMember(dest => dest.TotalArea, opt => opt.Condition(src => src.TotalArea != null))
            .ForMember(dest => dest.Municipality, opt => opt.Condition(src => src.Municipality != null))
            .ForMember(dest => dest.RealEstateNumber, opt => opt.Condition(src => src.RealEstateNumber != null));
        }
    }
}
