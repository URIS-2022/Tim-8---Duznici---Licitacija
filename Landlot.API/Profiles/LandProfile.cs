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
            .ForMember(dest => dest.RealEstateNumber, opt => opt.Condition(src => src.RealEstateNumber != null))
            .ForMember(dest => dest.Municipality, opt => opt.MapFrom(src => src.Municipality!.Value))
            .ForMember(dest => dest.Culture, opt => opt.MapFrom(src => src.Culture!.Value))
            .ForMember(dest => dest.LandClass, opt => opt.MapFrom(src => src.LandClass!.Value))
            .ForMember(dest => dest.Processing, opt => opt.MapFrom(src => src.Processing!.Value))
            .ForMember(dest => dest.Zone, opt => opt.MapFrom(src => src.Zone!.Value))
            .ForMember(dest => dest.Property, opt => opt.MapFrom(src => src.Property!.Value))
            .ForMember(dest => dest.Drainage, opt => opt.MapFrom(src => src.Drainage!.Value));
        }
    }
}
