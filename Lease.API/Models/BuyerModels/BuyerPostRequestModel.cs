

using System.Runtime.Serialization;


namespace Lease.API.Models.Buyer;

[DataContract(Name = "LeaseAgreement", Namespace = "")]
public class BuyerPostRequestModel
{

    

    public int RealisedArea { get; set; }

    public Guid PaymentGuid { get; set; }

    public bool Ban { get; set; }

    public DateTime StartDateOfBan { get; set; }

    public int BanDuration { get; set; }

    public DateTime BanEndDate { get; set; }

    public Guid BiddingGuid { get; set; }

    public Guid PersonGuid { get; set; }



    public BuyerPostRequestModel(Guid guid, int realisedArea, Guid paymentGuid, bool ban, DateTime startDateOfBan, int banDuration, DateTime banEndDate, Guid biddingGuid, Guid personGuid)
    {
     
        RealisedArea = realisedArea;
        PaymentGuid = paymentGuid;
        Ban = ban;
        StartDateOfBan = startDateOfBan;
        BanDuration = banDuration;
        BanEndDate = banEndDate;
        BiddingGuid = biddingGuid;
        PersonGuid = personGuid;
    }
}