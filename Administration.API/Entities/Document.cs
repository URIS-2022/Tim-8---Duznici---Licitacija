using Administration.API.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Administration.API.Entities;

/// <summary>
/// Represents a document related to a committee, with its metadata and contents.
/// </summary>
public class Document
{
    /// <summary>
    /// The unique identifier for this document.
    /// </summary>
    [Key]
    public Guid Guid { get; set; }

    /// <summary>
    /// The type of document, which determines its structure and required information.
    /// </summary>
    [JsonConverter(typeof(DocumentTypeConverter))]
    public DocumentType Type { get; set; }

    /// <summary>
    /// The unique identifier of the committee that this document belongs to.
    /// </summary>
    public Guid CommitteeGuid { get; set; }

    /// <summary>
    /// The committee that this document belongs to.
    /// </summary>
    public Committee? Committee { get; set; }

    /// <summary>
    /// A reference number for this document, which may be used to locate or identify it.
    /// </summary>
    [Required]
    public string? ReferenceNumber { get; set; }

    /// <summary>
    /// The date on which this document was submitted to the committee.
    /// </summary>
    public DateTime DateSubbmitted { get; set; }

    /// <summary>
    /// The date on which this document was certified or approved by the committee.
    /// </summary>
    public DateTime DateCertified { get; set; }

    /// <summary>
    /// The template used to create this document, if any.
    /// </summary>
    public string? Template { get; set; }

    /// <summary>
    /// Creates a new Document object with the specified properties.
    /// </summary>
    /// <param name="guid">The unique identifier for this document.</param>
    /// <param name="type">The type of document.</param>
    /// <param name="committeeGuid">The unique identifier of the committee that this document belongs to.</param>
    /// <param name="referenceNumber">The reference number for this document.</param>
    /// <param name="dateSubbmitted">The date on which this document was submitted.</param>
    /// <param name="dateCertified">The date on which this document was certified.</param>
    /// <param name="template">The template used to create this document.</param>
    public Document(DocumentType type, Guid committeeGuid, string referenceNumber, DateTime dateSubbmitted, DateTime dateCertified, string template, Guid? guid = null)
    {
        Guid = guid ?? Guid.NewGuid();
        Type = type;
        CommitteeGuid = committeeGuid;
        ReferenceNumber = referenceNumber;
        DateSubbmitted = dateSubbmitted;
        DateCertified = dateCertified;
        Template = template;
    }

    /// <summary>
    /// Creates a new Document object with the specified properties, generating a new unique identifier.
    /// </summary>
    public Document() { }
}
