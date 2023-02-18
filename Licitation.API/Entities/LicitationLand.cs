using System.ComponentModel.DataAnnotations;

namespace Licitation.API.Entities;
/// <summary>
/// Represents a piece of land associated with a licitation.
/// </summary>
public partial class LicitationLand : IValidatableObject
{

    /// <summary>
    /// Gets or sets the unique identifier of the associated Licitation.
    /// </summary>
    public Guid LicitationGuid { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the associated Land.
    /// </summary>
    public Guid LandGuid { get; set; }

    /// <summary>
    /// Gets or sets the Licitation object associated with the current instance of LicitationLand.
    /// </summary>
    public Licitation? licitation { get; set; }

    /// <summary>
    /// Initializes a new instance of the LicitationLand class.
    /// </summary>
    public LicitationLand()
    {

    }
    /// <summary>
    /// Initializes a new instance of the LicitationLand class with the specified Licitation and Land identifiers.
    /// </summary>
    /// <param name="licitation">The unique identifier of the associated Licitation.</param>
    /// <param name="landGuid">The unique identifier of the associated Land.</param>
    public LicitationLand(Guid licitation, Guid landGuid)
    {
        LicitationGuid = licitation;
        LandGuid = landGuid;
    }
    /// <summary>
    /// Validates the current instance of the LicitationLand class according to the specified rules.
    /// </summary>
    /// <param name="validationContext">The validation context.</param>
    /// <returns>A collection of ValidationResult objects that contain any validation errors. The collection is empty if the object is valid.</returns>
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
