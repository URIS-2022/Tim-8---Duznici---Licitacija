
using Lease.API.Enums;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Lease.API.Entities;

public partial class LeaseAgreement : IValidatableObject
{
    public Guid LeaseAgreementGuid { get; set; }

    [JsonConverter(typeof(GuaranteeTypeConverter))]
    public GuaranteeTypeConverter GuaranteeType { get; set; }
    public string ReferenceNumber { get; set; }
    public DateOnly DateRecording { get; set; }
    public Guid MinisterGuid { get; set; }
    public DateOnly DeadlineLandReturn { get; set; }
    public string PlaceOfSigning { get; set; }
    public DateOnly DateOfSigning { get; set; }
    public Guid BiddingGuid { get; set; }
    public Guid PersonGuid { get; set; }

    [JsonConverter(typeof(DocumentStatusConverter))]
    public  DocumentStatusConverter DocumentStatus {get; set; }




    public LeaseAgreement(Guid LeaseAgreementGuid, GuaranteeTypeConverter GuaranteeType, string ReferenceNumber, DateOnly DateRecording, Guid MinisterGuid, DateOnly DeadlineLandReturn, string PlaceOfSigning, DateOnly DateOfSigning, Guid BiddingGuid, Guid PersonGuid, DocumentStatusConverter DocumentStatus)
    {
        this.LeaseAgreementGuid = LeaseAgreementGuid;
        this.GuaranteeType = GuaranteeType;
        this.ReferenceNumber = ReferenceNumber;
        this.DateRecording = DateRecording;
        this.MinisterGuid = MinisterGuid;
        this.DeadlineLandReturn = DeadlineLandReturn;
        this.PlaceOfSigning = PlaceOfSigning;
        this.DateOfSigning = DateOfSigning;
        this.BiddingGuid = BiddingGuid;
        this.PersonGuid = PersonGuid;
        this.DocumentStatus = DocumentStatus;
    }

    public LeaseAgreement(GuaranteeTypeConverter GuaranteeType, string ReferenceNumber, DateOnly DateRecording, Guid MinisterGuid, DateOnly DeadlineLandReturn, string PlaceOfSigning, DateOnly DateOfSigning, Guid BiddingGuid, Guid PersonGuid, DocumentStatusConverter DocumentStatus)
    {
        this.LeaseAgreementGuid = Guid.NewGuid();
        this.GuaranteeType = GuaranteeType;
        this.ReferenceNumber = ReferenceNumber;
        this.DateRecording = DateRecording;
        this.MinisterGuid = MinisterGuid;
        this.DeadlineLandReturn = DeadlineLandReturn;
        this.PlaceOfSigning = PlaceOfSigning;
        this.DateOfSigning = DateOfSigning;
        this.BiddingGuid = BiddingGuid;
        this.PersonGuid = PersonGuid;
        this.DocumentStatus = DocumentStatus;
    }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var results = new List<ValidationResult>();

        if (LeaseAgreementGuid == Guid.Empty)
        {
            results.Add(new ValidationResult("Lease Agreement Guid cannot be empty."));
        }

        if (BiddingGuid == Guid.Empty)
        {
            results.Add(new ValidationResult("Bidding Guid cannot be empty."));
        }

        if (MinisterGuid == Guid.Empty)
        {
            results.Add(new ValidationResult("Minister Guid cannot be empty."));
        }

        if (PersonGuid == Guid.Empty)
        {
            results.Add(new ValidationResult("Person Guid cannot be empty."));
        }


        if (string.IsNullOrWhiteSpace(ReferenceNumber))
        {
            results.Add(new ValidationResult("Reference Number cannot be empty."));
        }

        if (string.IsNullOrWhiteSpace(PlaceOfSigning))
        {
            results.Add(new ValidationResult("Place of Signing cannot be empty."));
        }

        return results;


    }



}


