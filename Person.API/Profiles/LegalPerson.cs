using AutoMapper;
using Person.API.Entities;
using Person.API.Models.LegalPerson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


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
