using AutoMapper.Configuration.Annotations;
using Lease.API.Entities;
using Lease.API.Enums;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Lease.API.Models.Buyer;

[DataContract(Name = "LeaseAgreement", Namespace = "")]
public class BuyerPatchResponseModel
{
    [DataMember]
    public Guid Guid { get; set; }
    [DataMember]
    public int RealisedArea { get; set; }
    [DataMember]

    public bool Ban { get; set; }
    [DataMember]
    public DateTime StartDateOfBan { get; set; }
    [DataMember]
    public int BanDuration { get; set; }
    [DataMember]
    public DateTime BanEndDate { get; set; }
    [DataMember]
    public Guid BiddingGuid { get; set; }
    [DataMember]
    public Guid PersonGuid { get; set; }

    [DataMember]
    [ValueConverter(typeof(PriorityTypeListJsonConverter))]
    public List<PriorityType> Priorities { get; set; }



    public BuyerPatchResponseModel(Guid guid, int realisedArea, bool ban, DateTime startDateOfBan, int banDuration, DateTime banEndDate, Guid biddingGuid, Guid personGuid, List<PriorityType> priorities)
    {
        Guid = guid;
        RealisedArea = realisedArea;
        Ban = ban;
        StartDateOfBan = startDateOfBan;
        BanDuration = banDuration;
        BanEndDate = banEndDate;
        BiddingGuid = biddingGuid;
        PersonGuid = personGuid;
        Priorities= priorities; 
    }
}