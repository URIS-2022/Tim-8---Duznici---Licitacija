using AutoMapper;
using Preparation.API.Entities;
using Preparation.API.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Preparation.API.Profiles
{
    /// <summary>
    /// Defines the mapping profile for <see cref="Entities.Document"/> and its corresponding models.
    /// </summary>
    public class DocumentProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentProfile"/> class and creates the mapping for the document-related models and entities.
        /// </summary>
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
