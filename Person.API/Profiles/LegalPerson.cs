using AutoMapper;
using Person.API.Entities;
using Person.API.Models.ContactPerson;
using Person.API.Models.LegalPerson;


namespace Person.API.Profiles
{
    public class LegalPersonProfile : Profile
    {
        public LegalPersonProfile()
        {
            CreateMap<LegalPerson, LegalPersonModel>();
            CreateMap<LegalPersonCreationModel, LegalPerson>();
            CreateMap<LegalPersonUpdateModel, LegalPerson>();
        }
    }
}
