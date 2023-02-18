
using Lease.API.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Lease.API.Entities;

/// <summary>
/// Represents a lease agreement entity with its properties and methods.
/// </summary>
public partial class LeaseAgreement : IValidatableObject
{
    /// <summary>
    /// Gets or sets the unique identifier of the lease agreement.
    /// </summary>
    public Guid Guid { get; set; }

    /// <summary>
    /// Gets or sets the type of guarantee.
    /// </summary>
    [JsonConverter(typeof(GuaranteeTypeConverter))]
    public GuaranteeType GuaranteeType { get; set; }

    /// <summary>
    /// Gets or sets the reference number of the lease agreement.
    /// </summary>
    public string? ReferenceNumber { get; set; }

    /// <summary>
    /// Gets or sets the date when the lease agreement was recorded.
    /// </summary>
    public DateTime DateRecording { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the minister.
    /// </summary>
    public Guid MinisterGuid { get; set; }

    /// <summary>
    /// Gets or sets the deadline for returning the land.
    /// </summary>
    public DateTime DeadlineLandReturn { get; set; }

    /// <summary>
    /// Gets or sets the place where the lease agreement was signed.
    /// </summary>
    public string? PlaceOfSigning { get; set; }

    /// <summary>
    /// Gets or sets the date when the lease agreement was signed.
    /// </summary>
    public DateTime DateOfSigning { get; set; }
    public Guid? PublicBiddingGuid { get; set; }
    public Guid PersonGuid { get; set; }

    /// <summary>
    /// Gets or sets the buyer related to this lease agreement.
    /// </summary>
    public virtual Buyer? Buyer { get; set; }

    /// <summary>
    /// Gets or sets the bidding related to this lease agreement.
    /// </summary>
    [JsonConverter(typeof(DocumentStatusConverter))]
    public DocumentStatus DocumentStatus { get; set; }

    /// <summary>
    /// Gets or sets the due date related to this lease agreement.
    /// </summary>
    public virtual DueDate? DueDate { get; set; }

    /// <summary>
    /// Gets or sets the documents related to this lease agreement.
    /// </summary>
    public virtual ICollection<Document>? Documents { get; set; }

    /// <summary>
    /// Gets or sets the minister related to this lease agreement.
    /// </summary>
    public Guid DueDateGuid { get; internal set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="LeaseAgreement"/> class.
    /// </summary>
    public LeaseAgreement() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="LeaseAgreement"/> class with the specified parameters.
    /// </summary>
    /// <param name="Guid"></param>
    /// <param name="GuaranteeType"></param>
    /// <param name="ReferenceNumber"></param>
    /// <param name="DateRecording"></param>
    /// <param name="MinisterGuid"></param>
    /// <param name="DeadlineLandReturn"></param>
    /// <param name="PlaceOfSigning"></param>
    /// <param name="DateOfSigning"></param>
    /// <param name="BiddingGuid"></param>
    /// <param name="PersonGuid"></param>
    /// <param name="DocumentStatus"></param>
    /// <param name="dueDateguid"></param>
    public LeaseAgreement(Guid Guid, GuaranteeType GuaranteeType, string ReferenceNumber, DateTime DateRecording, Guid MinisterGuid, DateTime DeadlineLandReturn, string PlaceOfSigning, DateTime DateOfSigning, Guid? BiddingGuid, Guid PersonGuid, DocumentStatus DocumentStatus, Guid dueDateguid)
    {
        this.Guid = Guid;
        this.GuaranteeType = GuaranteeType;
        this.ReferenceNumber = ReferenceNumber;
        this.DateRecording = DateRecording;
        this.MinisterGuid = MinisterGuid;
        this.DeadlineLandReturn = DeadlineLandReturn;
        this.PlaceOfSigning = PlaceOfSigning;
        this.DateOfSigning = DateOfSigning;
        this.PublicBiddingGuid = BiddingGuid;
        this.PersonGuid = PersonGuid;
        this.DocumentStatus = DocumentStatus;
        DueDateGuid = dueDateguid;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="LeaseAgreement"/> class with the specified parameters.
    /// </summary>
    /// <param name="GuaranteeType"></param>
    /// <param name="ReferenceNumber"></param>
    /// <param name="DateRecording"></param>
    /// <param name="MinisterGuid"></param>
    /// <param name="DeadlineLandReturn"></param>
    /// <param name="PlaceOfSigning"></param>
    /// <param name="DateOfSigning"></param>
    /// <param name="BiddingGuid"></param>
    /// <param name="PersonGuid"></param>
    /// <param name="DocumentStatus"></param>
    /// <param name="dueDateGuid"></param>
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
        this.PublicBiddingGuid = BiddingGuid;
        this.PersonGuid = PersonGuid;
        this.DocumentStatus = DocumentStatus;
        DueDateGuid = dueDateGuid;
    }

    /// <summary>
    /// Validates the lease agreement.
    /// </summary>
    /// <param name="validationContext"></param>
    /// <returns></returns>
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var results = new List<ValidationResult>();

        if (Guid == Guid.Empty)
        {
            results.Add(new ValidationResult("Lease Agreement Guid cannot be empty."));
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


