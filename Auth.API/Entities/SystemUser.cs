using Auth.API.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Auth.API.Entities;

/// <summary>
/// SystemUser is a partial class that represents a user in the system.
/// It implements IValidatableObject for data validation.
/// </summary>
public partial class SystemUser : IValidatableObject
{
    /// <summary>
    /// Gets or sets the Guid property.
    /// Represents the unique identifier of the SystemUser.
    /// </summary>
    public Guid Guid { get; set; }

    /// <summary>
    /// Gets or sets the FirstName property.
    /// Represents the first name of the SystemUser.
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Gets or sets the LastName property.
    /// Represents the last name of the SystemUser.
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Gets or sets the Username property.
    /// Represents the username of the SystemUser.
    /// </summary>
    public string Username { get; set; }

    /// <summary>
    /// Gets or sets the Password property.
    /// Represents the password of the SystemUser.
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    /// Gets or sets the Role property.
    /// Represents the role of the SystemUser.
    /// </summary>
    [JsonConverter(typeof(SystemUserRoleConverter))]
    public SystemUserRole Role { get; set; }

    /// <summary>
    /// Initializes a new instance of the SystemUser class with the given parameters.
    /// </summary>
    /// <param name="id">The Guid value to be assigned to Guid property.</param>
    /// <param name="firstName">The string value to be assigned to FirstName property.</param>
    /// <param name="lastName">The string value to be assigned to LastName property.</param>
    /// <param name="username">The string value to be assigned to Username property.</param>
    /// <param name="password">The string value to be assigned to Password property.</param>
    /// <param name="role">The SystemUserRole value to be assigned to Role property. The default value is SystemUserRole.None.</param>
    public SystemUser(Guid id, string firstName, string lastName, string username, string password, SystemUserRole role = SystemUserRole.None)
    {
        Guid = id;
        FirstName = firstName;
        LastName = lastName;
        Username = username;
        Password = password;
        Role = role;
    }

    /// <summary>
    /// Initializes a new instance of the SystemUser class with the given parameters.
    /// </summary>
    /// <param name="firstName">The string value to be assigned to FirstName property.</param>
    /// <param name="lastName">The string value to be assigned to LastName property.</param>
    /// <param name="username">The string value to be assigned to Username property.</param>
    /// <param name="password">The string value to be assigned to Password property.</param>
    /// <param name="role">The SystemUserRole value to be assigned to Role property. The default value is SystemUserRole.None.</param>
    public SystemUser(string firstName, string lastName, string username, string password, SystemUserRole role = SystemUserRole.None)
    {
        Guid = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        Username = username;
        Password = password;
        Role = role;
    }

    /// <summary>
    /// Validates the properties of the `SystemUser` object to ensure they meet certain criteria.
    /// </summary>
    /// <param name="validationContext">The context in which validation is being performed.</param>
    /// <returns>A collection of validation results indicating any errors or issues with the properties.</returns>
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

