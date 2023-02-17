using System.Runtime.Serialization;

namespace Licitation.API.Models.Licitation;

[DataContract(Name = "PublicBidding", Namespace = "")]
public class LicitationPublicBiddingLicitationResponseModel
{
    [DataMember]
    public Guid Guid { get; set; }

}
