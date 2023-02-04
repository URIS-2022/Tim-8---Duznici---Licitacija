using Auth.API.Enums;
using System.Text.Json.Serialization;

namespace Auth.API.Models;

public class SystemUserResponseModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    [JsonConverter(typeof(SystemUserRoleConverter))]
    public SystemUserRole Role { get; set; }

    public SystemUserResponseModel(string firstName, string lastName, string username, SystemUserRole role)
    {
        FirstName = firstName;
        LastName = lastName;
        Username = username;
        Role = role;
    }
}
