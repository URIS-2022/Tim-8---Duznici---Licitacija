using Bidding.API.Entities;
using Bidding.API.Models;
using AutoMapper;

namespace Bidding.API.Profiles
{
    public class DocumentProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the  class.
        /// Configures mapping between  classes.
        /// </summary>
        public DocumentProfile()
        {
            CreateMap<Document, DocumentResponseModel>()
                .ForMember(dest => dest.Guid, opt => opt.MapFrom(src => src.Guid != Guid.Empty))
                 .ForMember(dest => dest.documentType, opt => opt.MapFrom(src => src.documentType));
            CreateMap<DocumentRequestModel, Document>()
                 .ForMember(dest => dest.Guid, opt => opt.MapFrom(src => src.Guid != Guid.Empty))
                 .ForMember(dest => dest.documentType, opt => opt.MapFrom(src => src.documentType));

           
            CreateMap<DocumentRequestModel, Document>()
                 
                 .ForMember(dest => dest.documentType, opt => opt.MapFrom(src => src.documentType));

            CreateMap<DocumentUpdateModel, Document>()
                .ForMember(dest => dest.PublicBiddingGuid, opt => opt.Condition(src => src.PublicBiddingGuid != Guid.Empty))
                .ForMember(dest => dest.documentType, opt => opt.Condition(src => src.documentType.HasValue))
                .ForMember(dest => dest.ReferenceNumber, opt => opt.Condition(src => !string.IsNullOrEmpty(src.ReferenceNumber)))
                .ForMember(dest => dest.DateSubmited, opt => opt.Condition(src => src.DateSubmited.HasValue))
                .ForMember(dest => dest.DateSertified, opt => opt.Condition(src => src.DateSertified.HasValue))
                .ForMember(dest => dest.Template, opt => opt.Condition(src => !string.IsNullOrEmpty(src.Template)))
                .ForMember(dest => dest.documentType, opt => opt.MapFrom(src => src.documentType!.Value));
        }
    }
}
