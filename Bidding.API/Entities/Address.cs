using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;


namespace Bidding.API.Entities
{
    public partial class Address : IValidatableObject
    {

        public Guid Guid { get; set; }
        public string Country { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string Place { get; set; }
        public string ZipCode { get; set; }

        public List<Representative> Representatives { get; set; }

        public ICollection<PublicBidding> PublicBiddings { get; set; }

        public Address() { }

        public Address(Guid id, string country, string street, string streetNumber, string place, string zipCode)
        {
            Guid = id;
            Country = country;
            Street = street;
            StreetNumber = streetNumber;
            Place = place;
            ZipCode = zipCode;
        }

        public Address(string country, string street, string streetNumber, string place, string zipCode)
        {
            Guid = Guid.NewGuid();
            Country = country;
            Street = street;
            StreetNumber = streetNumber;
            Place = place;
            ZipCode = zipCode;
        }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> results = new List<ValidationResult>();

            if (Guid == Guid.Empty)
            {
                results.Add(new ValidationResult("Guid cannot be empty."));
            }

            if (string.IsNullOrWhiteSpace(Country))
                results.Add(new ValidationResult("Country cannot be empty or whitespace."));

            if (string.IsNullOrWhiteSpace(Street))
                results.Add(new ValidationResult("Street cannot be empty or whitespace."));

            if (string.IsNullOrWhiteSpace(StreetNumber))
                results.Add(new ValidationResult("Street number cannot be empty or whitespace."));

            if (string.IsNullOrWhiteSpace(Place))
                results.Add(new ValidationResult("Place cannot be empty or whitespace."));

            if (string.IsNullOrWhiteSpace(ZipCode))
                results.Add(new ValidationResult("Zip code cannot be empty or whitespace."));

            return results;
        }

        [GeneratedRegex("^[a-zA-Z0-9._-]+$")]
        private static partial Regex usernameValidationRegex();
    }
}
