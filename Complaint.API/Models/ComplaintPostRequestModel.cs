using Complaint.API.Enums;
using System.Text.Json.Serialization;

namespace Complaint.API.Models;

/// <summary>
/// Post request model for a complaint
/// </summary>
public class ComplaintPostRequestModel
{
    /// <summary>
    /// The type of complaint
    /// </summary>
    [JsonConverter(typeof(ComplaintTypeConverter))]
    public ComplaintType Type { get; set; }

    /// <summary>
    /// The date the complaint was submitted
    /// </summary>
    public DateTime DateSubmitted { get; set; }

    /// <summary>
    /// The unique identifier of the buyer
    /// </summary>
    public Guid BuyerGuid { get; set; }

    /// <summary>
    /// The reason for the complaint
    /// </summary>
    public string Reason { get; set; }

    /// <summary>
    /// The rationale for the complaint
    /// </summary>
    public string Rationale { get; set; }

    /// <summary>
    /// The date the complaint was resolved
    /// </summary>
    public DateTime ResolutionDate { get; set; }

    /// <summary>
    /// The resolution code for the complaint
    /// </summary>
    public string ResolutionCode { get; set; }

    /// <summary>
    /// The status of the complaint
    /// </summary>
    [JsonConverter(typeof(ComplaintStatusConverter))]
    public ComplaintStatus Status { get; set; }

    /// <summary>
    /// The unique identifier of the subject
    /// </summary>
    public Guid SubjectGuid { get; set; }

    /// <summary>
    /// The action to take on the complaint
    /// </summary>
    [JsonConverter(typeof(ComplaintActionConverter))]
    public ComplaintAction Action { get; set; }

    /// <summary>
    /// Default constructor
    /// </summary>
    /// <param name="type"></param>
    /// <param name="dateSubmitted"></param>
    /// <param name="buyerGuid"></param>
    /// <param name="reason"></param>
    /// <param name="rationale"></param>
    /// <param name="resolutionDate"></param>
    /// <param name="resolutionCode"></param>
    /// <param name="status"></param>
    /// <param name="subjectGuid"></param>
    /// <param name="action"></param>
    public ComplaintPostRequestModel(ComplaintType type, DateTime dateSubmitted, Guid buyerGuid, string reason, string rationale, DateTime resolutionDate, string resolutionCode, ComplaintStatus status, Guid subjectGuid, ComplaintAction action)
    {
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
}
