using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;


namespace Bidding.API.Entities
{
    public partial class Representative : IValidatableObject
    {
        public Guid Representative_Guid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentificationNumber { get; set; }
        public Address AddressGuid { get; set; }

        public int NumberOfBoard { get; set; }

        public PublicBidding PublicBiddingGuid { get; set; }


        public Representative(Guid representative_Guid, string firstName, string lastName, string identificationNumber,
                         Address addressGuid, int numberOfBoard, PublicBidding publicBiddingGuid)
        {
            Representative_Guid = representative_Guid;
            FirstName = firstName;
            LastName = lastName;
            IdentificationNumber = identificationNumber;
            AddressGuid = addressGuid;
            NumberOfBoard = numberOfBoard;
            PublicBiddingGuid = publicBiddingGuid;
        }

        public Representative(string firstName, string lastName, string identificationNumber,
                         Address addressGuid, int numberOfBoard, PublicBidding publicBiddingGuid)
        {
            Representative_Guid = Guid.NewGuid();
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

            if (Representative_Guid == Guid.Empty)
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
            if (AddressGuid == null)
            {
                errors.Add(new ValidationResult("Address GUID cannot be null."));
            }
            if (NumberOfBoard <= 0)
            {
                errors.Add(new ValidationResult("Number of board must be greater than 0."));
            }
            if (PublicBiddingGuid == null)
            {
                errors.Add(new ValidationResult("Public bidding GUID cannot be null."));
            }
            return errors;
        }
    }
}

