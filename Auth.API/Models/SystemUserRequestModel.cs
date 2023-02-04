using Auth.API.Enums;
using System.Text.Json.Serialization;

namespace Auth.API.Models;

public class SystemUserRequestModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    [JsonConverter(typeof(SystemUserRoleConverter))]
    public SystemUserRole Role { get; set; }

    public SystemUserRequestModel(string firstName, string lastName, string username, string password, SystemUserRole role = SystemUserRole.None)
    {
        FirstName = firstName;
        LastName = lastName;
        Username = username;
        Password = password;
        Role = role;
    }
}
