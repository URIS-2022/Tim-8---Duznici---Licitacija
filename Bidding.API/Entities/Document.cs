using Bidding.API.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;


namespace Bidding.API.Entities
{
    public partial class Document : IValidatableObject
    {
       
        public Guid Guid { get; set; }
        public PublicBidding publicBidding { get; set; }
        [JsonConverter(typeof(DocumentTypeConverter))]
        public DocumentType documentType { get; set; }
        public string ReferenceNumber { get; set; }

        public DateTime DateSubmited { get; set; }

        public DateTime DateSertified { get; set; }

        public string Template { get; set; }

        public Document() { }


        public Document(Guid id,PublicBidding publicBidding, DocumentType documentType, string referenceNumber, DateTime dateSubmited, DateTime dateSertified, string template)
        {
            Guid = id;
            this.publicBidding = publicBidding;
            this.documentType = documentType;
            ReferenceNumber = referenceNumber;
            DateSubmited = dateSubmited;
            DateSertified = dateSertified;
            Template = template;
        }



        public Document(PublicBidding publicBidding, DocumentType documentType, string referenceNumber, DateTime dateSubmited, DateTime dateSertified, string template)
        {
            Guid = Guid.NewGuid();
            this.publicBidding = publicBidding;
            this.documentType = documentType;
            ReferenceNumber = referenceNumber;
            DateSubmited = dateSubmited;
            DateSertified = dateSertified;
            Template = template;
        }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> results = new List<ValidationResult>();

            if (Guid == Guid.Empty)
            {
                results.Add(new ValidationResult("Guid cannot be empty."));
            }

            if (publicBidding == null)
                results.Add(new ValidationResult("Public bidding cannot be null.", new[] { nameof(publicBidding) }));

            if (documentType == null)
                results.Add(new ValidationResult("Document type cannot be null.", new[] { nameof(documentType) }));

            if (string.IsNullOrWhiteSpace(ReferenceNumber))
                results.Add(new ValidationResult("ReferenceNumber cannot be empty or whitespace.", new[] { nameof(ReferenceNumber) }));

            if (DateSubmited == null)
                results.Add(new ValidationResult("Date submissed cannot be null.", new[] { nameof(DateSubmited) }));

            if (DateSertified == null)
                results.Add(new ValidationResult("Date sertified cannot be null.", new[] { nameof(DateSertified) }));

            if (string.IsNullOrWhiteSpace(Template))
                results.Add(new ValidationResult("Template cannot be empty or whitespace.", new[] { nameof(Template) }));

            return results;
        }
    }
}
