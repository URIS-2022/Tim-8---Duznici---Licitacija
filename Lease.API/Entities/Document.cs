using Lease.API.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Lease.API.Entities;


public partial class Document : IValidatableObject
{
    public Guid Guid { get; set; }
    public string ReferenceNumber { get; set; }
    public DateTime DateSubbmitted { get; set; }
    public DateTime DateCertified { get; set; }
    public string Template { get; set; }

    [JsonConverter(typeof(DocumentTypeConverter))]
    public DocumentType Type { get; set; }
    public Guid LeaseAgreementGuid { get; set; }
    public LeaseAgreement LeaseAgreement { get; set; }


    public Document() { }

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

    //LeaseAgreement  instanca nije napisan u konstruktorima
}