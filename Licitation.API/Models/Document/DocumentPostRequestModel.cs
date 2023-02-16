using Licitation.API.Enums;
using System.Text.Json.Serialization;

namespace Licitation.API.Models.Document
{
    public class DocumentPostRequestModel
    {
        public Guid LicitationGuid { get; set; }
        [JsonConverter(typeof(DocumentTypeConverter))]
        public DocumentType DocumentType { get; set; }
        public string ReferenceNumber { get; set; }
        public DateTime DateSubmitted { get; set; }
        public DateTime DateCertified { get; set; }
        public string Template { get; set; }

        public DocumentPostRequestModel(Guid licitationGuid, DocumentType documentType, string referenceNumber, DateTime dateSubmitted, DateTime dateCertified, string template)
        {
            LicitationGuid = licitationGuid;
            DocumentType = documentType;
            ReferenceNumber = referenceNumber;
            DateSubmitted = dateSubmitted;
            DateCertified = dateCertified;
            Template = template;
        }
    }
}
