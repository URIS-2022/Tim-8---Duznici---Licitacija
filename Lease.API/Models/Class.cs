using System.Runtime.Serialization;

namespace Lease.API.Models
{
    [DataContract(Name = "Document", Namespace = "")]
    public class MQRecievingMessageModel
    {
        [DataMember]
        public Guid BestBuyerGuid { get ; set; }

        [DataMember]
        public Guid BiddingGuid { get; set; }
        

    }
}
