using AutoMapper;
using Person.API.Entities;
using Person.API.Models;
using Person.API.Models;


namespace Person.API.Profiles
{
    public class PhysicalPersonProfile : Profile
    {
        public PhysicalPersonProfile()
        {
            CreateMap<PhysicalPerson, PhysicalPersonResponseModel>();
            CreateMap<PhysicalPersonRequestModel, PhysicalPerson>();
            CreateMap<PhysicalPersonUpdateModel, PhysicalPerson>();
        }
    }


}
