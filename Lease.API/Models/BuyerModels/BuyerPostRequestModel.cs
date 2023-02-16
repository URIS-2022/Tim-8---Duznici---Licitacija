﻿

using Lease.API.Entities;
using Lease.API.Enums;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Lease.API.Models.Buyer;

[DataContract(Name = "LeaseAgreement", Namespace = "")]
public class BuyerPostRequestModel
{
    public int RealisedArea { get; set; }

    public bool Ban { get; set; }

    public DateTime StartDateOfBan { get; set; }

    public int BanDuration { get; set; }

    public DateTime BanEndDate { get; set; }

    public Guid BiddingGuid { get; set; }

    public Guid PersonGuid { get; set; }


    [JsonConverter(typeof(PriorityTypeListJsonConverter))]
    public List<PriorityType> Priorities { get; set; }

    public BuyerPostRequestModel( int realisedArea, bool ban, DateTime startDateOfBan, int banDuration, DateTime banEndDate, Guid biddingGuid, Guid personGuid, List<PriorityType> priorities)
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