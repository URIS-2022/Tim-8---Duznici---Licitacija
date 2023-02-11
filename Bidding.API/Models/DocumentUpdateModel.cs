using Bidding.API.Entities;
using Bidding.API.Enums;
using System.Text.Json.Serialization;


namespace Bidding.API.Models
{
    public class DocumentUpdateModel
    {
        
        public PublicBidding publicBidding { get; set; }
        [JsonConverter(typeof(DocumentTypeConverter))]
        public DocumentType? documentType { get; set; }
        public string? ReferenceNumber { get; set; }

        public DateTime? DateSubmited { get; set; }

        public DateTime? DateSertified { get; set; }

        public string? Template { get; set; }

        public DocumentUpdateModel(PublicBidding publicBidding, DocumentType? documentType, string? referenceNumber, DateTime? dateSubmited, DateTime? dateSertified, string? template)
        {
            
            this.publicBidding = publicBidding;
            this.documentType = documentType;
            ReferenceNumber = referenceNumber;
            DateSubmited = dateSubmited;
            DateSertified = dateSertified;
            Template = template;
        }
    }
}
