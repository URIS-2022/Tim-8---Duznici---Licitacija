using System.Runtime.Serialization;

namespace Licitation.API.Models.Licitation;


/**
Represents a response model for posting a new licitation land.
*/
[DataContract(Name = "PublicBidding", Namespace = "")]
public class LicitationPublicBiddingLicitationResponseModel
{
    /// <summary>
    /// The unique identifier of the LICITATION.
    /// </summary>
    [DataMember]
    public Guid Guid { get; set; }

}
