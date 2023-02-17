using System.Runtime.Serialization;

namespace Bidding.API.Models
{

    [DataContract(Name = "BuyerApplication", Namespace = "")]
    public class RepresentativeBuyerApplicationResponseModel
    {
        [DataMember]
        public Guid Guid { get; set; }


        

        [DataMember]
        public int Amount { get; set; }
    }
}
