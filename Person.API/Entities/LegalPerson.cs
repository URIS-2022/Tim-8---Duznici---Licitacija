using System.ComponentModel.DataAnnotations;

namespace Person.API.Entities
{
    /// <summary>
    /// Represents a legal person.
    /// Implements the IValidatableObject interface for custom validation logic.
    /// </summary>
    public class LegalPerson : IValidatableObject
    {
        /// <summary>
        /// Gets or sets the unique identifier for a legal person record.
        /// </summary>
        [Key]
        public Guid LegalPersonId { get; set; }
        /// <summary>
        /// Gets or sets the unique identifier of the contact person associated with the legal person.
        /// </summary>
        public Guid ContactPersonId { get; set; }
        /// <summary>
        /// Gets or sets the name of the legal person.
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Gets or sets the identification number of the legal person.
        /// </summary>
        public string? IdentificationNumber { get; set; }
        /// <summary>
        /// Gets or sets the unique identifier of the address associated with the legal person.
        /// </summary>
        public Guid AddressId { get; set; }
        /// <summary>
        /// Gets or sets the first phone number of the legal person.
        /// </summary>
        public string? PhoneNumber1 { get; set; }
        /// <summary>
        /// Gets or sets the second phone number of the legal person.
        /// </summary>
        public string? PhoneNumber2 { get; set; }
        /// <summary>
        /// Gets or sets the fax number of the legal person.
        /// </summary>
        public string? Fax { get; set; }
        /// <summary>
        /// Gets or sets the email of the legal person.
        /// </summary>
        public string? Email { get; set; }
        /// <summary>
        /// Gets or sets the account number of the legal person.
        /// </summary>
        public string? AccountNumber { get; set; }
        /// <summary>
        /// Gets or sets the address associated with the legal person.
        /// </summary>

        public Address? Address { get; set; }
        /// <summary>
        /// Gets or sets the contact person associated with the legal person.
        /// </summary>
        public ContactPerson? ContactPerson { get; set; }

        

        /// <summary>
        /// Validates the LegalPerson object using the specified validation context and returns a collection of validation results.
        /// </summary>
        /// <param name="validationContext">The validation context used for validation.</param>
        /// <returns>An IEnumerable of ValidationResult objects representing the validation errors, if any.</returns>
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
