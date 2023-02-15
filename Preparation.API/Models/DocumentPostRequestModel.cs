using Preparation.API.Entities;
using Preparation.API.Enums;
using System.Text.Json.Serialization;

namespace Preparation.API.Models
{
    public class DocumentPostRequestModel
    {
        public Guid AnnouncementGuid { get; set; }
        [JsonConverter(typeof(DocumentTypeConverter))]
        public DocumentType DocumentType { get; set; }
        [JsonConverter(typeof(DocumentStatusConverter))]
        public DocumentStatus DocumentStatus { get; set; }
        public string ReferenceNumber { get; set; }
        public DateTime DateSubmitted { get; set; }
        public DateTime DateCertified { get; set; }
        public string Template { get; set; }

        public DocumentPostRequestModel(Guid announcementGuid, DocumentType documentType, DocumentStatus documentStatus, string referenceNumber, DateTime dateSubmitted, DateTime dateCertified, string template)
        {
            AnnouncementGuid = announcementGuid;
            DocumentType = documentType;
            DocumentStatus = documentStatus;
            ReferenceNumber = referenceNumber;
            DateSubmitted = dateSubmitted;
            DateCertified = dateCertified;
            Template = template;
        }
    }
}
