using System.Runtime.Serialization;


namespace Bidding.API.Models
{
    [DataContract(Name = "Representative", Namespace = "")]
    public class RepresentativeResponseModel
    {
        [DataMember]
        public Guid Guid { get; set; }
        
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string IdentificationNumber { get; set; }
        [DataMember]
        public AdressResponseModel address { get; set; }

        [DataMember]
        public Guid AddressGuid { get; set; }
        
        [DataMember]

        public int NumberOfBoard { get; set; }
        
       [DataMember]
        public RepresentativePublicBiddingResponseModel publicBidding { get; set; }

        [DataMember]
        public IEnumerable<RepresentativeBuyerApplicationResponseModel> BuyerApplications { get; set; }

        public RepresentativeResponseModel() { }

        public RepresentativeResponseModel(Guid guid,Guid addressGuid,string firstName, string lastName, string identificationNumber,
                         AdressResponseModel address, int numberOfBoard, RepresentativePublicBiddingResponseModel publicbidding, ICollection<RepresentativeBuyerApplicationResponseModel> buyerApplications)
        {
            Guid = guid;
            AddressGuid =addressGuid;
            FirstName = firstName;
            LastName = lastName;
            IdentificationNumber = identificationNumber;
            this.address = address;
            NumberOfBoard = numberOfBoard;
            publicBidding = publicbidding;
            BuyerApplications = buyerApplications;
        }
    }
}
