using AutoMapper;
using Person.API.Entities;
using Person.API.Models;



namespace Person.API.Profiles
{
    /// <summary>
    /// Represents a profile that contains information specific to a contact person.
    /// </summary>
    public class ContactPersonProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactPersonProfile"/> class.
        /// </summary>
        public ContactPersonProfile()
        {
            CreateMap<ContactPerson, ContactPersonResponseModel>();
            CreateMap<ContactPersonRequestModel, ContactPerson>();
            CreateMap<ContactPersonUpdateModel, ContactPerson>()
                .ForMember(dest => dest.FirstName, opt => opt.Condition(src => src.FirstName != null))
                .ForMember(dest => dest.LastName, opt => opt.Condition(src => src.LastName != null))
                .ForMember(dest => dest.Function, opt => opt.Condition(src => src.Function != null))
                .ForMember(dest => dest.PhoneNumber, opt => opt.Condition(src => src.PhoneNumber != null));
        }
    }
}
