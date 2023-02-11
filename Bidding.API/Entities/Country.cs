using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;



namespace Bidding.API.Entities
{
    public partial class Country : IValidatableObject
    {

        public Guid Guid { get; set; }
        public string Name { get; set; }

        public Country() { }

        public Country(Guid id, string name)
        {
            Guid = id;
            Name = name;
            
        }

        public Country( string name)
        {
            Guid = Guid.NewGuid();
            Name = name;

        }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (Guid == Guid.Empty)
            {
                results.Add(new ValidationResult("Guid cannot be empty."));
            }

            if (string.IsNullOrWhiteSpace(Name))
            {
                results.Add(new ValidationResult("Name cannot be empty."));
            }
            return results;
        }

        [GeneratedRegex("^[a-zA-Z0-9._-]+$")]
        private static partial Regex usernameValidationRegex();
    }
}
