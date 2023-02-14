using System.ComponentModel.DataAnnotations;

namespace Licitation.API.Entities;
public partial class LicitationLand : IValidatableObject
{
     internal object licitationEntity { get; set; }

    public Guid LicitationGuid { get; set; }
    public Guid LandGuid { get; set; }
    public object Licitation { get; internal set; }
    public object Licitations { get; internal set; }

    //public LicitationEntity licitationEntity { get; set; }
    //public object LicitationEntities { get; internal set; }
    //public object Licitation { get; set; }
    //public object Land { get; internal set; }

    //public object LicitationEntities { get; internal set; }

    public LicitationLand()
    {

    }

    public LicitationLand(Guid licitation, Guid landGuid)
    {
        LicitationGuid = licitation;
        LandGuid = landGuid;
    }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var results = new List<ValidationResult>();

        if (LicitationGuid == Guid.Empty)
        {
            results.Add(new ValidationResult("LicitationGuid cannot be empty."));
        }

        if (LandGuid == Guid.Empty)
        {
            results.Add(new ValidationResult("LandGuid cannot be empty."));
        }

        return results;
    }
}
