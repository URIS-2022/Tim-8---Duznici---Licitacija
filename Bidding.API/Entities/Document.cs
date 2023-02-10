using Bidding.API.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;


namespace Bidding.API.Entities
{
    public partial class Document : IValidatableObject
    {
       
        public Guid DocumentGuid { get; set; }
        public PublicBidding publicBidding { get; set; }
        [JsonConverter(typeof(DocumentTypeConverter))]
        public DocumentType documentType { get; set; }
        public int ReferenceNumber { get; set; }

        public DateOnly DateSubmissed { get; set; }

        public DateOnly DateSertified { get; set; }

        public string Template { get; set; }


        public Document(Guid id,PublicBidding publicBidding, DocumentType documentType, int referenceNumber, DateOnly dateSubmissed, DateOnly dateSertified, string template)
        {
            DocumentGuid = id;
            this.publicBidding = publicBidding;
            this.documentType = documentType;
            ReferenceNumber = referenceNumber;
            DateSubmissed = dateSubmissed;
            DateSertified = dateSertified;
            Template = template;
        }



        public Document(PublicBidding publicBidding, DocumentType documentType, int referenceNumber, DateOnly dateSubmissed, DateOnly dateSertified, string template)
        {
            DocumentGuid = Guid.NewGuid();
            this.publicBidding = publicBidding;
            this.documentType = documentType;
            ReferenceNumber = referenceNumber;
            DateSubmissed = dateSubmissed;
            DateSertified = dateSertified;
            Template = template;
        }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> results = new List<ValidationResult>();

            if (DocumentGuid == Guid.Empty)
            {
                results.Add(new ValidationResult("Guid cannot be empty."));
            }

            if (publicBidding == null)
                results.Add(new ValidationResult("Public bidding cannot be null.", new[] { nameof(publicBidding) }));

            if (documentType == null)
                results.Add(new ValidationResult("Document type cannot be null.", new[] { nameof(documentType) }));

            if (ReferenceNumber <= 0)
                results.Add(new ValidationResult("Reference number must be greater than zero.", new[] { nameof(ReferenceNumber) }));

            if (DateSubmissed == null)
                results.Add(new ValidationResult("Date submissed cannot be null.", new[] { nameof(DateSubmissed) }));

            if (DateSertified == null)
                results.Add(new ValidationResult("Date sertified cannot be null.", new[] { nameof(DateSertified) }));

            if (string.IsNullOrWhiteSpace(Template))
                results.Add(new ValidationResult("Template cannot be empty or whitespace.", new[] { nameof(Template) }));

            return results;
        }
    }
}
