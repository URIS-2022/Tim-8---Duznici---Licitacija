
using Lease.API.Enums;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Lease.API.Entities;

public partial class Buyer : IValidatableObject
{
    public Guid Guid { get; set; }
    public int RealisedArea { get; set; }
    public Guid PaymentGuid { get; set; }
    public bool Ban { get; set; }
    public DateTime StartDateOfBan { get; set; }
    public int BanDuration { get; set; }
    public DateTime BanEndDate { get; set; }
    public Guid BiddingGuid { get; set; }
    public Guid PersonGuid { get; set; }

    [JsonConverter(typeof(PriorityTypeConverter))]

    public List<PriorityType> PriorityTypes { get; set; }

    public LeaseAgreement LeaseAgreement { get; set; }




    public Buyer(Guid guid, int realisedArea, Guid paymentGuid, bool ban, DateTime startDateOfBan, int banDuration, DateTime banEndDate, Guid biddingGuid, Guid personGuid, List<PriorityType> priorityTypes)
    {
        Guid = guid;
        RealisedArea = realisedArea;
        PaymentGuid = paymentGuid;
        Ban = ban;
        StartDateOfBan = startDateOfBan;
        BanDuration = banDuration;
        BanEndDate = banEndDate;
        BiddingGuid = biddingGuid;
        PersonGuid = personGuid;
        PriorityTypes = priorityTypes;

    }

    public Buyer() { }
    public Buyer(int realisedArea, Guid paymentGuid, bool ban, DateTime startDateOfBan, int banDuration, DateTime banEndDate, Guid biddingGuid, Guid personGuid, List<PriorityType> priorityTypes )
    {
        Guid = Guid.NewGuid();
        RealisedArea = realisedArea;
        PaymentGuid = paymentGuid;
        Ban = ban;
        StartDateOfBan = startDateOfBan;
        BanDuration = banDuration;
        BanEndDate = banEndDate;
        BiddingGuid = biddingGuid;
        PersonGuid = personGuid;
        PriorityTypes = priorityTypes;
    }


    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var results = new List<ValidationResult>();

        if (Guid == Guid.Empty)
        {
            results.Add(new ValidationResult("Buyer Guid cannot be empty."));
        }

        if (PaymentGuid == Guid.Empty)
        {
            results.Add(new ValidationResult("Payment Guid cannot be empty."));
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

