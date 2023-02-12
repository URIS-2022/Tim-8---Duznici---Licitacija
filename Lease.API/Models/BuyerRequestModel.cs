namespace Lease.API.Models;

public class BuyerRequestModel
{
    public int RealisedArea { get; set; }
    public List<Guid> Payment { get; set; }
    public bool Ban { get; set; }
    public int BanDuration { get; set; }
    public DateTime BanEndDate { get; set; }
    public Guid PublicBiddingGuid { get; set; }
    public Guid PersonGuid { get; set; }
    public List<string> Priorities { get; set; }

    public BuyerRequestModel(int realisedArea, List<Guid> payment, bool ban, int banDuration,
     DateTime banEndDate, Guid publicBiddingGuid, Guid personGuid, List<string> priorities)
    {
        RealisedArea = realisedArea;
        Payment = payment;
        Ban = ban;
        BanDuration = banDuration;
        BanEndDate = banEndDate;
        PublicBiddingGuid = publicBiddingGuid;
        PersonGuid = personGuid;
        Priorities = priorities;
    }
}