using System.Runtime.Serialization;


namespace Lease.API.Models.Buyer;

[DataContract(Name = "LeaseAgreement", Namespace = "")]
public class BuyerPatchResponseModel
{
    [DataMember]
    public Guid? Guid { get; set; }
    [DataMember]
    public int? RealisedArea { get; set; }
    [DataMember]
    public Guid? PaymentGuid { get; set; }
    [DataMember]
    public bool? Ban { get; set; }
    [DataMember]
    public DateTime? StartDateOfBan { get; set; }
    [DataMember]
    public int? BanDuration { get; set; }
    [DataMember]
    public DateTime? BanEndDate { get; set; }
    [DataMember]
    public Guid? BiddingGuid { get; set; }
    [DataMember]
    public Guid? PersonGuid { get; set; }



    public BuyerPatchResponseModel(Guid? guid, int? realisedArea, Guid? paymentGuid, bool? ban, DateTime? startDateOfBan, int? banDuration, DateTime? banEndDate, Guid? biddingGuid, Guid? personGuid)
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
    }
}