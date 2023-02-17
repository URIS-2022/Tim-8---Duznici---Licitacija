using Bidding.API.Entities;
using Bidding.API.Models;
using AutoMapper;


namespace Bidding.API.Profiles
{
    public class RepresentativeBuyerApplicationProfile : Profile
    {


        public RepresentativeBuyerApplicationProfile()
        {
            CreateMap<BuyerApplication, RepresentativeBuyerApplicationResponseModel>()
                .ForMember(dest => dest.Guid, opt => opt.MapFrom(src => src.Guid))
             
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount));
            
        }

    }
}
