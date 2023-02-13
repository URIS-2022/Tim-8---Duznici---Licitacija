using Bidding.API.Entities;
using Bidding.API.Enums;
using System.Text.Json.Serialization;

namespace Bidding.API.Models
{
    public class RepresentativeRequestModel
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentificationNumber { get; set; }
        public Address address { get; set; }

        public int NumberOfBoard { get; set; }

        public Guid PublicBiddingGuid { get; set; }

        // public List<BuyerApplication> BuyerRepresentatives { get; set; }

        public RepresentativeRequestModel() { }

        public RepresentativeRequestModel(string firstName, string lastName, string identificationNumber,
                         Address address, int numberOfBoard, Guid publicBidding)
        {
            
            FirstName = firstName;
            LastName = lastName;
            IdentificationNumber = identificationNumber;
            this.address = address;
            NumberOfBoard = numberOfBoard;
            this.PublicBiddingGuid = publicBidding;
            
        }
    }
}
