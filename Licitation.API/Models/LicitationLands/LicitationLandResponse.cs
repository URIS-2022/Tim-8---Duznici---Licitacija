﻿using System.Runtime.Serialization;

namespace Licitation.API.Models.LicitationLands;

[DataContract(Name = "LicitationLand", Namespace = "")]
public class LicitationLandResponse
{
    [DataMember]
    public Guid LandGuid { get; set; }

    public LicitationLandResponse(Guid landGuid)
    {
        LandGuid = landGuid;
    }
}
