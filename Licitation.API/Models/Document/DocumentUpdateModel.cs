using Licitation.API.Entities;
using Licitation.API.Enums;
using System.Text.Json.Serialization;

namespace Licitation.API.Models.Document
{
    public class DocumentUpdateModel
    {
        public Guid LicitationGuid { get; set; }

        [JsonConverter(typeof(DocumentTypeConverter))]
        public DocumentType? DocumentType { get; set; }
        public string? ReferenceNumber { get; set; }

        public DateTime? DateSubmitted { get; set; }

        public DateTime? DateCertified { get; set; }

        public string? Template { get; set; }

        public DocumentUpdateModel(Guid licitation, DocumentType? documentType, string? referenceNumber, DateTime? dateSubmitted, DateTime? dateCertified, string? template)
        {

            this.LicitationGuid = licitation;
            DocumentType = documentType;
            ReferenceNumber = referenceNumber;
            DateSubmitted = dateSubmitted;
            DateCertified = dateCertified;
            Template = template;
        }
    }
}
