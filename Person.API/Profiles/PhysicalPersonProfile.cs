using AutoMapper;
using Person.API.Entities;
using Person.API.Models.PhysicalPerson;


namespace Person.API.Profiles
{
    public class PhysicalPersonProfile : Profile
    {
        public PhysicalPersonProfile()
        {
            CreateMap<PhysicalPerson, PhysicalPersonModel>();
        }
    }


}
