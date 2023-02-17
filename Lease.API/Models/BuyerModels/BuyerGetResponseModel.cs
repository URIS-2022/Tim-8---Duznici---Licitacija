
using AutoMapper.Configuration.Annotations;
using Lease.API.Entities;
using Lease.API.Enums;
using Microsoft.OpenApi.Extensions;
using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace Lease.API.Models.Buyer;

[DataContract(Name = "LeaseAgreement", Namespace = "")]
public class BuyerGetResponseModel
{
    
    public Guid Guid { get; set; }

    public int RealisedArea { get; set; }
    
    
 
    public bool Ban { get; set; }

    public DateTime StartDateOfBan { get; set; }

    public int BanDuration { get; set; }
    
    public DateTime BanEndDate { get; set; }
 
    public Guid BiddingGuid { get; set; }

    public Guid PersonGuid { get; set; }

    [ValueConverter(typeof(PriorityTypeListValueConverter))]
    public List<PriorityType>  Priorities { get; set; }
   
   // [JsonConverter(typeof(PriorityTypeListJsonConverter))]
   // public List<PriorityT> PrioritiesString { get; set; }




public BuyerGetResponseModel(Guid guid, int realisedArea, bool ban, DateTime startDateOfBan, int banDuration, DateTime banEndDate, Guid biddingGuid, Guid personGuid, List<PriorityType> priorities )
    {
        Guid = guid;
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