
using Lease.API.Enums;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Lease.API.Entities;

public partial class DueDate : IValidatableObject
{

    public int Id { get; set; }

    public Guid LeaseAgreementGuid { get; set; }

    public LeaseAgreement LeaseAgreement { get; set; }

    public DateTime Date { get; set; }

    public DueDate(int id, Guid leaseAgreementGuid, DateTime date)
    {
        Id = id;
        LeaseAgreementGuid = leaseAgreementGuid;
        Date = date;
       
    }


     public DueDate(Guid leaseAgreementGuid, DateTime date)
    {
        LeaseAgreementGuid = leaseAgreementGuid;
        Date = date;
    }



    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var results = new List<ValidationResult>();

        if (LeaseAgreementGuid == Guid.Empty)
        {
            results.Add(new ValidationResult("Buyer Guid cannot be empty."));
        }

        return results;
    }
}

