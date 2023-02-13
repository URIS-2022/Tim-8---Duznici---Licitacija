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
        public Guid RepresentativeGuid { get; set; }

        [DataMember]
        public int Amount { get; set; }

        [DataMember]
        public Representative representative { get; set; }

        public BuyerApplicationResponseModel() { }

        public BuyerApplicationResponseModel( Guid representativeGuid, int amount, Representative representative)
        {
            
            RepresentativeGuid = representativeGuid;
            Amount = amount;
            this.representative = representative;
        }
    }
}
