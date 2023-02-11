using Complaint.API.Enums;
using System.Text.Json.Serialization;

namespace Complaint.API.Models;

public class ComplaintPostRequestModel
{
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
