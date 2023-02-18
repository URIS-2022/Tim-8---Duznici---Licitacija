using System.Runtime.Serialization;

namespace Licitation.API.Models.LicitationPBResponse;

/**
Represents a response model licitation public vidding.
*/
[DataContract(Name = "PublicBidding", Namespace = "")]
public class LicitationPublicBiddingResponse
{
    /// <summary>
    /// The unique identifier of the public bidding.
    /// </summary>
    [DataMember]
    public Guid PublicBiddingGuid { get; set; }

    /// <summary>
    /// The representing constructor.
    /// </summary>
    public LicitationPublicBiddingResponse(Guid publicBiddingGuid)
    {
        PublicBiddingGuid = publicBiddingGuid;
    }
}
