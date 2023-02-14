using AutoMapper;
using Person.API.Entities;
using Person.API.Models;
using Person.API.Models;


namespace Person.API.Profiles
{
    public class ContactPersonProfile : Profile
    {
        public ContactPersonProfile()
        {
            CreateMap<ContactPerson, ContactPersonResponseModel>();
            CreateMap<ContactPersonRequestModel, ContactPerson>();
            CreateMap<ContactPersonUpdateModel, ContactPerson>();
        }
    }
}
