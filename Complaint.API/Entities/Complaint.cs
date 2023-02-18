using Complaint.API.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Complaint.API.Entities;

/// <summary>
/// Represents a complaint
/// </summary>
public class Complaint : IValidatableObject
{
    /// <summary>
    /// Unique identifier for the complaint
    /// </summary>
    [Key]
    public Guid Guid { get; set; }

    /// <summary>
    /// Type of the complaint
    /// </summary>
    [JsonConverter(typeof(ComplaintTypeConverter))]
    public ComplaintType Type { get; set; }

    /// <summary>
    /// Date the complaint was submitted
    /// </summary>
    public DateTime DateSubmitted { get; set; }

    /// <summary>
    /// Guid of the buyer
    /// </summary>
    public Guid BuyerGuid { get; set; }

    /// <summary>
    /// Reason for the complaint
    /// </summary>
    public string Reason { get; set; }

    /// <summary>
    /// Rationale for the complaint
    /// </summary>
    public string Rationale { get; set; }

    /// <summary>
    /// Date the complaint was resolved
    /// </summary>
    public DateTime ResolutionDate { get; set; }

    /// <summary>
    /// Resolution code for the complaint
    /// </summary>
    public string ResolutionCode { get; set; }

    /// <summary>
    /// Status of the complaint
    /// </summary>
    [JsonConverter(typeof(ComplaintStatusConverter))]
    public ComplaintStatus Status { get; set; }

    /// <summary>
    /// Guid of the subject of the complaint
    /// </summary>
    public Guid SubjectGuid { get; set; }

    /// <summary>
    /// Action taken for the complaint
    /// </summary>
    [JsonConverter(typeof(ComplaintActionConverter))]
    public ComplaintAction Action { get; set; }

    /// <summary>
    /// Constructor for Complaint
    /// </summary>
    public Complaint(ComplaintType type, DateTime dateSubmitted, Guid buyerGuid, string reason, string rationale,
    DateTime resolutionDate, string resolutionCode, ComplaintStatus status, Guid subjectGuid, ComplaintAction action, Guid? guid = null)
    {
        Guid = guid ?? Guid.NewGuid();
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

    /// <summary>
    /// Validates the complaint
    /// </summary>
    /// <param name="validationContext"> ValidationContext for the complaint</param>
    /// <returns> IEnumerable of ValidationResult</returns>
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        List<ValidationResult> results = new();

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
