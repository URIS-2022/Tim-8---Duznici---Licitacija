using AutoMapper;
using Preparation.API.Models;

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
            CreateMap<DocumentPatchRequestModel, Entities.Document>()
            .ForMember(dest => dest.AnnouncementGuid, opt => opt.Condition(src => src.AnnouncementGuid != null))
            .ForMember(dest => dest.ReferenceNumber, opt => opt.Condition(src => src.ReferenceNumber != null))
            .ForMember(dest => dest.DateSubmitted, opt => opt.Condition(src => src.DateSubmitted != null))
            .ForMember(dest => dest.DateCertified, opt => opt.Condition(src => src.DateCertified != null))
            .ForMember(dest => dest.Template, opt => opt.Condition(src => src.Template != null))
            .ForMember(dest => dest.DocumentStatus, opt => opt.Condition(src => src.DocumentStatus.HasValue))
            .ForMember(dest => dest.DocumentType, opt => opt.Condition(src => src.DocumentType.HasValue))
            .ForMember(dest => dest.DocumentStatus, opt => opt.MapFrom(src => src.DocumentStatus!.Value))
            .ForMember(dest => dest.DocumentType, opt => opt.MapFrom(src => src.DocumentType!.Value));
            
        }
    }
}
