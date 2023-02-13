﻿using Bidding.API.Entities;
using Bidding.API.Enums;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Bidding.API.Models
{
    public class PublicBiddingUpdateModel
    {
        
       
        
        public DateTime? Date { get; set; }
        
        public DateTime? StartDate { get; set; }
        
        public DateTime? EndDate { get; set; }
        
        public int? StartPricePerHectar { get; set; }
        
        public string? Expected { get; set; }
        [JsonConverter(typeof(MunicipalityConverter))]
        
        public Municipality? municipality { get; set; }
        
        public int? AuctionedPrice { get; set; }
        
        public Guid BestBuyerGuid { get; set; }
        [JsonConverter(typeof(PublicBiddingTypeConverter))]
       
        public PublicBiddingType? public_bidding_type { get; set; }
        
        public Address Addres { get; set; }
        
        public int? LeasePeriod { get; set; }
        
        public int? DepositReplenishmentAmount { get; set; }
       

        public Guid Round { get; set; }
        [JsonConverter(typeof(BiddingStatusConverter))]
        
        public BiddingStatus? biddingStatus { get; set; }

        public List<PublicBiddingLot> PublicBiddingLot { get; set; }

        public PublicBiddingUpdateModel(
       
       DateTime? date,
       DateTime? startDate,
       DateTime? endDate,
       int? startPricePerHectar,
       string? expected,
       Municipality? municipality,
       int? auctionedPrice,
       Guid bestBuyerGuid,
       PublicBiddingType? public_bidding_type,
       Address address,
       int? leasePeriod,
       int? depositReplenishmentAmount,
       Guid round,
       BiddingStatus? biddingStatus,
       List<PublicBiddingLot> publicBiddingLot

        )
        {
            
            Date = date;
            StartDate = startDate;
            EndDate = endDate;
            StartPricePerHectar = startPricePerHectar;
            Expected = expected;
            this.municipality = municipality;
            AuctionedPrice = auctionedPrice;
            BestBuyerGuid = bestBuyerGuid;
            this.public_bidding_type = public_bidding_type;
            Addres = address;
            LeasePeriod = leasePeriod;
            DepositReplenishmentAmount = depositReplenishmentAmount;
            this.Round = round;
            this.biddingStatus = biddingStatus;
            PublicBiddingLot = publicBiddingLot;
        }
    }
}