using Licitation.API.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace Licitation.API.Entities
{
    public partial class Document : IValidatableObject
    {
        public Guid Guid { get; set; }
        public LicitationEntity licitation { get; set; }
        [JsonConverter(typeof(DocumentTypeConverter))]
        public DocumentType documentType { get; set; }
        public string ReferenceNumber { get; set; }
        public DateTime DateSubmitted { get; set; }
        public DateTime DateCertified { get; set; }
        public string Template { get; set; }

        public Document()
        {

        }

        public Document(Guid id, LicitationEntity licitation, DocumentType documentType, string referenceNumber, DateTime dateSubmitted, DateTime dateSertified, string template)
        {
            Guid = id;
            this.licitation = licitation;
            this.documentType = documentType;
            ReferenceNumber = referenceNumber;
            DateSubmitted = dateSubmitted;
            DateCertified = dateSertified;
            Template = template;
        }



        public Document(LicitationEntity licitation, DocumentType documentType, string referenceNumber, DateTime dateSubmitted, DateTime dateSertified, string template)
        {
            Guid = Guid.NewGuid();
            this.licitation = licitation;
            this.documentType = documentType;
            ReferenceNumber = referenceNumber;
            DateSubmitted = dateSubmitted;
            DateCertified = dateSertified;
            Template = template;
        }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> results = new List<ValidationResult>();

            if (Guid == Guid.Empty)
            {
                results.Add(new ValidationResult("Guid cannot be empty."));
            }

            if (licitation == null)
                results.Add(new ValidationResult("Licitation cannot be null."));

            if (documentType == null)
                results.Add(new ValidationResult("Document type cannot be null."));

            if (ReferenceNumber == null)
                results.Add(new ValidationResult("Reference number must be greater than zero."));

            if (DateSubmitted > DateCertified)
                results.Add(new ValidationResult("Date submitted cannont be after DataCertified"));

            //if (DateCertified < DateTime.Now)
                //results.Add(new ValidationResult("Date"));

            if (string.IsNullOrWhiteSpace(Template))
                results.Add(new ValidationResult("Template cannot be empty or whitespace."));

            return results;
        }
    }
}
