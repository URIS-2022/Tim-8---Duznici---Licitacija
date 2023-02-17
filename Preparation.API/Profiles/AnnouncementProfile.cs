using AutoMapper;
using Preparation.API.Entities;
using Preparation.API.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Preparation.API.Profiles
{
    /// <summary>
    /// AutoMapper profile for mapping Announcement entities to/from request/response models.
    /// </summary>
    public class AnnouncementProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the AnnouncementProfile class and configures the mappings between Announcement entities and request/response models.
        /// </summary>
        public AnnouncementProfile()
        {
            // Maps Announcement entities to AnnouncementGetResponseModel objects
            CreateMap<Entities.Announcement, AnnouncementGetResponseModel>();

            // Maps Announcement entities to AnnouncementPostResponseModel objects
            CreateMap<Entities.Announcement, AnnouncementPostResponseModel>();

            // Maps Announcement entities to AnnouncementPatchResponseModel objects
            CreateMap<Entities.Announcement, AnnouncementPatchResponseModel>();

            // Maps AnnouncementPostRequestModel objects to Announcement entities
            CreateMap<AnnouncementPostRequestModel, Entities.Announcement>();

            // Maps AnnouncementPatchRequestModel objects to Announcement entities
            CreateMap<AnnouncementPatchRequestModel, Entities.Announcement>()
                .ForMember(dest => dest.LicitationGuid, opt => opt.Condition(src => src.LicitationGuid != null));
        }
    }
}
