
using Lease.API.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Lease.API.Entities;

public partial class LeaseAgreement : IValidatableObject
{
    public Guid Guid { get; set; }

    [JsonConverter(typeof(GuaranteeTypeConverter))]
    public GuaranteeType GuaranteeType { get; set; }
    public string ReferenceNumber { get; set; }
    public DateTime DateRecording { get; set; }
    public Guid MinisterGuid { get; set; }
    public DateTime DeadlineLandReturn { get; set; }
    public string PlaceOfSigning { get; set; }
    public DateTime DateOfSigning { get; set; }
    public Guid BiddingGuid { get; set; }
    public Guid PersonGuid { get; set; }

    public virtual Buyer Buyer { get; set; }

    [JsonConverter(typeof(DocumentStatusConverter))]
    public DocumentStatus DocumentStatus { get; set; }


    public virtual DueDate DueDate { get; set; }

    public virtual ICollection<Document> Documents { get; set; }

    public Guid DueDateGuid { get; internal set; }

    public LeaseAgreement() { }

    public LeaseAgreement(Guid Guid, GuaranteeType GuaranteeType, string ReferenceNumber, DateTime DateRecording, Guid MinisterGuid, DateTime DeadlineLandReturn, string PlaceOfSigning, DateTime DateOfSigning, Guid BiddingGuid, Guid PersonGuid, DocumentStatus DocumentStatus, Guid dueDateguid)
    {
        this.Guid = Guid;
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
        DueDateGuid = dueDateguid;


    }

    public LeaseAgreement(GuaranteeType GuaranteeType, string ReferenceNumber, DateTime DateRecording, Guid MinisterGuid, DateTime DeadlineLandReturn, string PlaceOfSigning, DateTime DateOfSigning, Guid BiddingGuid, Guid PersonGuid, DocumentStatus DocumentStatus, Guid dueDateGuid)
    {
        this.Guid = Guid.NewGuid();
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
        DueDateGuid = dueDateGuid;

    }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var results = new List<ValidationResult>();

        if (Guid == Guid.Empty)
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


