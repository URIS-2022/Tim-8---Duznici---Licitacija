using AutoMapper;
using Licitation.API.Models.Document;

namespace Licitation.API.Profiles
{
    public class DocumentProfile : Profile
    {
        public DocumentProfile()
        {
            CreateMap<Entities.Document, DocumentGetResponseModel>();
            CreateMap<Entities.Document, DocumentPostResponseModel>();
            CreateMap<Entities.Document, DocumentPatchResponseModel>();
            CreateMap<DocumentPostRequestModel, Entities.Document>();
            CreateMap<DocumentPatchRequestModel, Entities.Document>();

        }
    }
}