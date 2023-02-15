
using Lease.API.Enums;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Lease.API.Entities;

public partial class DueDate //: IValidatableObject
{

    public Guid Guid { get; set; }

    public Guid DueDateGuid;
    

    public virtual List<LeaseAgreement> LeaseAgreements { get; set; }

    public DateTime Date { get; set; }

    public DueDate() { }

     public DueDate(Guid guid, Guid dueDateGuid) /*List<LeaseAgreement> leaseAgreements,*/ 
    {
        Guid = guid;
      // LeaseAgreementGuid = leaseAgreementGuid;
       // LeaseAgreements= leaseAgreements;
        Date = DateTime.Now.AddYears(2);
        DueDateGuid = dueDateGuid;
    }


    /*
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var results = new List<ValidationResult>();

        if (LeaseAgreementGuid == Guid.Empty)
        {
            results.Add(new ValidationResult("Buyer Guid cannot be empty."));
        }

        return results;
    }
    */
}

