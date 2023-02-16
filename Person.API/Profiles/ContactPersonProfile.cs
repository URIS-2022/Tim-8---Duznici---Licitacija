using AutoMapper;
using Person.API.Entities;
using Person.API.Models;



namespace Person.API.Profiles
{
    public class ContactPersonProfile : Profile
    {
        public ContactPersonProfile()
        {
            CreateMap<ContactPerson, ContactPersonResponseModel>();
            CreateMap<ContactPersonRequestModel, ContactPerson>();
            CreateMap<ContactPersonUpdateModel, ContactPerson>()
                .ForMember(dest => dest.FirstName, opt => opt.Condition(src => src.FirstName != null))
                .ForMember(dest => dest.LastName, opt => opt.Condition(src => src.LastName != null))
                .ForMember(dest => dest.Function, opt => opt.Condition(src => src.Function != null))
                .ForMember(dest => dest.PhoneNumber, opt => opt.Condition(src => src.PhoneNumber != null));
        }
    }
}
