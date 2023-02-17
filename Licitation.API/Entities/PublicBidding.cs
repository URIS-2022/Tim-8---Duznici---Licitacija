using System.ComponentModel.DataAnnotations;

namespace Licitation.API.Entities;

public class PublicBidding : IValidatableObject
{

    public Guid PublicBiddingGuid { get; set; }
    public Guid LicitationGuid { get; set; }

    public Licitation licitation { get; set; }

    public PublicBidding()
    {

    }
    public PublicBidding(Guid publicBiddingGuid, Guid licitation)
    {
        PublicBiddingGuid= publicBiddingGuid;
        LicitationGuid= licitation;
    }
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
