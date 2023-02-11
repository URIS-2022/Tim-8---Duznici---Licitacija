using AutoMapper;
using Landlot.API.Entities;
using Landlot.API.Models;

namespace Landlot.API.Profiles
{
    public class LotProfile : Profile
    {
        public LotProfile() 
        { 
            CreateMap<Lot, LotModel>();
            CreateMap<LotCreationModel, Lot>();
            CreateMap<LotUpdateModel, Lot>();
        
        }
    }
}
