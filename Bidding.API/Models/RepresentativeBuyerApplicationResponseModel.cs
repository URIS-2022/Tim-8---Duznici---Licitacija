using Bidding.API.Entities;
using Bidding.API.Enums;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

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
