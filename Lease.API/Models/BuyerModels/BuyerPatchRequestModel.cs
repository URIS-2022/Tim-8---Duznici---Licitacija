using Lease.API.Enums;


namespace Lease.API.Models.Buyer;

public class BuyerPatchRequestModel
{

    public int? RealisedArea { get; set; }
    public bool? Ban { get; set; }

    public DateTime? StartDateOfBan { get; set; }
    public int? BanDuration { get; set; }
    public DateTime? BanEndDate { get; set; }
    public Guid? BiddingGuid { get; set; }

    public Guid? PersonGuid {get; set;}


    public List<PriorityType>? Priorities { get; set; }


    public BuyerPatchRequestModel(int? realisedArea, bool? ban, DateTime? startDateOfBan, int? banDuration, DateTime? banEndDate, Guid? biddingGuid, Guid? personGuid, List<PriorityType>? priorities)
    {
        RealisedArea = realisedArea;
        Ban = ban;
        StartDateOfBan = startDateOfBan;
        BanDuration = banDuration;
        BanEndDate = banEndDate;
        BiddingGuid = biddingGuid;
        PersonGuid = personGuid;
        Priorities = priorities;
    }
}