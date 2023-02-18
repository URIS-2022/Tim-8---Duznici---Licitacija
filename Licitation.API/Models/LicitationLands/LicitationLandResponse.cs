using System.Runtime.Serialization;

namespace Licitation.API.Models.LicitationLands;

/**
Represents a response model for posting a new licitation land.
*/
[DataContract(Name = "LicitationLand", Namespace = "")]
public class LicitationLandResponse
{
    /// <summary>
    /// The unique identifier of the LICITATION.
    /// </summary>
    [DataMember]
    public Guid LandGuid { get; set; }

    /// <summary>
    /// The representing constructor.
    /// </summary>
    public LicitationLandResponse(Guid landGuid)
    {
        LandGuid = landGuid;
    }
}
