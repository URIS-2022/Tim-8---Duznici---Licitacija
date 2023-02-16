using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;


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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Function { get; set; }
        public string PhoneNumber { get; set; }


        public ContactPerson(string firstName, string lastName, string function, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Function = function;
            PhoneNumber = phoneNumber;

        }

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
