using AutoMapper;
using Licitation.API.Models.Document;

namespace Licitation.API.Profiles;

public class DocumentProfile : Profile
{
    public DocumentProfile()
    {
        CreateMap<Entities.Document, DocumentResponseModel>();
        CreateMap<DocumentRequestModel, Entities.Document>();
        CreateMap<DocumentUpdateModel, Entities.Document>()
            .ForMember(dest => dest.LicitationGuid, opt => opt.Condition(src => src.LicitationGuid != Guid.Empty))
            .ForMember(dest => dest.documentType, opt => opt.Condition(src => src.documentType != null))
            .ForMember(dest => dest.ReferenceNumber, opt => opt.Condition(src => src.ReferenceNumber != null))
            .ForMember(dest => dest.DateSubmitted, opt => opt.Condition(src => src.DateSubmitted != null))
            .ForMember(dest => dest.DateCertified, opt => opt.Condition(src => src.DateCertified != null))
            .ForMember(dest => dest.Template, opt => opt.Condition(src => src.Template != null));
    }
}
