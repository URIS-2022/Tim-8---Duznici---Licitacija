using Bidding.API.Entities;
using Bidding.API.Enums;
using System.Text.Json.Serialization;


namespace Bidding.API.Models
{
    public class DocumentRequestModel
    {
        public Guid Guid { get; set; }
        public Guid PublicBiddingGuid { get; set; }
        [JsonConverter(typeof(DocumentTypeConverter))]
        public DocumentType documentType { get; set; }
        public string ReferenceNumber { get; set; }

        public DateTime DateSubmited { get; set; }

        public DateTime DateSertified { get; set; }
        public string Template { get; set; }

        public DocumentRequestModel() { }

        public DocumentRequestModel(Guid guid,Guid publicBidding, DocumentType documentType, string referenceNumber,string template)
        {
            Guid = guid;
            this.PublicBiddingGuid = publicBidding;
            this.documentType = documentType;
            ReferenceNumber = referenceNumber; // U entitetu dokument popraviti svuda da reference number bude string a ne int
            Template = template;
        }
    }
}
