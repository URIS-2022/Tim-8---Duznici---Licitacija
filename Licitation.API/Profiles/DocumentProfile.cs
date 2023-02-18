using AutoMapper;
using Licitation.API.Models.Document;

namespace Licitation.API.Profiles
{
    /// <summary>
    /// Represents a profile that contains information specific to a document.
    /// </summary>
    public class DocumentProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentProfile"/> class.
        /// </summary>
        public DocumentProfile()
        {
            CreateMap<Entities.Document, DocumentGetResponseModel>();
            CreateMap<Entities.Document, DocumentPostResponseModel>();
            CreateMap<Entities.Document, DocumentPatchResponseModel>();
            CreateMap<DocumentPostRequestModel, Entities.Document>();
            CreateMap<DocumentPatchRequestModel, Entities.Document>()
                .ForMember(dest => dest.DocumentType, opt => opt.Condition(src => src.DocumentType.HasValue))
                .ForMember(dest => dest.LicitationGuid, opt => opt.Condition(src => src.LicitationGuid != null))
                .ForMember(dest => dest.ReferenceNumber, opt => opt.Condition(src => src.ReferenceNumber != null))
                .ForMember(dest => dest.DateSubmitted, opt => opt.Condition(src => src.DateSubmitted != null))
                .ForMember(dest => dest.DateCertified, opt => opt.Condition(src => src.DateCertified != null))
                .ForMember(dest => dest.Template, opt => opt.Condition(src => src.Template != null));

        }
    }
}