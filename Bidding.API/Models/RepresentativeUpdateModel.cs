﻿using Bidding.API.Entities;
using Bidding.API.Enums;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Bidding.API.Models
{
    public class RepresentativeUpdateModel
    {


       // public Guid Guid {get; set;}
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? IdentificationNumber { get; set; }

        public Guid addressGuid { get; set; }



        public int? NumberOfBoard { get; set; }


        public Guid PublicBiddingGuid { get; set; }

        public RepresentativeUpdateModel() { }


        // public List<BuyerApplication> BuyerRepresentatives { get; set; }

        public RepresentativeUpdateModel(string? firstName, string? lastName, string? identificationNumber,
                         Guid addressGuid, int? numberOfBoard, Guid publicBiddingGuid)
        {
            
            FirstName = firstName;
            LastName = lastName;
            IdentificationNumber = identificationNumber;
            this.addressGuid = addressGuid;
            NumberOfBoard = numberOfBoard;
            PublicBiddingGuid = publicBiddingGuid;
           
        }
    }
}
