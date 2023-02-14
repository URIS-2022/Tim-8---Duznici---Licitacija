using System.ComponentModel.DataAnnotations;

namespace Licitation.API.Entities;

public class LicitationPublicBidding : IValidatableObject
{

    public Guid PublicBiddingGuid { get; set; }
    public Guid Licitation { get; set; }

    //public Entities.Licitation licitationEntity { get; set; }

    //public object LicitationEntity { get; internal set; }

    //public object LicitationEntity { get; internal set; }

    public LicitationPublicBidding()
    {

    }
    public LicitationPublicBidding(Guid publicBiddingGuid, Guid licitation)
    {
        PublicBiddingGuid= publicBiddingGuid;
        Licitation= licitation;
    }
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var results = new List<ValidationResult>();

        if (PublicBiddingGuid == Guid.Empty)
        {
            results.Add(new ValidationResult("PublicBiddingGuid cannot be empty."));
        }

        if (Licitation == Guid.Empty)
        {
            results.Add(new ValidationResult("LicitationGuid cannot be empty."));
        }

        return results;
    }
}
