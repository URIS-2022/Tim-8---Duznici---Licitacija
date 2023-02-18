namespace Bidding.API.Models
{
    public class RepresentativeRequestModel
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentificationNumber { get; set; }

        public Guid addressGuid { get; set; }

        public int NumberOfBoard { get; set; }

        public Guid PublicBiddingGuid { get; set; }



        public RepresentativeRequestModel() { }

        public RepresentativeRequestModel(string firstName, string lastName, string identificationNumber,
                         Guid addressGuid, int numberOfBoard, Guid publicBidding)
        {

            FirstName = firstName;
            LastName = lastName;
            IdentificationNumber = identificationNumber;
            this.addressGuid = addressGuid;
            NumberOfBoard = numberOfBoard;
            this.PublicBiddingGuid = publicBidding;

        }
    }
}
