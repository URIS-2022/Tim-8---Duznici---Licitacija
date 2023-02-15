using Preparation.API.Enums;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Preparation.API.Models
{
    [DataContract(Name = "Document", Namespace = "")]
    public class DocumentPostResponseModel
    {
        [DataMember]
        public Guid AnnouncementGuid { get; set; }

        [JsonConverter(typeof(DocumentTypeConverter))]
        [DataMember(Name = "DocumentType")]
        public DocumentType DocumentType { get; set; }
        [JsonConverter(typeof(DocumentStatusConverter))]
        [DataMember(Name = "DocumentStatus")]
        public DocumentStatus DocumentStatus { get; set; }
        [DataMember]
        public string ReferenceNumber { get; set; }
        [DataMember]
        public DateTime DateSubmitted { get; set; }
        [DataMember]
        public DateTime DateCertified { get; set; }
        [DataMember]
        public string Template { get; set; }

        public DocumentPostResponseModel(Guid announcementGuid, DocumentType documentType, DocumentStatus documentStatus, string referenceNumber, DateTime dateSubmitted, DateTime dateCertified, string template)
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
