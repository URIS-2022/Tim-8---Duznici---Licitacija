using AutoMapper;
using Person.API.Entities;
using Person.API.Models;


namespace Person.API.Profiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<Address, AddressResponseModel>();
            CreateMap<AddressRequestModel, Address>();
            CreateMap<AddressUpdateModel, Address>();
        }
    }
}
