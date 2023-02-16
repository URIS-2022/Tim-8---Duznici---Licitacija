using Preparation.API.Entities;
using Preparation.API.Enums;
using System.Text.Json.Serialization;

namespace Preparation.API.Models
{
    /// <summary>
    /// Represents a model for creating a new document request.
    /// </summary>
    public class DocumentPostRequestModel
    {
        /// <summary>
        /// Gets or sets the announcement Guid of the document.
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
        /// Gets or sets the date the document was submitted.
        /// </summary>
        public DateTime DateSubmitted { get; set; }

        /// <summary>
        /// Gets or sets the date the document was certified.
        /// </summary>
        public DateTime DateCertified { get; set; }

        /// <summary>
        /// Gets or sets the template of the document.
        /// </summary>
        public string Template { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentPostRequestModel"/> class.
        /// </summary>
        /// <param name="announcementGuid">The announcement Guid of the document.</param>
        /// <param name="documentType">The type of the document.</param>
        /// <param name="documentStatus">The status of the document.</param>
        /// <param name="referenceNumber">The reference number of the document.</param>
        /// <param name="dateSubmitted">The date the document was submitted.</param>
        /// <param name="dateCertified">The date the document was certified.</param>
        /// <param name="template">The template of the document.</param>
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
