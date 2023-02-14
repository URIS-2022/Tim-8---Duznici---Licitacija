using AutoMapper;
using Person.API.Entities;
using Person.API.Models;
using Person.API.Models;


namespace Person.API.Profiles
{
    public class LegalPersonProfile : Profile
    {
        public LegalPersonProfile()
        {
            CreateMap<LegalPerson, LegalPersonResponseModel>();
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
