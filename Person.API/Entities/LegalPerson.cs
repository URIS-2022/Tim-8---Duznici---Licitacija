using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Person.API.Entities
{
    public class LegalPerson : IValidatableObject
    {
        public Guid LegalPersonId { get; set; }
        public string Name { get; set; }
        public string IdentificationNumber { get; set; }
        public Guid AddressId { get; set; }
        public string PhoneNumber1 { get; set; }
        public string PhoneNumber2 { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string AccountNumber { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            // Validate Name
            if (string.IsNullOrWhiteSpace(Name))
            {
                results.Add(new ValidationResult("Name is required"));
            }
            else if (Name.Length > 100)
            {
                results.Add(new ValidationResult("Name cannot be longer than 100 characters"));
            }

            // Validate IdentificationNumber
            if (string.IsNullOrWhiteSpace(IdentificationNumber))
            {
                results.Add(new ValidationResult("IdentificationNumber is required"));
            }
            else if (IdentificationNumber.Length > 20)
            {
                results.Add(new ValidationResult("IdentificationNumber cannot be longer than 20 characters"));
            }

            // Validate PhoneNumber1
            if (string.IsNullOrWhiteSpace(PhoneNumber1))
            {
                results.Add(new ValidationResult("PhoneNumber1 is required"));
            }
            else if (PhoneNumber1.Length > 20)
            {
                results.Add(new ValidationResult("PhoneNumber1 cannot be longer than 20 characters"));
            }

            // Validate PhoneNumber2
            if (!string.IsNullOrWhiteSpace(PhoneNumber2) && PhoneNumber2.Length > 20)
            {
                results.Add(new ValidationResult("PhoneNumber2 cannot be longer than 20 characters"));
            }

            // Validate Fax
            if (!string.IsNullOrWhiteSpace(Fax) && Fax.Length > 20)
            {
                results.Add(new ValidationResult("Fax cannot be longer than 20 characters"));
            }

            // Validate Email
            if (!string.IsNullOrWhiteSpace(Email) && Email.Length > 100)
            {
                results.Add(new ValidationResult("Email cannot be longer than 100 characters"));
            }

            // Validate AccountNumber
            if (!string.IsNullOrWhiteSpace(AccountNumber) && AccountNumber.Length > 20)
            {
                results.Add(new ValidationResult("AccountNumber cannot be longer than 20 characters"));
            }

            return results;
        }
    }


}
