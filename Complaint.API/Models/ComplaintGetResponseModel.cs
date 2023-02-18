using Complaint.API.Enums;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Complaint.API.Models;

/// <summary>
/// Get response model for a complaint
/// </summary>
[DataContract(Name = "Complaint", Namespace = "")]
public class ComplaintGetResponseModel
{
    /// <summary>
    /// The unique identifier for the complaint
    /// </summary>
    [DataMember]
    public Guid Guid { get; set; }

    /// <summary>
    /// The type of complaint
    /// </summary>
    [DataMember]
    [JsonConverter(typeof(ComplaintTypeConverter))]
    public ComplaintType Type { get; set; }

    /// <summary>
    /// The date the complaint was submitted
    /// </summary>
    [DataMember]
    public DateTime DateSubmitted { get; set; }

    /// <summary>
    /// The unique identifier of the buyer
    /// </summary>
    [DataMember]
    public Guid BuyerGuid { get; set; }

    /// <summary>
    /// The reason for the complaint
    /// </summary>
    [DataMember]
    public string Reason { get; set; }

    /// <summary>
    /// The rationale for the complaint
    /// </summary>
    [DataMember]
    public string Rationale { get; set; }

    /// <summary>
    /// The date the complaint was resolved
    /// </summary>
    [DataMember]
    public DateTime ResolutionDate { get; set; }

    /// <summary>
    /// The resolution code for the complaint
    /// </summary>
    [DataMember]
    public string ResolutionCode { get; set; }

    /// <summary>
    /// The status of the complaint
    /// </summary>
    [JsonConverter(typeof(ComplaintStatusConverter))]
    [DataMember(Name = "Status")]
    public ComplaintStatus Status { get; set; }

    /// <summary>
    /// The unique identifier of the subject
    /// </summary>
    [DataMember]
    public Guid SubjectGuid { get; set; }

    /// <summary>
    /// The action taken on the complaint
    /// </summary>
    [JsonConverter(typeof(ComplaintActionConverter))]
    [DataMember(Name = "Action")]
    public ComplaintAction Action { get; set; }

    /// <summary>
    /// Default constructor
    /// </summary>
    /// <param name="guid"></param>
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
    public ComplaintGetResponseModel(Guid guid, ComplaintType type, DateTime dateSubmitted, Guid buyerGuid, string reason, string rationale, DateTime resolutionDate, string resolutionCode, ComplaintStatus status, Guid subjectGuid, ComplaintAction action)
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
