using System.Runtime.Serialization;

namespace Licitation.API.Models.Licitation;

[DataContract(Name = "LicitationLand", Namespace = "")]
public class LicitationLandLicitationResponseModel
{
    [DataMember]
    public Guid Guid { get; set; }

}
