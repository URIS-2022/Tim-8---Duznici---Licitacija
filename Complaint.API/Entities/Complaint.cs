using Complaint.API.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Complaint.API.Entities;

public class Complaint : IValidatableObject
{
    [Key]
    public Guid Guid { get; set; }
    [JsonConverter(typeof(ComplaintTypeConverter))]
    public ComplaintType Type { get; set; }
    public DateTime DateSubmitted { get; set; }
    public Guid BuyerGuid { get; set; }
    public string Reason { get; set; }
    public string Rationale { get; set; }
    public DateTime ResolutionDate { get; set; }
    public string ResolutionCode { get; set; }
    [JsonConverter(typeof(ComplaintStatusConverter))]
    public ComplaintStatus Status { get; set; }
    public Guid SubjectGuid { get; set; }
    [JsonConverter(typeof(ComplaintActionConverter))]
    public ComplaintAction Action { get; set; }

    public Complaint(Guid guid, ComplaintType type, DateTime dateSubmitted, Guid buyerGuid, string reason, string rationale,
    DateTime resolutionDate, string resolutionCode, ComplaintStatus status, Guid subjectGuid, ComplaintAction action)
    {
        Guid = guid;
        Type = type;
        DateSubmitted = dateSubmitted;
        BuyerGuid = buyerGuid;
        Reason = reason;
        Rationale = rationale;
        ResolutionDate = resolutionDate;
        ResolutionCode = resolutionCode;
        Status = status;
        SubjectGuid = subjectGuid;
        Action = action;
    }

    public Complaint(ComplaintType type, DateTime dateSubmitted, Guid buyerGuid, string reason, string rationale,
    DateTime resolutionDate, string resolutionCode, ComplaintStatus status, Guid subjectGuid, ComplaintAction action)
    {
        Guid = Guid.NewGuid();
        Type = type;
        DateSubmitted = dateSubmitted;
        BuyerGuid = buyerGuid;
        Reason = reason;
        Rationale = rationale;
        ResolutionDate = resolutionDate;
        ResolutionCode = resolutionCode;
        Status = status;
        SubjectGuid = subjectGuid;
        Action = action;
    }


    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        List<ValidationResult> results = new List<ValidationResult>();

        if (DateSubmitted > DateTime.Now)
        {
            results.Add(new ValidationResult("Date Submitted cannot be in the future.", new[] { nameof(DateSubmitted) }));
        }

        if (ResolutionDate < DateSubmitted)
        {
            results.Add(new ValidationResult("Resolution Date cannot be before Date Submitted.", new[] { nameof(ResolutionDate) }));
        }

        if (string.IsNullOrWhiteSpace(Reason))
        {
            results.Add(new ValidationResult("Reason cannot be empty.", new[] { nameof(Reason) }));
        }

        if (string.IsNullOrWhiteSpace(Rationale))
        {
            results.Add(new ValidationResult("Rationale cannot be empty.", new[] { nameof(Rationale) }));
        }

        if (string.IsNullOrWhiteSpace(ResolutionCode))
        {
            results.Add(new ValidationResult("Resolution Code cannot be empty.", new[] { nameof(ResolutionCode) }));
        }

        return results;
    }

}
