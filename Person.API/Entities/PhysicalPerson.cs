using System.ComponentModel.DataAnnotations;

namespace Person.API.Entities
{
    public class PhysicalPerson : IValidatableObject
    {
        public Guid PhysicalPersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Jmbg { get; set; }
        public Guid AddressId { get; set; }
        public string PhoneNumber1 { get; set; }
        public string PhoneNumber2 { get; set; }
        public string Email { get; set; }
        public string AccountNumber { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            // Validate FirstName
            if (string.IsNullOrWhiteSpace(FirstName))
            {
                results.Add(new ValidationResult("FirstName is required"));
            }
            else if (FirstName.Length > 50)
            {
                results.Add(new ValidationResult("FirstName cannot be longer than 50 characters"));
            }

            // Validate LastName
            if (string.IsNullOrWhiteSpace(LastName))
            {
                results.Add(new ValidationResult("LastName is required"));
            }
            else if (LastName.Length > 50)
            {
                results.Add(new ValidationResult("LastName cannot be longer than 50 characters"));
            }

            // Validate Jmbg
            if (!string.IsNullOrWhiteSpace(Jmbg) && Jmbg.Length > 13)
            {
                results.Add(new ValidationResult("Jmbg cannot be longer than 13 characters"));
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

            // Validate Email
            if (!string.IsNullOrWhiteSpace(Email) && Email.Length > 50)
            {
                results.Add(new ValidationResult("Email cannot be longer than 50 characters"));
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
