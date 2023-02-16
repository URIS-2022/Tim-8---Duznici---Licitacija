using Administration.API.Enums;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Administration.API.Models.Document;

[DataContract(Name = "Document", Namespace = "")]
public class DocumentGetResponseModel
{
    [DataMember]
    public Guid Guid { get; set; }
    [DataMember]
    [JsonConverter(typeof(DocumentTypeConverter))]
    public DocumentType Type { get; set; }
    [DataMember]
    public Guid CommitteeGuid { get; set; }
    [DataMember]
    public string ReferenceNumber { get; set; }
    [DataMember]
    public DateTime DateSubbmitted { get; set; }
    [DataMember]
    public DateTime DateCertified { get; set; }
    [DataMember]
    public string Template { get; set; }

    public DocumentGetResponseModel() { }
}
