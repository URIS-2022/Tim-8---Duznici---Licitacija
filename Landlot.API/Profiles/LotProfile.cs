using AutoMapper;
using Landlot.API.Entities;
using Landlot.API.Models;

namespace Landlot.API.Profiles
{
    /// <summary>
    /// Represents a profile that contains information specific to a lot.
    /// </summary>
    public class LotProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LotProfile"/> class.
        /// </summary>
        public LotProfile()
        {
            CreateMap<Lot, LotGetResponseModel>();
            CreateMap<Lot, LotPostResponseModel>();
            CreateMap<Lot, LotPatchResponseModel>();
            CreateMap<LotPostRequestModel, Lot>();
            CreateMap<LotPatchRequestModel, Lot>()
            .ForMember(dest => dest.LandGuid, opt => opt.Condition(src => src.LandGuid != null))
            .ForMember(dest => dest.LotUser, opt => opt.Condition(src => src.LotUser != null))
            .ForMember(dest => dest.LotNumber, opt => opt.Condition(src => src.LotNumber != null))
            .ForMember(dest => dest.LotArea, opt => opt.Condition(src => src.LotArea != null))
            .ForMember(dest => dest.CultureState, opt => opt.MapFrom(src => src.CultureState!.Value))
            .ForMember(dest => dest.ClassState, opt => opt.MapFrom(src => src.ClassState!.Value))
            .ForMember(dest => dest.ProcessingState, opt => opt.MapFrom(src => src.ProcessingState!.Value))
            .ForMember(dest => dest.ProtectedZoneState, opt => opt.MapFrom(src => src.ProtectedZoneState!.Value))
            .ForMember(dest => dest.DrainageState, opt => opt.MapFrom(src => src.DrainageState!.Value));


        }
    }
}
