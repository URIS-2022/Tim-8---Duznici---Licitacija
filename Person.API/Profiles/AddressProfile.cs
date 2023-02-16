using AutoMapper;
using Person.API.Entities;
using Person.API.Models;


namespace Person.API.Profiles
{
    /// <summary>
    /// Represents a profile that contains information specific to a address.
    /// </summary>
    public class AddressProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddressProfile"/> class.
        /// </summary>
        public AddressProfile()
        {
            CreateMap<Address, AddressResponseModel>();
            CreateMap<AddressRequestModel, Address>();
            CreateMap<AddressUpdateModel, Address>()
                .ForMember(dest => dest.Country, opt => opt.Condition(src => src.Country != null))
                .ForMember(dest => dest.Street, opt => opt.Condition(src => src.Street != null))
                .ForMember(dest => dest.StreetNumber, opt => opt.Condition(src => src.StreetNumber != null))
                .ForMember(dest => dest.Place, opt => opt.Condition(src => src.Place != null))
                .ForMember(dest => dest.ZipCode, opt => opt.Condition(src => src.ZipCode != null));
        }
    }
}
