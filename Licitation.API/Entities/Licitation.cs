using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Licitation.API.Entities;

public partial class Licitation : IValidatableObject
{
    public Guid LicitationGuid { get; set; }
    public int Stage { get; set; }
    public DateTime Date { get; set; }
    public int Year { get; set; }
    public int Constarint { get; set; }
    public int BidIncrement { get; set; }
    public DateTime ApplicationDeadline { get; set; }

    public Licitation(Guid licitationGuid, int stage, DateTime date, int year, int constraint, int bidIncrement, DateTime applicationDeadline)
    {
        LicitationGuid = licitationGuid;
        Stage = stage;
        Date = date;
        Year = year;
        Constarint = constraint;
        BidIncrement = bidIncrement;
        ApplicationDeadline = applicationDeadline;

    }

    public Licitation(int stage, DateTime date, int year, int constraint, int bidIncrement, DateTime applicationDeadline)
    {
        LicitationGuid = Guid.NewGuid();
        Stage = stage;
        Date = date;
        Year = year;
        Constarint = constraint;
        BidIncrement = bidIncrement;
        ApplicationDeadline = applicationDeadline;
    }
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var results = new List<ValidationResult>();

        if (LicitationGuid == Guid.Empty)
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

        if (ApplicationDeadline > Date)
        {
            results.Add(new ValidationResult("ApplicationDeadline cannot be greater than Date."));
        }

        return results;
    }
 }

