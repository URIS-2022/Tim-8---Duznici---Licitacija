using Bidding.API.Entities;
using Bidding.API.Enums;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace Bidding.API.Models

{

    [DataContract(Name = "Document", Namespace = "")]
    public class DocumentResponseModel
    {
        [DataMember]
       public  Guid Guid { get; set; }

        [DataMember]
        public Guid PublicBiddingGuid { get; set; }
        [JsonConverter(typeof(DocumentTypeConverter))]

        [DataMember(Name ="documentType")]
        public DocumentType documentType { get; set; }

        [DataMember]
        public string ReferenceNumber { get; set; }

        [DataMember]

        public DateTime DateSubmited { get; set; } 

        [DataMember]
        public DateTime DateSertified { get; set; }

        [DataMember]
        public string Template { get; set; }

        public DocumentResponseModel() { }

        public DocumentResponseModel(Guid guid,Guid publicBidding, DocumentType documentType, string referenceNumber, DateTime dateSubmited, DateTime dateSertified, string template)
        {
            Guid = guid;
            this.PublicBiddingGuid = publicBidding;
            this.documentType = documentType;
            ReferenceNumber = referenceNumber;
            DateSubmited = dateSubmited;
            DateSertified = dateSertified;
            Template = template;
        }



    }
}
