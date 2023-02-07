using Auth.API.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Auth.API.Entities;

public partial class SystemUser : IValidatableObject
{
    public Guid Guid { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    [JsonConverter(typeof(SystemUserRoleConverter))]
    public SystemUserRole Role { get; set; }

    public SystemUser(Guid id, string firstName, string lastName, string username, string password, SystemUserRole role = SystemUserRole.None)
    {
        Guid = id;
        FirstName = firstName;
        LastName = lastName;
        Username = username;
        Password = password;
        Role = role;
    }

    public SystemUser(string firstName, string lastName, string username, string password, SystemUserRole role = SystemUserRole.None)
    {
        Guid = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        Username = username;
        Password = password;
        Role = role;
    }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var results = new List<ValidationResult>();

        if (Guid == Guid.Empty)
        {
            results.Add(new ValidationResult("Guid cannot be empty."));
        }

        if (string.IsNullOrWhiteSpace(FirstName))
        {
            results.Add(new ValidationResult("FirstName cannot be empty."));
        }

        if (string.IsNullOrWhiteSpace(LastName))
        {
            results.Add(new ValidationResult("LastName cannot be empty."));
        }

        if (string.IsNullOrWhiteSpace(Username))
        {
            results.Add(new ValidationResult("Username cannot be empty."));
        }
        else if (!usernameValidationRegex().IsMatch(Username))
        {
            results.Add(new ValidationResult("Username can only contain alphanumeric characters, dots, dashes and underscores."));
        }

        if (string.IsNullOrWhiteSpace(Password))
        {
            results.Add(new ValidationResult("Password cannot be empty."));
        }

        return results;
    }

    [GeneratedRegex("^[a-zA-Z0-9._-]+$")]
    private static partial Regex usernameValidationRegex();
}

