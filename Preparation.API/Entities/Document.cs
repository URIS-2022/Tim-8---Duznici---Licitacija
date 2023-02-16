using Preparation.API.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Preparation.API.Entities
{
    public partial class Document : IValidatableObject
    {
        [Key]
        public Guid Guid { get; set; }
        public Guid AnnouncementGuid { get; set; }
        [JsonConverter(typeof(DocumentTypeConverter))]
        public DocumentType DocumentType { get; set; }
        [JsonConverter(typeof(DocumentStatusConverter))]
        public DocumentStatus DocumentStatus { get; set; }
        public string ReferenceNumber { get; set; }
        public DateTime DateSubmitted { get; set; }
        public DateTime DateCertified { get; set; }
        public string Template { get; set; }

        //public Announcement Announcement { get; set; }

        public Document() { }


        public Document(Guid id, Guid announcementGuid, DocumentType documentType, DocumentStatus documentStatus, string referenceNumber, DateTime dateSubmitted, DateTime dateCertified, string template)
        {
            Guid = id;
            AnnouncementGuid = announcementGuid;
            DocumentType = documentType;
            DocumentStatus = documentStatus;
            ReferenceNumber = referenceNumber;
            DateSubmitted = dateSubmitted;
            DateCertified = dateCertified;
            Template = template;
        }



        public Document(Guid announcementGuid, DocumentType documentType, DocumentStatus documentStatus, string referenceNumber, DateTime dateSubmitted, DateTime dateCertified, string template)
        {
            Guid = Guid.NewGuid();
            AnnouncementGuid = announcementGuid;
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

            if (AnnouncementGuid == Guid.Empty)
            {
                results.Add(new ValidationResult("Guid cannot be empty."));
            }

            if (ReferenceNumber.Length != 20 )
                results.Add(new ValidationResult("Reference number length must be 20 characters.", new[] { nameof(ReferenceNumber) }));

            if (DateSubmitted > DateTime.Now)
            {
                results.Add(new ValidationResult("Date Submitted cannot be in the future.", new[] { nameof(DateSubmitted) }));
            }

            if (DateCertified < DateSubmitted)
            {
                results.Add(new ValidationResult("Resolution Certified cannot be before Date Submitted.", new[] { nameof(DateCertified) }));
            }

            if (string.IsNullOrWhiteSpace(Template))
                results.Add(new ValidationResult("Template cannot be empty or whitespace.", new[] { nameof(Template) }));

            return results;
        }
    }
}
