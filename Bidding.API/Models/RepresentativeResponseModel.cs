using Bidding.API.Entities;
using Bidding.API.Enums;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace Bidding.API.Models
{
    [DataContract(Name = "Representative", Namespace = "")]
    public class RepresentativeResponseModel
    {
        
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string IdentificationNumber { get; set; }
        [DataMember]
        public Address address { get; set; }
        
        [DataMember]

        public int NumberOfBoard { get; set; }
        
        [DataMember]
        public PublicBidding publicBidding { get; set; }

        [DataMember]
        public List<BuyerApplication> BuyerRepresentatives { get; set; }

        public RepresentativeResponseModel(string firstName, string lastName, string identificationNumber,
                         Address address, int numberOfBoard, PublicBidding publicBidding, List<BuyerApplication> buyerRepresentatives)
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
