using Lease.API.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Lease.API.Entities;

/// <summary>
/// Represents a lease agreement entity with its properties and methods.
/// </summary>
public partial class Document : IValidatableObject
{
    /// <summary>
    /// Gets or sets the unique identifier of the document.
    /// </summary>
    public Guid Guid { get; set; }

    /// <summary>
    /// Gets or sets the reference number of the document.
    /// </summary>
    public string? ReferenceNumber { get; set; }

    /// <summary>
    /// Gets or sets the date when the document was submitted.
    /// </summary>
    public DateTime DateSubbmitted { get; set; }

    /// <summary>
    /// Gets or sets the date when the document was certified.
    /// </summary>
    public DateTime DateCertified { get; set; }

    /// <summary>
    /// Gets or sets the template of the document.
    /// </summary>
    public string? Template { get; set; }

    /// <summary>
    /// Gets or sets the type of the document.
    /// </summary>
    [JsonConverter(typeof(DocumentTypeConverter))]
    public DocumentType Type { get; set; }

    /// <summary>
    /// Gets or sets the lease agreement related to this document.
    /// </summary>
    public Guid LeaseAgreementGuid { get; set; }

    /// <summary>
    /// Gets or sets the lease agreement related to this document.
    /// </summary>
    public LeaseAgreement? LeaseAgreement { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Document"/> class.
    /// </summary>
    public Document() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="Document"/> class.
    /// </summary>
    /// <param name="guid"></param>
    /// <param name="referenceNumber"></param>
    /// <param name="dateSubmissed"></param>
    /// <param name="dateCertified"></param>
    /// <param name="template"></param>
    /// <param name="documentType"></param>
    /// <param name="leaseAgreementGuid"></param>
    public Document(Guid guid, string referenceNumber, DateTime dateSubmissed, DateTime dateCertified, string template, DocumentType documentType, Guid leaseAgreementGuid)
    {
        Guid = guid;
        ReferenceNumber = referenceNumber;
        DateSubbmitted = dateSubmissed;
        DateCertified = dateCertified;
        Template = template;
        Type = documentType;
        LeaseAgreementGuid = leaseAgreementGuid;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Document"/> class.
    /// </summary>
    /// <param name="referenceNumber"></param>
    /// <param name="dateSubmissed"></param>
    /// <param name="dateCertified"></param>
    /// <param name="template"></param>
    /// <param name="documentType"></param>
    /// <param name="leaseAgreementGuid"></param>
    public Document(string referenceNumber, DateTime dateSubmissed, DateTime dateCertified, string template, DocumentType documentType, Guid leaseAgreementGuid)
    {
        Guid = Guid.NewGuid();
        ReferenceNumber = referenceNumber;
        DateSubbmitted = dateSubmissed;
        DateCertified = dateCertified;
        Template = template;
        Type = documentType;
        LeaseAgreementGuid = leaseAgreementGuid;
    }

    /// <summary>
    /// Validates the document.
    /// </summary>
    /// <param name="validationContext"></param>
    /// <returns> A collection of validation results. </returns>
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var results = new List<ValidationResult>();

        if (Guid == Guid.Empty)
        {
            results.Add(new ValidationResult("Document Guid cannot be empty."));
        }

        if (LeaseAgreementGuid == Guid.Empty)
        {
            results.Add(new ValidationResult("Lease Agreement Guid cannot be empty."));
        }

        if (string.IsNullOrWhiteSpace(ReferenceNumber))
        {
            results.Add(new ValidationResult("Reference Number cannot be empty."));
        }

        if (string.IsNullOrWhiteSpace(Template))

        {
            results.Add(new ValidationResult("Template cannot be empty."));
        }

        return results;
    }
}