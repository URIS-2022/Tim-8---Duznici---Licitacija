using System.ComponentModel.DataAnnotations;

namespace Licitation.API.Entities;
public partial class LicitationLand : IValidatableObject
{
    public Guid Licitation { get; set; }
    public Guid LandGuid { get; set; }

    public LicitationLand(Guid licitation, Guid landGuid)
    {
        Licitation = licitation;
        LandGuid = landGuid;
    }
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var results = new List<ValidationResult>();

        if (Licitation == Guid.Empty)
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
