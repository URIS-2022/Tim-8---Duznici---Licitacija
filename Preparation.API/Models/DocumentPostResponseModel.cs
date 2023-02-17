using Preparation.API.Enums;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Preparation.API.Models
{
    /// <summary>
    /// Represents the model for the response after a new document is posted.
    /// </summary>
    [DataContract(Name = "Document", Namespace = "")]
    public class DocumentPostResponseModel
    {
        /// <summary>
        /// The Announcement Guid of the new document.
        /// </summary>
        [DataMember]
        public Guid AnnouncementGuid { get; set; }

        /// <summary>
        /// The Document Type of the new document.
        /// </summary>
        [JsonConverter(typeof(DocumentTypeConverter))]
        [DataMember(Name = "DocumentType")]
        public DocumentType DocumentType { get; set; }

        /// <summary>
        /// The Document Status of the new document.
        /// </summary>
        [JsonConverter(typeof(DocumentStatusConverter))]
        [DataMember(Name = "DocumentStatus")]
        public DocumentStatus DocumentStatus { get; set; }

        /// <summary>
        /// The Reference Number of the new document.
        /// </summary>
        [DataMember]
        public string ReferenceNumber { get; set; }

        /// <summary>
        /// The Date Submitted of the new document.
        /// </summary>
        [DataMember]
        public DateTime DateSubmitted { get; set; }

        /// <summary>
        /// The Date Certified of the new document.
        /// </summary>
        [DataMember]
        public DateTime DateCertified { get; set; }

        /// <summary>
        /// The Template of the new document.
        /// </summary>
        [DataMember]
        public string Template { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentPostResponseModel"/> class.
        /// </summary>
        /// <param name="announcementGuid">The Announcement Guid of the new document.</param>
        /// <param name="documentType">The Document Type of the new document.</param>
        /// <param name="documentStatus">The Document Status of the new document.</param>
        /// <param name="referenceNumber">The Reference Number of the new document.</param>
        /// <param name="dateSubmitted">The Date Submitted of the new document.</param>
        /// <param name="dateCertified">The Date Certified of the new document.</param>
        /// <param name="template">The Template of the new document.</param>
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
