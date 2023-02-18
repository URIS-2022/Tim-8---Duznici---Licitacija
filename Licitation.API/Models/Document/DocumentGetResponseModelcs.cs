using Licitation.API.Enums;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Licitation.API.Models.Document
{
    /// <summary>
    /// Model representing the response for getting a document. 
    /// </summary>
    [DataContract(Name = "Document", Namespace = "")]
    public class DocumentGetResponseModel
    {
        /// <summary>
        /// The unique identifier of the document.
        /// </summary>
        [DataMember]
        public Guid Guid { get; set; }

        /// <summary>
        /// The unique identifier of the licitation to which the document belongs.
        /// </summary>
        [DataMember]
        public Guid LicitationGuid { get; set; }

        /// <summary>
        /// The type of the document.
        /// </summary>
        [JsonConverter(typeof(DocumentTypeConverter))]
        [DataMember(Name = "DocumentType")]
        public DocumentType DocumentType { get; set; }

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
        /// Initializes a new instance of the <see cref="DocumentGetResponseModel"/> class.
        /// </summary>
        /// <param name="guid">The unique identifier of the document.</param>
        /// <param name="licitationGuid">The unique identifier of the licitation to which the document belongs.</param>
        /// <param name="documentType">The type of the document.</param>
        /// <param name="referenceNumber">The reference number of the document.</param>
        /// <param name="dateSubmitted">The date the document was submitted.</param>
        /// <param name="dateCertified">The date the document was certified.</param>
        /// <param name="template">The template of the document.</param>
        public DocumentGetResponseModel(Guid guid, Guid licitationGuid, DocumentType documentType, string referenceNumber, DateTime dateSubmitted, DateTime dateCertified, string template)
        {
            Guid = guid;
            LicitationGuid = licitationGuid;
            DocumentType = documentType;
            ReferenceNumber = referenceNumber;
            DateSubmitted = dateSubmitted;
            DateCertified = dateCertified;
            Template = template;
        }
    }
}

