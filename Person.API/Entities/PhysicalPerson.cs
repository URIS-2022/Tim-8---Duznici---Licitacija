using System.ComponentModel.DataAnnotations;

namespace Person.API.Entities
{
    /// <summary>
    /// Represents a physical person.
    /// Implements the IValidatableObject interface for custom validation logic.
    /// </summary>
    public class PhysicalPerson : IValidatableObject
    {
        /// <summary>
        /// Gets or sets the unique identifier for a physical person record.
        /// </summary>
        [Key] 
        public Guid PhysicalPersonId { get; set; }
        /// <summary>
        /// Gets or sets the first name of the physical person.
        /// </summary>
        public string? FirstName { get; set; }
        /// <summary>
        /// Gets or sets the last name of the physical person.
        /// </summary>
        public string? LastName { get; set; }
        /// <summary>
        /// Gets or sets the JMBG (Unique Master Citizen Number) of the physical person.
        /// </summary>
        public string? Jmbg { get; set; }
        /// <summary>
        /// Gets or sets the unique identifier for the address of the physical person.
        /// </summary>
        public Guid AddressId { get; set; }
        /// <summary>
        /// Gets or sets the primary phone number of the physical person.
        /// </summary>
        public string? PhoneNumber1 { get; set; }
        /// <summary>
        /// Gets or sets the secondary phone number of the physical person.
        /// </summary>
        public string? PhoneNumber2 { get; set; }
        /// <summary>
        /// Gets or sets the email address of the physical person.
        /// </summary>
        public string? Email { get; set; }
        /// <summary>
        /// Gets or sets the account number of the physical person.
        /// </summary>
        public string? AccountNumber { get; set; }

        /// <summary>
        /// Gets or sets the contact person associated with the physical person.
        /// </summary>
        public Address? Address { get; set; }

        /// <summary>
        /// Validates the PyhsicalPerson object using the specified validation context and returns a collection of validation results.
        /// </summary>
        /// <param name="validationContext">The validation context used for validation.</param>
        /// <returns>An IEnumerable of ValidationResult objects representing the validation errors, if any.</returns>
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
