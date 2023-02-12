using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;


namespace Bidding.API.Entities
{
    public partial class Representative : IValidatableObject
    {
        public Guid Guid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentificationNumber { get; set; }
        public Guid AddressGuid { get; set; }

        public int NumberOfBoard { get; set; }

        public Guid PublicBiddingGuid { get; set; }

        public Address address { get; set; }
        public PublicBidding publicBidding { get; set; }

        public List<BuyerApplication> buyerApplications { get; set; }

        public  ICollection<BiddingOffer> BiddingOffers { get; set; }

        public Representative() { }


        public Representative(Guid representative_Guid, string firstName, string lastName, string identificationNumber,
                         Guid addressGuid, int numberOfBoard, Guid publicBiddingGuid)
        {
            Guid = representative_Guid;
            FirstName = firstName;
            LastName = lastName;
            IdentificationNumber = identificationNumber;
            AddressGuid = addressGuid;
            NumberOfBoard = numberOfBoard;
            PublicBiddingGuid = publicBiddingGuid;
        }

        public Representative(string firstName, string lastName, string identificationNumber,
                         Guid addressGuid, int numberOfBoard, Guid publicBiddingGuid)
        {
            Guid = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            IdentificationNumber = identificationNumber;
            AddressGuid = addressGuid;
            NumberOfBoard = numberOfBoard;
            PublicBiddingGuid = publicBiddingGuid;
        }



        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            if (Guid == Guid.Empty)
            {
                errors.Add(new ValidationResult("Guid cannot be empty."));
            }

            if (string.IsNullOrEmpty(FirstName))
            {
                errors.Add(new ValidationResult("First name cannot be empty."));
            }
            if (string.IsNullOrEmpty(LastName))
            {
                errors.Add(new ValidationResult("Last name cannot be empty."));
            }
            if (string.IsNullOrEmpty(IdentificationNumber))
            {
                errors.Add(new ValidationResult("Identification number cannot be empty."));
            }
            if (AddressGuid == Guid.Empty)
            {
                errors.Add(new ValidationResult("Guid cannot be empty."));
            }
            if (NumberOfBoard <= 0)
            {
                errors.Add(new ValidationResult("Number of board must be greater than 0."));
            }
            if (PublicBiddingGuid == Guid.Empty)
            {
                errors.Add(new ValidationResult("Guid cannot be empty."));
            }
            return errors;
        }
    }
}

