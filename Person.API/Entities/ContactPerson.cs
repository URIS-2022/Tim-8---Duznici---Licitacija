using System.ComponentModel.DataAnnotations;


namespace Person.API.Entities
{
    /// <summary>
    /// Represents a contact person.
    /// Implements the IValidatableObject interface for custom validation logic.
    /// </summary>
    public class ContactPerson : IValidatableObject
    {
        /// <summary>
        /// Gets or sets the unique identifier for a contact person record.
        /// </summary>
        [Key]
        public Guid ContactPersonId { get; set; }
        /// <summary>The first name of the contact person.</summary>
        public string? FirstName { get; set; }
        /// <summary>The last name of the contact person.</summary>
        public string? LastName { get; set; }
        /// <summary>The function or role of the contact person.</summary>
        public string? Function { get; set; }
        /// <summary>The phone number of the contact person.</summary>
        public string? PhoneNumber { get; set; }

               /**
            <summary>Initializes a new instance of the ContactPerson class.</summary>
            <param name="firstName">The first name of the contact person.</param>
            <param name="lastName">The last name of the contact person.</param>
            <param name="function">The function or role of the contact person.</param>
            <param name="phoneNumber">The phone number of the contact person.</param>
               */
        public ContactPerson(string? firstName, string? lastName, string? function, string? phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Function = function;
            PhoneNumber = phoneNumber;

        }
        /// <summary>Initializes a new instance of the ContactPerson class.</summary>
        public ContactPerson() { }

        /// <summary>
        /// Validates the ContactPerson object using the specified validation context and returns a collection of validation results.
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

            // Validate Function
            if (!string.IsNullOrWhiteSpace(Function) && Function.Length > 50)
            {
                results.Add(new ValidationResult("Function cannot be longer than 50 characters"));
            }

            // Validate PhoneNumber
            if (string.IsNullOrWhiteSpace(PhoneNumber))
            {
                results.Add(new ValidationResult("PhoneNumber is required"));
            }
            else if (PhoneNumber.Length > 20)
            {
                results.Add(new ValidationResult("PhoneNumber cannot be longer than 20 characters"));
            }

            return results;
        }
    }

}
