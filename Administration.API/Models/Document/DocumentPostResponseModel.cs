using Administration.API.Enums;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Administration.API.Models.Document;

[DataContract(Name = "Document", Namespace = "")]
public class DocumentPostResponseModel
{
    [JsonConverter(typeof(DocumentTypeConverter))]
    public DocumentType Type { get; set; }
    public Guid CommitteeGuid { get; set; }
    public string ReferenceNumber { get; set; }
    public DateTime DateSubbmitted { get; set; }
    public DateTime DateCertified { get; set; }
    public string Template { get; set; }

    public DocumentPostResponseModel() { }
}
