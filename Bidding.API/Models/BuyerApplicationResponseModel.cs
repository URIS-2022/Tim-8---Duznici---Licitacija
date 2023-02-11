using Bidding.API.Entities;
using Bidding.API.Enums;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Bidding.API.Models
{

    [DataContract(Name = "BuyerApplication", Namespace = "")]
    public class BuyerApplicationResponseModel
    {

        

        [DataMember]
        public Representative RepresentativeGuid { get; set; }

        [DataMember]
        public int Amount { get; set; }

        [DataMember]
        public Representative representative { get; set; }

        public BuyerApplicationResponseModel( Representative representativeGuid, int amount, Representative representative)
        {
            
            RepresentativeGuid = representativeGuid;
            Amount = amount;
            this.representative = representative;
        }
    }
}
