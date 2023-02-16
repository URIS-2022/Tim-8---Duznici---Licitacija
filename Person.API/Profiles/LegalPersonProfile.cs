using AutoMapper;
using Person.API.Entities;
using Person.API.Models;


namespace Person.API.Profiles
{
    /// <summary>
    /// Represents a profile that contains information specific to a legal person.
    /// </summary>
    public class LegalPersonProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LegalPersonProfile"/> class.
        /// </summary>
        public LegalPersonProfile()
        {
            CreateMap<LegalPerson, LegalPersonResponseModel>()
                .ForMember(dest => dest.ContactLegalPerson,opt => opt.MapFrom(src=>src.ContactPerson));
            
            CreateMap<LegalPersonRequestModel, LegalPerson>();
            CreateMap<LegalPersonUpdateModel, LegalPerson>()
                .ForMember(dest => dest.Name, opt => opt.Condition(src => src.Name != null))
                .ForMember(dest => dest.IdentificationNumber, opt => opt.Condition(src => src.IdentificationNumber != null))
                .ForMember(dest => dest.PhoneNumber1, opt => opt.Condition(src => src.PhoneNumber1 != null))
                .ForMember(dest => dest.PhoneNumber2, opt => opt.Condition(src => src.PhoneNumber2 != null))
                .ForMember(dest => dest.Fax, opt => opt.Condition(src => src.Fax != null))
                .ForMember(dest => dest.Email, opt => opt.Condition(src => src.Email != null))
                .ForMember(dest => dest.AccountNumber, opt => opt.Condition(src => src.AccountNumber != null));
        }
    }
}
