using Bidding.API.Entities;
using Bidding.API.Enums;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Bidding.API.Models
{
    public class RepresentativeUpdateModel
    {

        

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? IdentificationNumber { get; set; }

        public Address? address { get; set; }



        public int? NumberOfBoard { get; set; }


        public PublicBidding? publicBidding { get; set; }

        
        public List<BuyerApplication> BuyerRepresentatives { get; set; }

        public RepresentativeUpdateModel(string? firstName, string? lastName, string? identificationNumber,
                         Address? address, int? numberOfBoard, PublicBidding? publicBidding, List<BuyerApplication> buyerRepresentatives)
        {
            
            FirstName = firstName;
            LastName = lastName;
            IdentificationNumber = identificationNumber;
            this.address = address;
            NumberOfBoard = numberOfBoard;
            this.publicBidding = publicBidding;
            BuyerRepresentatives = buyerRepresentatives;
        }
    }
}
