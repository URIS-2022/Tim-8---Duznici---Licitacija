using Preparation.API.Entities;
using Preparation.API.Enums;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Preparation.API.Models
{
    /// <summary>
    /// Represents the response model for a document.
    /// </summary>
    [DataContract(Name = "Document", Namespace = "")]
    public class DocumentGetResponseModel
    {
        /// <summary>
        /// The GUID of the document.
        /// </summary>
        [DataMember]
        public Guid Guid { get; set; }

        /// <summary>
        /// The GUID of the announcement that the document is associated with.
        /// </summary>
        [DataMember]
        public Guid AnnouncementGuid { get; set; }

        /// <summary>
        /// The type of the document.
        /// </summary>
        [JsonConverter(typeof(DocumentTypeConverter))]
        [DataMember(Name = "DocumentType")]
        public DocumentType DocumentType { get; set; }

        /// <summary>
        /// The status of the document.
        /// </summary>
        [JsonConverter(typeof(DocumentStatusConverter))]
        [DataMember(Name = "DocumentStatus")]
        public DocumentStatus DocumentStatus { get; set; }

        /// <summary>
        /// The reference number of the document.
        /// </summary>
        [DataMember]
        public string ReferenceNumber { get; set; }

        /// <summary>
        /// The date the document was submitted.
        /// </summary>
        [DataMember]
        public DateTime DateSubmitted { get; set; }

        /// <summary>
        /// The date the document was certified.
        /// </summary>
        [DataMember]
        public DateTime DateCertified { get; set; }

        /// <summary>
        /// The template of the document.
        /// </summary>
        [DataMember]
        public string Template { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentGetResponseModel"/> class with the specified properties.
        /// </summary>
        /// <param name="guid">The GUID of the document.</param>
        /// <param name="announcementGuid">The GUID of the announcement that the document is associated with.</param>
        /// <param name="documentType">The type of the document.</param>
        /// <param name="documentStatus">The status of the document.</param>
        /// <param name="referenceNumber">The reference number of the document.</param>
        /// <param name="dateSubmitted">The date the document was submitted.</param>
        /// <param name="dateCertified">The date the document was certified.</param>
        /// <param name="template">The template of the document.</param>
        public DocumentGetResponseModel(Guid guid,Guid announcementGuid, DocumentType documentType, DocumentStatus documentStatus, string referenceNumber, DateTime dateSubmitted, DateTime dateCertified, string template)
        {
            Guid = guid;
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
