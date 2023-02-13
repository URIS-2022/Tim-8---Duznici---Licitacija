using Auth.API.Enums;
using System.Text.Json.Serialization;

namespace Auth.API.Models;

/// <summary>
/// The DTO class for updating system user information.
/// </summary>
public class SystemUserPatchRequestModel
{
    /// <summary>
    /// Gets or sets the last name of the system user.
    /// </summary>
    public string? FirstName { get; set; }

    /// <summary>
    /// Gets or sets the first name of the system user.
    /// </summary>
    public string? LastName { get; set; }

    /// <summary>
    /// Gets or sets the username of the system user.
    /// </summary>
    public string? Username { get; set; }

    /// <summary>
    /// Gets or sets the password of the system user.
    /// </summary>
    public string? Password { get; set; }

    /// <summary>
    /// Gets or sets the role of the system user.
    /// </summary>
    [JsonConverter(typeof(SystemUserRoleConverter))]
    public SystemUserRole? Role { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="SystemUserPatchRequestModel"/> class.
    /// </summary>
    /// <param name="firstName">The first name of the system user.</param>
    /// <param name="lastName">The last name of the system user.</param>
    /// <param name="username">The username of the system user.</param>
    /// <param name="password">The password of the system user.</param>
    /// <param name="role">The role of the system user.</param>
    public SystemUserPatchRequestModel(string? firstName, string? lastName, string? username, string? password, SystemUserRole? role)
    {
        FirstName = firstName;
        LastName = lastName;
        Username = username;
        Password = password;
        Role = role;
    }
}
