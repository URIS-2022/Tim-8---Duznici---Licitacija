using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using Bidding.API.Entities;
using Bidding.API.Enums;


namespace Bidding.API.Entities
{
    public partial class PublicBidding : IValidatableObject
    {
        public Guid Guid { get; set; }

        public DateTime Date { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int StartPricePerHectar { get; set; }
        public string Expected { get; set; }
        [JsonConverter(typeof(MunicipalityConverter))]
        public Municipality municipality { get; set; }
        public int AuctionedPrice { get; set; }
        public Guid BestBuyerGuid { get; set; }
        [JsonConverter(typeof(PublicBiddingTypeConverter))]
        public PublicBiddingType public_bidding_type { get; set; }
        public Address AddresGuid { get; set; }
        public int LeasePeriod { get; set; }
        public int DepositReplenishmentAmount { get; set; }
         
        public Guid Round { get; set; }
        [JsonConverter(typeof(BiddingStatusConverter))]

        public BiddingStatus biddingStatus { get; set; }

        public PublicBidding() { }
        public PublicBidding(
         Guid publicBiddingGuid,
         DateTime date,
         DateTime startDate,
         DateTime endDate,
         int startPricePerHectar,
         string expected,
         Municipality municipality,
         int auctionedPrice,
         Guid bestBuyerGuid,
         PublicBiddingType public_bidding_type,
         Address addressGuid,
         int leasePeriod,
         int depositReplenishmentAmount,
         Guid round,
         BiddingStatus biddingStatus
          )
        {
            Guid = publicBiddingGuid;
            Date = date;
            StartDate = startDate;
            EndDate = endDate;
            StartPricePerHectar = startPricePerHectar;
            Expected = expected;
            this.municipality = municipality;
            AuctionedPrice = auctionedPrice;
            BestBuyerGuid = bestBuyerGuid;
            this.public_bidding_type = public_bidding_type;
            AddresGuid = addressGuid;
            LeasePeriod = leasePeriod;
            DepositReplenishmentAmount = depositReplenishmentAmount;
            this.Round = round;
            this.biddingStatus = biddingStatus;
        }

         public PublicBidding(

         DateTime date,
         DateTime startDate,
         DateTime endDate,
         int startPricePerHectar,
         string expected,
         Municipality municipality,
         int auctionedPrice,
         Guid bestBuyerGuid,
         PublicBiddingType public_bidding_type,
         Address addressGuid,
         int leasePeriod,
         int depositReplenishmentAmount,
         Guid round,
         BiddingStatus biddingStatus
          )
        {
            Guid =Guid.NewGuid();
            Date = date;
            StartDate = startDate;
            EndDate = endDate;
            StartPricePerHectar = startPricePerHectar;
            Expected = expected;
            this.municipality = municipality;
            AuctionedPrice = auctionedPrice;
            BestBuyerGuid = bestBuyerGuid;
            this.public_bidding_type = public_bidding_type;
            AddresGuid = addressGuid;
            LeasePeriod = leasePeriod;
            DepositReplenishmentAmount = depositReplenishmentAmount;
            this.Round = round;
            this.biddingStatus = biddingStatus;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> results = new List<ValidationResult>();

            if (Guid == Guid.Empty)
            {
                results.Add(new ValidationResult("Guid cannot be empty."));
            }


            if (Date > EndDate)
            {
                results.Add(new ValidationResult("Date cannot be greater than EndDate."));
            }

            if (StartDate > EndDate)
            {
                results.Add(new ValidationResult("StartDate cannot be greater than EndDate."));
            }

            if (AuctionedPrice < StartPricePerHectar)
            {
                results.Add(new ValidationResult("AuctionedPrice cannot be less than StartPricePerHectar."));
            }

            if (LeasePeriod <= 0)
            {
                results.Add(new ValidationResult("LeasePeriod must be greater than 0."));
            }

            if (DepositReplenishmentAmount <= 0)
            {
                results.Add(new ValidationResult("DepositReplenishmentAmount must be greater than 0."));
            }

            if (string.IsNullOrEmpty(Expected))
            {
                results.Add(new ValidationResult("Expected must not be empty."));
            }

            if (municipality == null)
            {
                results.Add(new ValidationResult("municipality must not be null."));
            }

            if (public_bidding_type == null)
            {
                results.Add(new ValidationResult("public_bidding_type must not be null."));
            }

            if (AddresGuid == null)
            {
                results.Add(new ValidationResult("AddresGuid must not be null."));
            }

            if (biddingStatus == null)
            {
                results.Add(new ValidationResult("biddingStatus must not be null."));
            }


            if (Round == Guid.Empty)
            {
                results.Add(new ValidationResult("Guid cannot be empty."));
            }


            if (BestBuyerGuid == Guid.Empty)
            {
                results.Add(new ValidationResult("Guid cannot be empty."));
            }


            return results;
        }





        [GeneratedRegex("^[a-zA-Z0-9._-]+$")]
        private static partial Regex usernameValidationRegex();

    }
}
