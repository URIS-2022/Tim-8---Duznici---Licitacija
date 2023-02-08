using AutoMapper;
using Person.API.Entities;
using Person.API.Models.Address;


namespace Person.API.Profiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<Address, AddressModel>();
        }
    }
}
