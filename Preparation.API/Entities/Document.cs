// using statements for necessary namespaces
using Preparation.API.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Preparation.API.Entities
{
    /// <summary>
    /// Represents a document entity with its properties and methods.
    /// </summary>
    public partial class Document : IValidatableObject
    {
        /// <summary>
        /// Gets or sets the unique identifier of the document.
        /// </summary>
        [Key]
        public Guid Guid { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the announcement.
        /// </summary>
        public Guid AnnouncementGuid { get; set; }

        /// <summary>
        /// Gets or sets the type of the document.
        /// </summary>
        [JsonConverter(typeof(DocumentTypeConverter))]
        public DocumentType DocumentType { get; set; }

        /// <summary>
        /// Gets or sets the status of the document.
        /// </summary>
        [JsonConverter(typeof(DocumentStatusConverter))]
        public DocumentStatus DocumentStatus { get; set; }

        /// <summary>
        /// Gets or sets the reference number of the document.
        /// </summary>
        public string ReferenceNumber { get; set; }

        /// <summary>
        /// Gets or sets the date when the document was submitted.
        /// </summary>
        public DateTime DateSubmitted { get; set; }

        /// <summary>
        /// Gets or sets the date when the document was certified.
        /// </summary>
        public DateTime DateCertified { get; set; }

        /// <summary>
        /// Gets or sets the template of the document.
        /// </summary>
        public string Template { get; set; }

        /// <summary>
        /// Gets or sets the announcement related to this document.
        /// </summary>
        public Announcement Announcement { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Document"/> class.
        /// </summary>
        public Document() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Document"/> class with the specified parameters.
        /// </summary>
        /// <param name="id">The unique identifier of the document.</param>
        /// <param name="announcementGuid">The unique identifier of the announcement.</param>
        /// <param name="documentType">The type of the document.</param>
        /// <param name="documentStatus">The status of the document.</param>
        /// <param name="referenceNumber">The reference number of the document.</param>
        /// <param name="dateSubmitted">The date when the document was submitted.</param>
        /// <param name="dateCertified">The date when the document was certified.</param>
        /// <param name="template">The template of the document.</param>
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

        /// <summary>
        /// Initializes a new instance of the Document class with a new Guid.
        /// </summary>
        /// <param name="announcementGuid">The unique identifier of the announcement that this Document is associated with.</param>
        /// <param name="documentType">The type of the Document.</param>
        /// <param name="documentStatus">The status of the Document.</param>
        /// <param name="referenceNumber">The reference number of the Document.</param>
        /// <param name="dateSubmitted">The date when the Document was submitted.</param>
        /// <param name="dateCertified">The date when the Document was certified.</param>
        /// <param name="template">The template of the Document.</param>
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

        /// <summary>
        /// Validates the Document entity.
        /// </summary>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>A collection of ValidationResult objects that represent the validation errors.</returns>
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
