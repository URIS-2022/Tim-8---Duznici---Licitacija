using System.ComponentModel.DataAnnotations;

namespace Licitation.API.Entities;


/// <summary>
/// Represents a public bidding related to a licitation.
/// </summary>
public class PublicBidding : IValidatableObject
{
    /// <summary>
    /// Gets or sets the unique identifier of the public bidding.
    /// </summary>
    public Guid PublicBiddingGuid { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the licitation related to the public bidding.
    /// </summary>
    public Guid LicitationGuid { get; set; }

    /// <summary>
    /// Gets or sets the licitation related to the public bidding.
    /// </summary>
    public Licitation licitation { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="PublicBidding"/> class.
    /// </summary>
    public PublicBidding()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PublicBidding"/> class with the specified public bidding and licitation identifiers.
    /// </summary>
    /// <param name="publicBiddingGuid">The unique identifier of the public bidding.</param>
    /// <param name="licitation">The unique identifier of the licitation related to the public bidding.</param>
    public PublicBidding(Guid publicBiddingGuid, Guid licitation)
    {
        PublicBiddingGuid = publicBiddingGuid;
        LicitationGuid = licitation;
    }

    /// <summary>
    /// Validates the current <see cref="PublicBidding"/> instance.
    /// </summary>
    /// <param name="validationContext">The validation context.</param>
    /// <returns>A collection of validation results.</returns>
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var results = new List<ValidationResult>();

        if (PublicBiddingGuid == Guid.Empty)
        {
            results.Add(new ValidationResult("PublicBiddingGuid cannot be empty."));
        }

        if (LicitationGuid == Guid.Empty)
        {
            results.Add(new ValidationResult("LicitationGuid cannot be empty."));
        }

        return results;
    }
}

