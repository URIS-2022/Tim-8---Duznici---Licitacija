namespace Bidding.API.Models
{
    public class BuyerApplicationUpdateModel
    {


       
        public Guid RepresentativeGuid { get; set; }

        
        public int? Amount { get; set; }

        public BuyerApplicationUpdateModel() { }


        public BuyerApplicationUpdateModel(Guid representativeGuid, int amount)
        {
            
            RepresentativeGuid = representativeGuid;
            Amount = amount;
            
        }
    }
}
