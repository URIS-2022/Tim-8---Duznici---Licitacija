using System.ComponentModel.DataAnnotations;

namespace Licitation.API.Entities;

/// <summary>
/// Represents a public land auction (licitation) with its properties and associated entities.
/// </summary>
public partial class Licitation : IValidatableObject
{
    /// <summary>
    /// Gets or sets the unique identifier of the licitation.
    /// </summary>
    public Guid Guid { get; set; }

    /// <summary>
    /// Gets or sets the stage number of the licitation.
    /// </summary>
    public int Stage { get; set; }

    /// <summary>
    /// Gets or sets the date of the licitation.
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Gets or sets the year of the licitation.
    /// </summary>
    public int Year { get; set; }

    /// <summary>
    /// Gets or sets the constraint of the licitation.
    /// </summary>
    public int Constarint { get; set; }

    /// <summary>
    /// Gets or sets the bid increment of the licitation.
    /// </summary>
    public int BidIncrement { get; set; }

    /// <summary>
    /// Gets or sets the application deadline of the licitation.
    /// </summary>
    public DateTime ApplicationDeadline { get; set; }

    /// <summary>
    /// Gets or sets the lands associated with the licitation.
    /// </summary>
    public IEnumerable<LicitationLand>? Lands { get; set; }

    /// <summary>
    /// Gets or sets the public biddings associated with the licitation.
    /// </summary>
    public IEnumerable<PublicBidding>? LicitationPublicBiddings { get; set; }

    /// <summary>
    /// Gets or sets the lands associated with the licitation.
    /// </summary>
    public List<LicitationLand>? LicitationLands { get; set; }

    /// <summary>
    /// Gets or sets the public biddings associated with the licitation.
    /// </summary>
    public List<PublicBidding>? PublicBiddings { get; set; }

    /// <summary>
    /// Gets or sets the documents associated with the licitation.
    /// </summary>
    public List<Document>? Documents { get; set; }


    /// <summary>
    /// Initializes a new instance of the <see cref="Licitation"/> class.
    /// </summary>
    public Licitation()
    {
        Lands = new HashSet<LicitationLand>();
        LicitationPublicBiddings = new HashSet<PublicBidding>();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Licitation"/> class with the specified parameters.
    /// </summary>
    /// <param name="licitationGuid">The unique identifier of the licitation.</param>
    /// <param name="stage">The stage of the licitation.</param>
    /// <param name="date">The date of the licitation.</param>
    /// <param name="year">The year of the licitation.</param>
    /// <param name="constraint">The constraint of the licitation.</param>
    /// <param name="bidIncrement">The bid increment of the licitation.</param>
    /// <param name="applicationDeadline">The application deadline of the licitation.</param>
    /// <param name="licitationLands">The collection of licitation lands associated with the licitation.</param>
    /// <param name="licitationPublicBiddings">The collection of public biddings associated with the licitation.</param>
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
    /// <summary>
    /// Initializes a new instance of the <see cref="Licitation"/> class with the specified parameters.
    /// </summary>
    /// <param name="stage">The stage of the licitation.</param>
    /// <param name="date">The date of the licitation.</param>
    /// <param name="year">The year of the licitation.</param>
    /// <param name="constraint">The constraint of the licitation.</param>
    /// <param name="bidIncrement">The bid increment of the licitation.</param>
    /// <param name="applicationDeadline">The application deadline of the licitation.</param>
    /// <param name="licitationLands">The collection of licitation lands associated with the licitation.</param>
    /// <param name="licitationPublicBiddings">The collection of public biddings associated with the licitation.</param>
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

    /// <summary>
    /// Validates the current instance of the Licitation class according to the specified rules.
    /// </summary>
    /// <param name="validationContext">The validation context.</param>
    /// <returns>A collection of ValidationResult objects that contain any validation errors. The collection is empty if the object is valid.</returns>
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

