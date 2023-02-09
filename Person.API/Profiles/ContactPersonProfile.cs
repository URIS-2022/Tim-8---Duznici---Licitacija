using AutoMapper;
using Person.API.Entities;
using Person.API.Models.ContactPerson;


namespace Person.API.Profiles
{
    public class ContactPersonProfile : Profile
    {
        public ContactPersonProfile()
        {
            CreateMap<ContactPerson, ContactPersonModel>();
        }
    }
}
