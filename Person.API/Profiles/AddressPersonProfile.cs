using AutoMapper;
using Person.API.Entities;
using Person.API.Models;

namespace Person.API.Profiles
{
    /// <summary>
    /// Represents a profile that contains information specific to a address of person.
    /// </summary>
    public class AddressPersonModel : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddressPersonModel"/> class.
        /// </summary>
        public AddressPersonModel()
        {
            CreateMap<Address, AddressPersonResponseModel>()
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country))
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Street))
                .ForMember(dest => dest.StreetNumber, opt => opt.MapFrom(src => src.StreetNumber))
                .ForMember(dest => dest.Place, opt => opt.MapFrom(src => src.Place))
                .ForMember(dest => dest.ZipCode, opt => opt.MapFrom(src => src.ZipCode));
        }
    }
}
