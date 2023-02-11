using Licitation.API.Entities;
using Licitation.API.Enums;
using System.Text.Json.Serialization;

namespace Licitation.API.Models.Document
{
    public class DocumentRequestModel
    {
        public LicitationEntity licitation { get; set; }
        [JsonConverter(typeof(DocumentTypeConverter))]
        public DocumentType documentType { get; set; }
        public string ReferenceNumber { get; set; }
        public string Template { get; set; }

        public DocumentRequestModel(LicitationEntity licitation, DocumentType documentType, string referenceNumber, string template)
        {

            this.licitation = licitation;
            this.documentType = documentType;
            ReferenceNumber = referenceNumber;
            Template = template;
        }
    }
}
