using Bidding.API.Entities;
using Bidding.API.Enums;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Bidding.API.Models
{
    public class BuyerApplicationUpdateModel
    {
        

        
        public Representative RepresentativeGuid { get; set; }

        
        public int? Amount { get; set; }

        
        

        public BuyerApplicationUpdateModel(Representative representativeGuid, int amount)
        {
            
            RepresentativeGuid = representativeGuid;
            Amount = amount;
            
        }
    }
}
