namespace Licitation.API.Models.LicitationLands;

/**
Represents a request model for posting a new licitation land.
*/
public class LicitationLandRequest
{
    /// <summary>
    /// The unique identifier of the LICITATION.
    /// </summary>
    public Guid LandGuid { get; set; }

    /// <summary>
    /// The representing constructor.
    /// </summary>
    public LicitationLandRequest(Guid landGuid)
    {
        LandGuid = landGuid;
    }
}
