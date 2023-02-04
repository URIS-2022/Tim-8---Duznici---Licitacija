using Auth.API.Enums;
using System.Text.Json.Serialization;

namespace Auth.API.Models;

public class SystemUser
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    [JsonConverter(typeof(SystemUserRoleConverter))]
    public SystemUserRole Role { get; set; }

    public SystemUser(Guid id, string firstName, string lastName, string username, string password, SystemUserRole role = SystemUserRole.None)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Username = username;
        Password = password;
        Role = role;
    }

    public SystemUser(string firstName, string lastName, string username, string password, SystemUserRole role = SystemUserRole.None)
    {
        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        Username = username;
        Password = password;
        Role = role;
    }
}

