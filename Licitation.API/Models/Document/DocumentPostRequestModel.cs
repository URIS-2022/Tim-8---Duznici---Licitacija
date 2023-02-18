using Licitation.API.Enums;
using System.Text.Json.Serialization;

namespace Licitation.API.Models.Document
{
    /**
    Represents a request model for posting a new document.
    */
    public class DocumentPostRequestModel
    {
        /*
        Represents a unique identifier for the licitation.
        */
        public Guid LicitationGuid { get; set; }

        /**
        Represents the type of document associated with the licitation, using a custom JsonConverter.
        */
        [JsonConverter(typeof(DocumentTypeConverter))]
        public DocumentType DocumentType { get; set; }
        /**
        Represents a reference number associated with the licitation.
        */
        public string ReferenceNumber { get; set; }
        /**
        Represents the date the document was submitted.
        */
        public DateTime DateSubmitted { get; set; }
        /**
        Represents the date the document was certified.
        */
        public DateTime DateCertified { get; set; }
        /**
        Represents the template used for the document.
        */
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
        public DocumentPostRequestModel(Guid licitationGuid, DocumentType documentType, string referenceNumber, DateTime dateSubmitted, DateTime dateCertified, string template)
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
