using AutoMapper;
using Person.API.Entities;
using Person.API.Models;

namespace Person.API.Profiles
{
    public class ContactLegalPersonProfile : Profile

    {
        public ContactLegalPersonProfile()

        {
        CreateMap<ContactPerson, ContactLegalResponseModel>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName ))
                .ForMember(dest => dest.Function, opt => opt.MapFrom(src => src.Function ))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber));
    } }
}
