
using Lease.API.Enums;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Lease.API.Entities;

public partial class Buyer : IValidatableObject
{
    public Guid BuyerGuid { get; set; }
    public int RealisedArea { get; set; }
    public Guid PaymentGuid { get; set; }
    public string Ban { get; set; }
    public DateOnly StartDateOfBan { get; set; }
    public int BanDuration { get; set; }
    public DateOnly BanEndDate { get; set; }
    public Guid BiddingGuid { get; set; }
    public Guid PersonGuid { get; set; }





    public Buyer(Guid buyerGuid, int realisedArea, Guid paymentGuid, string ban, DateOnly startDateOfBan, int banDuration, DateOnly banEndDate, Guid biddingGuid, Guid personGuid)
    {
        buyerGuid = buyerGuid;
        RealisedArea = realisedArea;
        PaymentGuid = paymentGuid;
        Ban = ban;
        StartDateOfBan = startDateOfBan;
        BanDuration = banDuration;
        BanEndDate = banEndDate;
        BiddingGuid = biddingGuid;
        PersonGuid = personGuid;
    }

    
    public Buyer(int realisedArea, Guid paymentGuid, string ban, DateOnly startDateOfBan, int banDuration, DateOnly banEndDate, Guid biddingGuid, Guid personGuid)
    {
        BuyerGuid = Guid.NewGuid();
        RealisedArea = realisedArea;
        PaymentGuid = paymentGuid;
        Ban = ban;
        StartDateOfBan = startDateOfBan;
        BanDuration = banDuration;
        BanEndDate = banEndDate;
        BiddingGuid = biddingGuid;
        PersonGuid = personGuid;
    }


    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var results = new List<ValidationResult>();

        if (BuyerGuid == Guid.Empty)
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

        if (string.IsNullOrWhiteSpace(Ban))
        {
            results.Add(new ValidationResult("Ban cannot be empty."));
        }



        return results;
    }
}

