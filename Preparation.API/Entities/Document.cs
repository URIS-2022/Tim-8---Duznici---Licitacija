using Preparation.API.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Preparation.API.Entities
{
    public partial class Document : IValidatableObject
    {
        public Guid Guid { get; set; }
        public Announcement Announcement { get; set; }
        [JsonConverter(typeof(DocumentTypeConverter))]
        public DocumentType DocumentType { get; set; }
        [JsonConverter(typeof(DocumentStatusConverter))]
        public DocumentStatus DocumentStatus { get; set; }
        public string ReferenceNumber { get; set; }
        public DateTime DateSubmitted { get; set; }
        public DateTime DateCertified { get; set; }
        public string Template { get; set; }

        public Document() { }


        public Document(Guid id, Announcement announcement, DocumentType documentType, DocumentStatus documentStatus, string referenceNumber, DateTime dateSubmitted, DateTime dateCertified, string template)
        {
            Guid = id;
            Announcement = announcement;
            DocumentType = documentType;
            DocumentStatus = documentStatus;
            ReferenceNumber = referenceNumber;
            DateSubmitted = dateSubmitted;
            DateCertified = dateCertified;
            Template = template;
        }



        public Document(Announcement announcement, DocumentType documentType, DocumentStatus documentStatus, string referenceNumber, DateTime dateSubmitted, DateTime dateCertified, string template)
        {
            Guid = Guid.NewGuid();
            Announcement = announcement;
            DocumentType = documentType;
            DocumentStatus = documentStatus;
            ReferenceNumber = referenceNumber;
            DateSubmitted = dateSubmitted;
            DateCertified = dateCertified;
            Template = template;
        }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> results = new List<ValidationResult>();

            if (Guid == Guid.Empty)
            {
                results.Add(new ValidationResult("Guid cannot be empty."));
            }

            if (Announcement == null)
                results.Add(new ValidationResult("Announcement cannot be null."/*, new[] { nameof(publicBidding) }*/));

            if (DocumentType == null)
                results.Add(new ValidationResult("Document type cannot be null."/*, new[] { nameof(documentType) }*/));

            if (ReferenceNumber.Length != 20 )
                results.Add(new ValidationResult("Reference number length must be 20 characters."/*, new[] { nameof(ReferenceNumber) }*/));

            if (DateSubmitted == null)
                results.Add(new ValidationResult("Date submitted cannot be null."/*, new[] { nameof(DateSubmitted) }*/));

            if (DateCertified == null)
                results.Add(new ValidationResult("Date certified cannot be null."/*, new[] { nameof(DateCertified) }*/));

            if (string.IsNullOrWhiteSpace(Template))
                results.Add(new ValidationResult("Template cannot be empty or whitespace."/*, new[] { nameof(Template) }*/));

            return results;
        }
    }
}
