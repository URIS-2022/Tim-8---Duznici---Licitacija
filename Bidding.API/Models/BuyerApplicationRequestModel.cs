using Bidding.API.Entities;
using Bidding.API.Enums;
using System.Text.Json.Serialization;



namespace Bidding.API.Models
{
    public class BuyerApplicationRequestModel
    {

        public Guid Guid { get; set; }
        public Guid RepresentativeGuid { get; set; }

        public int Amount { get; set; }

        // public Guid representative { get; set; }

        public BuyerApplicationRequestModel() { }
        public BuyerApplicationRequestModel( Guid representativeGuid, int amount)
        {
            
            RepresentativeGuid = representativeGuid;
            Amount = amount;
           // this.representative = representative;
        }
    }
}
