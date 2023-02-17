using System.ComponentModel.DataAnnotations;

namespace Licitation.API.Entities;

public partial class Licitation : IValidatableObject
{
    public Guid Guid { get; set; }
    public int Stage { get; set; }
    public DateTime Date { get; set; }
    public int Year { get; set; }
    public int Constarint { get; set; }
    public int BidIncrement { get; set; }
    public DateTime ApplicationDeadline { get; set; }
    public IEnumerable<LicitationLand> Lands { get; set; }
    public IEnumerable<PublicBidding> LicitationPublicBiddings { get; set; }

    public List<LicitationLand> LicitationLands { get; set; }
    public List<PublicBidding> PublicBiddings { get; set; }
    public List<Document> Documents { get; set; }

 
    public Licitation()
    {
        Lands =  new HashSet<LicitationLand>();
        LicitationPublicBiddings = new HashSet<PublicBidding>();
    }

    public Licitation(Guid licitationGuid, int stage, DateTime date, int year, int constraint, int bidIncrement, DateTime applicationDeadline, ICollection<LicitationLand>? licitationLands = null, ICollection<PublicBidding>? licitationPublicBiddings = null)
    {
        Guid = licitationGuid;
        Stage = stage;
        Date = date;
        Year = year;
        Constarint = constraint;
        BidIncrement = bidIncrement;
        ApplicationDeadline = applicationDeadline;
        Lands = licitationLands ?? new HashSet<LicitationLand>();
        LicitationPublicBiddings = licitationPublicBiddings ?? new HashSet<PublicBidding>();

    }

    public Licitation(int stage, DateTime date, int year, int constraint, int bidIncrement, DateTime applicationDeadline, ICollection<LicitationLand>? licitationLands = null, ICollection<PublicBidding>? licitationPublicBiddings = null)
    {
        Guid = Guid.NewGuid();
        Stage = stage;
        Date = date;
        Year = year;
        Constarint = constraint;
        BidIncrement = bidIncrement;
        ApplicationDeadline = applicationDeadline;
        Lands = licitationLands ?? new HashSet<LicitationLand>();
        LicitationPublicBiddings = licitationPublicBiddings ?? new HashSet<PublicBidding>();
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

