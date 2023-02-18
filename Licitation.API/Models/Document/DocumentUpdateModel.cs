using Licitation.API.Enums;
using System.Text.Json.Serialization;

namespace Licitation.API.Models.Document
{
    /**
    Model for patching (updating) a document.
    */
    public class DocumentUpdateModel
    {
        /// <summary>
        /// Gets or sets the LicitationGuid.
        /// </summary>
        public Guid LicitationGuid { get; set; }

        /// <summary>
        /// Gets or sets the DocumentType.
        /// </summary>
        [JsonConverter(typeof(DocumentTypeConverter))]
        public DocumentType? DocumentType { get; set; }

        /// <summary>
        /// Gets or sets the ReferenceNumber.
        /// </summary>
        public string? ReferenceNumber { get; set; }

        /// <summary>
        /// Gets or sets the DateSubmitted.
        /// </summary>
        public DateTime? DateSubmitted { get; set; }

        /// <summary>
        /// Gets or sets the DateCertified.
        /// </summary>
        public DateTime? DateCertified { get; set; }

        /// <summary>
        /// Gets or sets the Template.
        /// </summary>
        public string? Template { get; set; }

        /// <summary>
        /// Represents a model for updating a document.
        /// </summary>
        public DocumentUpdateModel(Guid licitation, DocumentType? documentType, string? referenceNumber, DateTime? dateSubmitted, DateTime? dateCertified, string? template)
        {

            this.LicitationGuid = licitation;
            DocumentType = documentType;
            ReferenceNumber = referenceNumber;
            DateSubmitted = dateSubmitted;
            DateCertified = dateCertified;
            Template = template;
        }
    }
}
