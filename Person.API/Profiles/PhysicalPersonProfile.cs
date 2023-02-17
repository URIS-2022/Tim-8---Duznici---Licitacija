using AutoMapper;
using Person.API.Entities;
using Person.API.Models;


namespace Person.API.Profiles

{
    /// <summary>
    /// Represents a profile that contains information specific to a physical person.
    /// </summary>
    public class PhysicalPersonProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PhysicalPersonProfile"/> class.
        /// </summary>
        public PhysicalPersonProfile()
        {
            CreateMap<PhysicalPerson, PhysicalPersonResponseModel>()
             .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address));

            CreateMap<PhysicalPersonRequestModel, PhysicalPerson>();
            CreateMap<PhysicalPersonUpdateModel, PhysicalPerson>()
                .ForMember(dest => dest.FirstName, opt => opt.Condition(src => src.FirstName != null))
                .ForMember(dest => dest.LastName, opt => opt.Condition(src => src.LastName != null))
                .ForMember(dest => dest.PhoneNumber1, opt => opt.Condition(src => src.PhoneNumber1 != null))
                .ForMember(dest => dest.PhoneNumber2, opt => opt.Condition(src => src.PhoneNumber2 != null))
                .ForMember(dest => dest.Jmbg, opt => opt.Condition(src => src.Jmbg != null))
                .ForMember(dest => dest.Email, opt => opt.Condition(src => src.Email != null))
                .ForMember(dest => dest.AccountNumber, opt => opt.Condition(src => src.AccountNumber != null));
        }
    }


}
