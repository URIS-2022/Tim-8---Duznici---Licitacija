using AutoMapper;
using Landlot.API.Entities;
using Landlot.API.Models;

namespace Landlot.API.Profiles
{
    public class LotProfile : Profile
    {
        public LotProfile() 
        {
            CreateMap<Lot, LotGetResponseModel>();
            CreateMap<Lot, LotPostResponseModel>();
            CreateMap<Lot, LotPatchResponseModel>();
            CreateMap<LotPostRequestModel, Lot>();
            CreateMap<LotPatchRequestModel, Lot>()
            .ForMember(dest => dest.LotUser, opt => opt.Condition(src => src.LotUser != null))
            .ForMember(dest => dest.LotNumber, opt => opt.Condition(src => src.LotNumber != null))
            .ForMember(dest => dest.LotArea, opt => opt.Condition(src => src.LotArea != null));


        }
    }
}
