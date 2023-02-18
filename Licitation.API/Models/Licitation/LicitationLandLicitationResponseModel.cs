using System.Runtime.Serialization;

namespace Licitation.API.Models.Licitation;

/**
Represents a response model for posting a new licitation land.
*/
[DataContract(Name = "LicitationLand", Namespace = "")]
public class LicitationLandLicitationResponseModel
{
    /// <summary>
    /// The unique identifier of the LICITATION.
    /// </summary>
    [DataMember]
    public Guid Guid { get; set; }

}
