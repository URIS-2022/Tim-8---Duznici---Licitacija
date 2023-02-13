using AutoMapper;
using Preparation.API.Entities;
using Preparation.API.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Preparation.API.Profiles
{
    public class DocumentProfile : Profile
    {
        public DocumentProfile()
        {
            CreateMap<Document, DocumentResponseModel>();
            CreateMap<Document, DocumentRequestModel>();
            CreateMap<Document, DocumentUpdateModel>();
        }
    }
}
