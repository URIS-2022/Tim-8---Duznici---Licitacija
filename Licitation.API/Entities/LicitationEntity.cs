using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Licitation.API.Entities;

public partial class LicitationEntity : IValidatableObject
{
    public Guid Guid { get; set; }
    public int Stage { get; set; }
    public DateTime Date { get; set; }
    public int Year { get; set; }
    public int Constarint { get; set; }
    public int BidIncrement { get; set; }
    public DateTime ApplicationDeadline { get; set; }
    public List<Guid> LandGuids { get; set; }
    public List<Guid> PublicBiddingGuids { get; set; }
    public List<LicitationLand> LicitationLands { get; set; }
    public List<LicitationPublicBidding> LicitationPublicBiddings { get; set; }
    public ICollection<Document> Documents { get; set; }

    //public LicitationLand LicitationLand { get; set; }
    //public LicitationPublicBidding LicitationPublicBidding { get; set; }
    //public ICollection<Document> Documents { get; set; }

    public LicitationEntity()
    { 
    }

    public LicitationEntity(Guid licitationGuid, int stage, DateTime date, int year, int constraint, int bidIncrement, DateTime applicationDeadline, List<Guid> landGuids, List<Guid> publicBiddingGuids)
    {
        Guid = licitationGuid;
        Stage = stage;
        Date = date;
        Year = year;
        Constarint = constraint;
        BidIncrement = bidIncrement;
        ApplicationDeadline = applicationDeadline;
        LandGuids = landGuids;
        PublicBiddingGuids = publicBiddingGuids;

    }

    public LicitationEntity(int stage, DateTime date, int year, int constraint, int bidIncrement, DateTime applicationDeadline, List<Guid> landGuids, List<Guid> publicBiddingGuids)
    {
        Guid = Guid.NewGuid();
        Stage = stage;
        Date = date;
        Year = year;
        Constarint = constraint;
        BidIncrement = bidIncrement;
        ApplicationDeadline = applicationDeadline;
        LandGuids = landGuids;
        PublicBiddingGuids = publicBiddingGuids;
    }
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var results = new List<ValidationResult>();

        if (Guid == Guid.Empty)
        {
            results.Add(new ValidationResult("LicitationGuid cannot be empty."));
        }

        if (Stage <= 0)
        {
            results.Add(new ValidationResult("Stage must be greater than 0."));
        }

        if (Year <= 0)
        {
            results.Add(new ValidationResult("Year must be greater than 0."));
        }

        if (Constarint <= 0)
        {
            results.Add(new ValidationResult("Constarint must be greater than 0."));
        }

        if (BidIncrement <= 0)
        {
            results.Add(new ValidationResult("BidIncrement must be greater than 0."));
        }

        if (Date < DateTime.Now)
        {
            results.Add(new ValidationResult("Date cannot be in the past"));
        }

        if (ApplicationDeadline > Date)
        {
            results.Add(new ValidationResult("ApplicationDeadline cannot be after Date."));
        }

        return results;
    }
 }

