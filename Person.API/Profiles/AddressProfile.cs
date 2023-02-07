using AutoMapper;
using Person.API.Entities;
using Person.API.Models.Address;
using Person.API.Models.ContactPerson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


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
