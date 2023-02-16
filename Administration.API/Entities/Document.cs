using Administration.API.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Administration.API.Entities;

public class Document
{
    [Key]
    public Guid Guid { get; set; }
    [JsonConverter(typeof(DocumentTypeConverter))]
    public DocumentType Type { get; set; }
    public Guid CommitteeGuid { get; set; }
    public Committee Committee { get; set; }
    public string ReferenceNumber { get; set; }
    public DateTime DateSubbmitted { get; set; }
    public DateTime DateCertified { get; set; }
    public string Template { get; set; }

    public Document(Guid guid, DocumentType type, Guid committeeGuid, string referenceNumber, DateTime dateSubbmitted, DateTime dateCertified, string template)
    {
        Guid = guid;
        Type = type;
        CommitteeGuid = committeeGuid;
        ReferenceNumber = referenceNumber;
        DateSubbmitted = dateSubbmitted;
        DateCertified = dateCertified;
        Template = template;
    }

    public Document(DocumentType type, Guid committeeGuid, string referenceNumber, DateTime dateSubbmitted, DateTime dateCertified, string template)
    {
        Type = type;
        CommitteeGuid = committeeGuid;
        ReferenceNumber = referenceNumber;
        DateSubbmitted = dateSubbmitted;
        DateCertified = dateCertified;
        Template = template;
    }
}
