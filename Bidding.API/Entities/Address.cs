using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;


namespace Bidding.API.Entities
{
    public partial class Address : IValidatableObject
    {

        public Guid AddressGuid { get; set; }
        public Country country { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string Place { get; set; }
        public string ZipCode { get; set; }

        public Address(Guid id,Country country, string street, string streetNumber, string place, string zipCode)
        {
            AddressGuid = id;
            this.country = country;
            Street = street;
            StreetNumber = streetNumber;
            Place = place;
            ZipCode = zipCode;
        }

        public Address(Country country, string street, string streetNumber, string place, string zipCode)
        {
            AddressGuid = Guid.NewGuid();
            this.country = country;
            Street = street;
            StreetNumber = streetNumber;
            Place = place;
            ZipCode = zipCode;
        }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> results = new List<ValidationResult>();

            if (AddressGuid == Guid.Empty)
            {
                results.Add(new ValidationResult("Guid cannot be empty."));
            }

            if (country == null)
                results.Add(new ValidationResult("Country cannot be null."));

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
