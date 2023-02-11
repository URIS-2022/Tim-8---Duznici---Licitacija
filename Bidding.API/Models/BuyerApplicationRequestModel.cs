using Bidding.API.Entities;
using Bidding.API.Enums;
using System.Text.Json.Serialization;



namespace Bidding.API.Models
{
    public class BuyerApplicationRequestModel
    {
       

        public Representative RepresentativeGuid { get; set; }

        public int Amount { get; set; }

        public Representative representative { get; set; }


        public BuyerApplicationRequestModel( Representative representativeGuid, int amount,Representative representative)
        {
            
            RepresentativeGuid = representativeGuid;
            Amount = amount;
            this.representative = representative;
        }
    }
}
