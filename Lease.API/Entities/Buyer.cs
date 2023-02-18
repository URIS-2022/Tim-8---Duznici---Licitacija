
using AutoMapper.Configuration.Annotations;
using Lease.API.Enums;
using System.ComponentModel.DataAnnotations;

namespace Lease.API.Entities;

/// <summary>
/// Represents a buyer with its properties and associated entities.
/// </summary>
public partial class Buyer : IValidatableObject
{
    /// <summary>
    /// Gets or sets the unique identifier of the buyer.
    /// </summary>
    public Guid Guid { get; set; }

    /// <summary>
    /// Gets or sets the realised area of the buyer.
    /// </summary>
    public int RealisedArea { get; set; }

    /// <summary>
    /// Gets or sets the ban of the buyer.
    /// </summary>
    public bool Ban { get; set; }

    /// <summary>
    /// Gets or sets the start date of ban of the buyer.
    /// </summary>
    public DateTime StartDateOfBan { get; set; }

    /// <summary>
    /// Gets or sets the ban duration of the buyer.
    /// </summary>
    public int BanDuration { get; set; }

    /// <summary>
    /// Gets or sets the ban end date of the buyer.
    /// </summary>
    public DateTime BanEndDate { get; set; }

    /// <summary>
    /// Gets or sets the bidding guid of the buyer.
    /// </summary>
    public Guid BiddingGuid { get; set; }

    /// <summary>
    /// Gets or sets the person guid of the buyer.
    /// </summary>
    public Guid PersonGuid { get; set; }

    /// <summary>
    /// Gets or sets the bidding of the buyer.
    /// </summary>
    public virtual LeaseAgreement? LeaseAgreement { get; set; }

    /// <summary>
    /// Gets or sets the person of the buyer.
    /// </summary>
    [ValueConverter(typeof(PriorityTypeListValueConverter))]
    public List<PriorityType>? Priorities { get; set; }

    /// <summary>
    /// Creates a new instance of the <see cref="Buyer"/> class.
    /// </summary>
    /// <param name="guid"></param>
    /// <param name="realisedArea"></param>
    /// <param name="ban"></param>
    /// <param name="startDateOfBan"></param>
    /// <param name="banDuration"></param>
    /// <param name="banEndDate"></param>
    /// <param name="biddingGuid"></param>
    /// <param name="personGuid"></param>
    public Buyer(Guid guid, int realisedArea, bool ban, DateTime startDateOfBan, int banDuration, DateTime banEndDate, Guid biddingGuid, Guid personGuid)
    {
        Guid = guid;
        RealisedArea = realisedArea;
        Ban = ban;
        StartDateOfBan = startDateOfBan;
        BanDuration = banDuration;
        BanEndDate = banEndDate;
        BiddingGuid = biddingGuid;
        PersonGuid = personGuid;
    }

    /// <summary>
    /// Creates a new instance of the <see cref="Buyer"/> class.
    /// </summary>
    public Buyer() { }

    /// <summary>
    /// Creates a new instance of the <see cref="Buyer"/> class with the specified parameters.
    /// </summary>
    /// <param name="realisedArea"></param>
    /// <param name="ban"></param>
    /// <param name="startDateOfBan"></param>
    /// <param name="banDuration"></param>
    /// <param name="banEndDate"></param>
    /// <param name="biddingGuid"></param>
    /// <param name="personGuid"></param>
    public Buyer(int realisedArea, bool ban, DateTime startDateOfBan, int banDuration, DateTime banEndDate, Guid biddingGuid, Guid personGuid)
    {
        Guid = Guid.NewGuid();
        RealisedArea = realisedArea;
        Ban = ban;
        StartDateOfBan = startDateOfBan;
        BanDuration = banDuration;
        BanEndDate = banEndDate;
        BiddingGuid = biddingGuid;
        PersonGuid = personGuid;
    }

    /// <summary>
    /// Validates the buyer.
    /// </summary>
    /// <param name="validationContext"> The validation context. </param>
    /// <returns> The validation results. </returns>
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var results = new List<ValidationResult>();

        if (Guid == Guid.Empty)
        {
            results.Add(new ValidationResult("Buyer Guid cannot be empty."));
        }

        if (BiddingGuid == Guid.Empty)
        {
            results.Add(new ValidationResult("Bidding Guid cannot be empty."));
        }

        if (PersonGuid == Guid.Empty)
        {
            results.Add(new ValidationResult("Person Guid cannot be empty."));
        }

        return results;
    }
}

