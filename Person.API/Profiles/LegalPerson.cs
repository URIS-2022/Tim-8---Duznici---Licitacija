using AutoMapper;
using Person.API.Entities;
using Person.API.Models.LegalPerson;


namespace Person.API.Profiles
{
    public class LegalPersonProfile : Profile
    {
        public LegalPersonProfile()
        {
            CreateMap<LegalPerson, LegalPersonModel>();
        }
    }
}
