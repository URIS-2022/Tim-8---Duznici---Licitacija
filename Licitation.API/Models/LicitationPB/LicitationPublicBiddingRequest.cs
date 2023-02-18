namespace Licitation.API.Models.LicitationPB;

/**
Represents a request model for posting a new licitation land.
*/
public class LicitationPublicBiddingRequest
{
    /// <summary>
    /// The unique identifier of the public bidding.
    /// </summary>
    public Guid PublicBiddingGuid { get; set; }

    /// <summary>
    /// The representing constructor.
    /// </summary>
    public LicitationPublicBiddingRequest(Guid publicBiddingGuid)
    {
        PublicBiddingGuid = publicBiddingGuid;
    }
}
