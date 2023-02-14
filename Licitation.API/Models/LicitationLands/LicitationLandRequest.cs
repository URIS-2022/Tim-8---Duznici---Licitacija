using Licitation.API.Entities;

namespace Licitation.API.Models.LicitationLands;

public class LicitationLandRequest
{
    public Guid LandGuid { get; set; }


    public LicitationLandRequest(Guid landGuid)
    {
        LandGuid = landGuid;
    }
}
