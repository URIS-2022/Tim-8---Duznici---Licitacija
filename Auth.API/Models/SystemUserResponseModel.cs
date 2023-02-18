using Auth.API.Enums;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Auth.API.Models;

/// <summary>
/// SystemUserResponseModel is a model class used to represent a response for a system user.
/// </summary>
[DataContract(Name = "SystemUser", Namespace = "")]
public class SystemUserResponseModel
{
    /// <summary>
    /// Gets or sets the last name of the system user.
    /// </summary>
    [DataMember]
    public string FirstName { get; set; }

    /// <summary>
    /// Gets or sets the last name of the system user.
    /// </summary>
    [DataMember]
    public string LastName { get; set; }

    /// <summary>
    /// Gets or sets the username of the system user.
    /// </summary>
    [DataMember]
    public string Username { get; set; }

    /// <summary>
    /// Gets or sets the role of the system user.
    /// </summary>
    [JsonConverter(typeof(SystemUserRoleConverter))]
    [DataMember(Name = "Role")]
    public SystemUserRole Role { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="SystemUserResponseModel"/> class.
    /// </summary>
    /// <param name="firstName">The first name of the system user.</param>
    /// <param name="lastName">The last name of the system user.</param>
    /// <param name="username">The username of the system user.</param>
    /// <param name="role">The role of the system user.</param>
    public SystemUserResponseModel(string firstName, string lastName, string username, SystemUserRole role)
    {
        FirstName = firstName;
        LastName = lastName;
        Username = username;
        Role = role;
    }
}
