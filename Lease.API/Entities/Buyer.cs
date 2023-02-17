
using AutoMapper.Configuration.Annotations;
using Lease.API.Enums;
using System.ComponentModel.DataAnnotations;

namespace Lease.API.Entities;

public partial class Buyer : IValidatableObject
{
    public Guid Guid { get; set; }
    public int RealisedArea { get; set; }
    
    public bool Ban { get; set; }
    public DateTime StartDateOfBan { get; set; }
    public int BanDuration { get; set; }
    public DateTime BanEndDate { get; set; }
    public Guid BiddingGuid { get; set; }
    public Guid PersonGuid { get; set; }

  //   [JsonConverter(typeof(PriorityTypeConverter))]
  //  public PriorityType PriorityType { get; set; }

    public  virtual LeaseAgreement LeaseAgreement { get; set; }

    // public virtual ICollection<PriorityBuyer> PriorityBuyers { get; set; }

    [ValueConverter(typeof(PriorityTypeListValueConverter))]
    public List<PriorityType> Priorities { get; set; }
    

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
      //  Priorities = (List<PriorityType>?) PriorityBuyers.Where(pb => pb.BuyerGuid == Guid).Select(pb => pb.PriorityType).ToList();


    //    PriorityTypes = priorityTypes;


}

public Buyer() { }
    public Buyer(int realisedArea,bool ban, DateTime startDateOfBan, int banDuration, DateTime banEndDate, Guid biddingGuid, Guid personGuid )
    {
        Guid = Guid.NewGuid();
        RealisedArea = realisedArea;
        Ban = ban;
        StartDateOfBan = startDateOfBan;
        BanDuration = banDuration;
        BanEndDate = banEndDate;
        BiddingGuid = biddingGuid;
        PersonGuid = personGuid;
        //Priorities = (List<PriorityType>?)PriorityBuyers.Where(pb => pb.BuyerGuid == Guid).Select(pb => pb.PriorityType).ToList();
            

        //  PriorityTypes = priorityTypes;
    }


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

