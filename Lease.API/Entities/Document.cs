using System;
using Lease.API.Enums;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.SymbolStore;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Lease.API.Entities;


public partial class Document : IValidatableObject
{
    public Guid DocumentGuid { get; set; }
    public string ReferenceNumber { get; set; }
    public DateOnly DateSubmissed { get; set; }
    public DateOnly DateCertified { get; set; }
    public string Template { get; set; }

    [JsonConverter(typeof(DocumentTypeConverter))]
    public DocumentTypeConverter DocumentType { get; set; }
    public Guid LeaseAgreementGuid { get; set; }



    public Document(Guid documentGuid, string referenceNumber, DateOnly dateSubmissed, DateOnly dateCertified, string template, DocumentTypeConverter documentType, Guid leaseAgreementGuid)
    {
        DocumentGuid = documentGuid;
        ReferenceNumber = referenceNumber;
        DateSubmissed = dateSubmissed;
        DateCertified = dateCertified;
        Template = template;
        DocumentType = documentType;
        LeaseAgreementGuid = leaseAgreementGuid;
    }


    public Document(string referenceNumber, DateOnly dateSubmissed, DateOnly dateCertified, string template, DocumentTypeConverter documentType, Guid leaseAgreementGuid)
    {
        DocumentGuid = Guid.NewGuid();
        ReferenceNumber = referenceNumber;
        DateSubmissed = dateSubmissed;
        DateCertified = dateCertified;
        Template = template;
        DocumentType = documentType;
        LeaseAgreementGuid = leaseAgreementGuid;
    }



    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var results = new List<ValidationResult>();

        if (DocumentGuid == Guid.Empty)
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