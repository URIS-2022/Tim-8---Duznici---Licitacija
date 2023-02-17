using Person.API.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Person.API.Entities
{
    /// <summary>
    /// Represents a physical address that can be validated for correctness.
    /// </summary>
    public class Address : IValidatableObject
    {
        /// <summary>
        /// Gets or sets the unique identifier for a address record.
        /// </summary>
        [Key]
        public Guid AddressId { get; set; }

        [JsonConverter(typeof(CountryConverter))]
        public Country Country { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string Place { get; set; }
        public string ZipCode { get; set; }

        


        /// <summary>
        /// Validates the Address object using the specified validation context and returns a collection of validation results.
        /// </summary>
        /// <param name="validationContext">The validation context used for validation.</param>
        /// <returns>An IEnumerable of ValidationResult objects representing the validation errors, if any.</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            // Validate Country
            if (!Enum.IsDefined(typeof(Country), Country) || Country.Equals(default(Country)))
            {
                results.Add(new ValidationResult("Country is required."));
            }

            // Validate Street
            if (string.IsNullOrWhiteSpace(Street))
            {
                results.Add(new ValidationResult("Street is required"));
            }
            else if (Street.Length > 50)
            {
                results.Add(new ValidationResult("Street cannot be longer than 50 characters"));
            }

            // Validate StreetNumber
            if (string.IsNullOrWhiteSpace(StreetNumber))
            {
                results.Add(new ValidationResult("StreetNumber is required"));
            }
            else if (StreetNumber.Length > 10)
            {
                results.Add(new ValidationResult("StreetNumber cannot be longer than 10 characters"));
            }

            // Validate Place
            if (string.IsNullOrWhiteSpace(Place))
            {
                results.Add(new ValidationResult("Place is required"));
            }
            else if (Place.Length > 50)
            {
                results.Add(new ValidationResult("Place cannot be longer than 50 characters"));
            }

            // Validate ZipCode
            if (string.IsNullOrWhiteSpace(ZipCode))
            {
                results.Add(new ValidationResult("ZipCode is required"));
            }
            else if (ZipCode.Length > 10)
            {
                results.Add(new ValidationResult("ZipCode cannot be longer than 10 characters"));
            }

            return results;
        }
    }


}
