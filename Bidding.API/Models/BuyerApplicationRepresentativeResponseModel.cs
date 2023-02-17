using Bidding.API.Entities;
using Bidding.API.Enums;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace Bidding.API.Models
{
    [DataContract(Name = "BuyerApplicationRepresentative", Namespace = "")]
    public class BuyerApplicationRepresentativeResponseModel
    {
        [DataMember]
        public Guid Guid { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string IdentificationNumber { get; set; }
        [DataMember]
        public Guid AdressGuid { get; set; }

        [DataMember]

        public int NumberOfBoard { get; set; }

        [DataMember]
        public Guid PublicBiddingGuid { get; set; }
    }
}
