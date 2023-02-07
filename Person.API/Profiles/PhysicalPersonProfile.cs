using AutoMapper;
using Person.API.Entities;
using Person.API.Models.PhysicalPerson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


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
