namespace Licitation.API.Models.LicitationPB;

public class LicitationPublicBiddingRequest
{
    public Guid PublicBiddingGuid { get; set; }

    public LicitationPublicBiddingRequest(Guid publicBiddingGuid)
    {
        PublicBiddingGuid = publicBiddingGuid;
    }
}
