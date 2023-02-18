using System.Runtime.Serialization;

namespace Bidding.API.Models
{

    [DataContract(Name = "BuyerApplication", Namespace = "")]
    public class BuyerApplicationResponseModel
    {
        [DataMember]
        public Guid Guid { get; set; }

        [DataMember]
        public Guid RepresentativeGuid { get; set; }

        [DataMember]
        public int Amount { get; set; }

        [DataMember]
        public BuyerApplicationRepresentativeResponseModel representative { get; set; }

        public BuyerApplicationResponseModel() { }

        public BuyerApplicationResponseModel(Guid representativeGuid, int amount, BuyerApplicationRepresentativeResponseModel representative)
        {

            RepresentativeGuid = representativeGuid;
            Amount = amount;
            this.representative = representative;

        }
    }
}
