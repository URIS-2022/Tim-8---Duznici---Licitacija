using Licitation.API.Enums;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Licitation.API.Models.Document
{
    /**
    Represents a request model for posting a new document.
    */
    [DataContract(Name = "Document", Namespace = "")]
    public class DocumentPostResponseModel
    {
        /// <summary>
        /// The unique identifier of the licitation that the document belongs to.
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
        /// The date when the document was submitted.
        /// </summary>
        [DataMember]
        public DateTime DateSubmitted { get; set; }

        /// <summary>
        /// The date when the document was certified.
        /// </summary>
        [DataMember]
        public DateTime DateCertified { get; set; }

        /// <summary>
        /// The template of the document.
        /// </summary>
        [DataMember]
        public string Template { get; set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentPostRequestModel"/> class.
        /// </summary>
        /// <param name="licitationGuid">The GUID of the licitation associated with the document.</param>
        /// <param name="documentType">The type of the document.</param>
        /// <param name="referenceNumber">The reference number of the document.</param>
        /// <param name="dateSubmitted">The date when the document was submitted.</param>
        /// <param name="dateCertified">The date when the document was certified.</param>
        /// <param name="template">The template used to generate the document.</param>
        public DocumentPostResponseModel(Guid licitationGuid, DocumentType documentType, string referenceNumber, DateTime dateSubmitted, DateTime dateCertified, string template)
        {
            LicitationGuid = licitationGuid;
            DocumentType = documentType;
            ReferenceNumber = referenceNumber;
            DateSubmitted = dateSubmitted;
            DateCertified = dateCertified;
            Template = template;
        }
    }
}
