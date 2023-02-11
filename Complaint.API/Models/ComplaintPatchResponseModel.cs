using Complaint.API.Enums;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Complaint.API.Models;

[DataContract(Name = "Complaint", Namespace = "")]
public class ComplaintPatchResponseModel
{
    [DataMember]
    public Guid Guid { get; set; }
    [JsonConverter(typeof(ComplaintTypeConverter))]
    [DataMember(Name = "Type")]
    public ComplaintType Type { get; set; }
    [DataMember]
    public DateTime DateSubmitted { get; set; }
    [DataMember]
    public Guid BuyerGuid { get; set; }
    [DataMember]
    public string Reason { get; set; }
    [DataMember]
    public string Rationale { get; set; }
    [DataMember]
    public DateTime ResolutionDate { get; set; }
    [DataMember]
    public string ResolutionCode { get; set; }
    [JsonConverter(typeof(ComplaintStatusConverter))]
    [DataMember(Name = "Status")]
    public ComplaintStatus Status { get; set; }
    [DataMember]
    public Guid SubjectGuid { get; set; }
    [JsonConverter(typeof(ComplaintActionConverter))]
    [DataMember(Name = "Action")]
    public ComplaintAction Action { get; set; }

    public ComplaintPatchResponseModel(Guid guid, ComplaintType type, DateTime dateSubmitted, Guid buyerGuid, string reason, string rationale, DateTime resolutionDate, string resolutionCode, ComplaintStatus status, Guid subjectGuid, ComplaintAction action)
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
}
