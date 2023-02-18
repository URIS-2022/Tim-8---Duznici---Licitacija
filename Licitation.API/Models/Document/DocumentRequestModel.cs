using Licitation.API.Enums;
using System.Text.Json.Serialization;

namespace Licitation.API.Models.Document
{
    /**
    Represents a request model for posting a new document.
    */
    public class DocumentRequestModel
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
        /// Constructor for DocumentRewustModel class.
        /// </summary>
        public DocumentRequestModel(Guid licitation, DocumentType documentType, string referenceNumber, DateTime dateSubmitted, DateTime dateCertified, string template)
        {

            LicitationGuid = licitation;
            DocumentType = documentType;
            ReferenceNumber = referenceNumber;
            DateSubmitted = dateSubmitted;
            DateCertified = dateCertified;
            Template = template;
        }


    }


}
