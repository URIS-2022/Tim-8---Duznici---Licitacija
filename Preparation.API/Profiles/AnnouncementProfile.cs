using AutoMapper;
using Preparation.API.Entities;
using Preparation.API.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Preparation.API.Profiles
{
    public class AnnouncementProfile : Profile
    {
        public AnnouncementProfile()
        {
            CreateMap<Entities.Announcement, AnnouncementGetResponseModel>();
            CreateMap<Entities.Announcement, AnnouncementPostResponseModel>();
            CreateMap<Entities.Announcement, AnnouncementPatchResponseModel>();
            CreateMap<AnnouncementPostRequestModel, Entities.Announcement>();
            CreateMap<AnnouncementPatchRequestModel, Entities.Announcement>();
        }
    }
}
