using Preparation.API.Entities;
using Preparation.API.Enums;
using System.Text.Json.Serialization;

namespace Preparation.API.Models
{
    /// <summary>
    /// Represents a request model for patching a <see cref="Document"/>.
    /// </summary>
    public class DocumentPatchRequestModel
    {
        /// <summary>
        /// Gets or sets the announcement GUID for the document.
        /// </summary>
        public Guid? AnnouncementGuid { get; set; }

        /// <summary>
        /// Gets or sets the document type.
        /// </summary>
        [JsonConverter(typeof(DocumentTypeConverter))]
        public DocumentType? DocumentType { get; set; }

        /// <summary>
        /// Gets or sets the document status.
        /// </summary>
        [JsonConverter(typeof(DocumentStatusConverter))]
        public DocumentStatus? DocumentStatus { get; set; }

        /// <summary>
        /// Gets or sets the reference number for the document.
        /// </summary>
        public string? ReferenceNumber { get; set; }

        /// <summary>
        /// Gets or sets the date when the document was submitted.
        /// </summary>
        public DateTime? DateSubmitted { get; set; }

        /// <summary>
        /// Gets or sets the date when the document was certified.
        /// </summary>
        public DateTime? DateCertified { get; set; }

        /// <summary>
        /// Gets or sets the document template.
        /// </summary>
        public string? Template { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentPatchRequestModel"/> class.
        /// </summary>
        /// <param name="announcementGuid">The announcement GUID for the document.</param>
        /// <param name="documentType">The document type.</param>
        /// <param name="documentStatus">The document status.</param>
        /// <param name="referenceNumber">The reference number for the document.</param>
        /// <param name="dateSubmitted">The date when the document was submitted.</param>
        /// <param name="dateCertified">The date when the document was certified.</param>
        /// <param name="template">The document template.</param>
        public DocumentPatchRequestModel(Guid? announcementGuid, DocumentType? documentType, DocumentStatus? documentStatus, string? referenceNumber, DateTime? dateSubmitted, DateTime? dateCertified, string? template)
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
