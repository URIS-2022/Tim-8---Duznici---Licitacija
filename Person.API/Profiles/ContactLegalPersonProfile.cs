using AutoMapper;
using Person.API.Entities;
using Person.API.Models;

namespace Person.API.Profiles
{
    /// <summary>
    /// Represents a profile that contains information specific to a contact person of legal person.
    /// </summary>
    public class ContactLegalPersonProfile : Profile

    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactLegalPersonProfile"/> class.
        /// </summary>
        public ContactLegalPersonProfile()

        {
            CreateMap<ContactPerson, ContactLegalResponseModel>()
                    .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                    .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                    .ForMember(dest => dest.Function, opt => opt.MapFrom(src => src.Function))
                    .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber));
        }
    }
}
