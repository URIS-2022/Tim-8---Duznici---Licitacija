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
            CreateMap<Announcement, AnnouncementResponseModel>();
            CreateMap<Announcement, AnnouncementRequestModel>();
            CreateMap<Announcement, AnnouncementUpdateModel>();
        }
    }
}
