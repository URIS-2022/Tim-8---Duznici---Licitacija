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
    public Guid DocumentGuid { get; set; }
    public string ReferenceNumber { get; set; }
    public DateTime DateSubbmitted { get; set; }
    public DateTime DateCertified { get; set; }
    public string Template { get; set; }
}
