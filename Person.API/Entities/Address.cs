using System.ComponentModel.DataAnnotations;

namespace Person.API.Entities
{
    public class Address : IValidatableObject
    {
        public Guid AddressId { get; set; }
        public string Country { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string Place { get; set; }
        public string ZipCode { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            // Validate Country
            if (string.IsNullOrWhiteSpace(Country))
            {
                results.Add(new ValidationResult("Country is required"));
            }
            else if (Country.Length > 50)
            {
                results.Add(new ValidationResult("Country cannot be longer than 50 characters"));
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
