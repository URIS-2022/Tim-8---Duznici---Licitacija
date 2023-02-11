using AutoMapper;
using LiceWebAPI.Models.Lice.FizickoLice;
using Person.API.Entities;
using Person.API.Models.ContactPerson;
using Person.API.Models.PhysicalPerson;


namespace Person.API.Profiles
{
    public class PhysicalPersonProfile : Profile
    {
        public PhysicalPersonProfile()
        {
            CreateMap<PhysicalPerson, PhysicalPersonModel>();
            CreateMap<PhysicalPersonCreationModel, PhysicalPerson>();
            CreateMap<PhysicalPersonUpdateModel, PhysicalPerson>();
        }
    }


}
