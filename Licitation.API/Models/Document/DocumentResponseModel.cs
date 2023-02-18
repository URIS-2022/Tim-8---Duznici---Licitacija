using Licitation.API.Enums;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Licitation.API.Models.Document
{
    /**
    Represents a request model for posting a new document.
    */
    [DataContract(Name = "Document", Namespace = "")]
    public class DocumentResponseModel
    {
        /// <summary>
        /// The unique identifier of the document.
        /// </summary>
        [DataMember]
        public Guid Guid { get; set; }

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
        /// Constructor for DocumentResponseModel class.
        /// </summary>
        public DocumentResponseModel(Guid licitation, DocumentType documentType, string referenceNumber, DateTime dateSubmitted, DateTime dateCertified, string template)
            {

                Guid = Guid.NewGuid();
                this.LicitationGuid = licitation;
                DocumentType = documentType;
                ReferenceNumber = referenceNumber;
                DateSubmitted = dateSubmitted;
                DateCertified = dateCertified;
                Template = template;
            }



        
    }
}
