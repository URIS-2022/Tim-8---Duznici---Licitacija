using AutoMapper;
using Person.API.Entities;
using Person.API.Models;
using Person.API.Models.ContactPerson;


namespace Person.API.Profiles
{
    public class LegalPersonProfile : Profile
    {
        public LegalPersonProfile()
        {
            CreateMap<LegalPerson, LegalPersonResponseModel>();
            CreateMap<LegalPersonRequestModel, LegalPerson>();
            CreateMap<LegalPersonUpdateModel, LegalPerson>();
        }
    }
}
