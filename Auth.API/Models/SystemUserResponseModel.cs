using Auth.API.Enums;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Auth.API.Models;

[DataContract(Name = "SystemUser", Namespace = "")]
public class SystemUserResponseModel
{
    [DataMember]
    public string FirstName { get; set; }
    [DataMember]
    public string LastName { get; set; }
    [DataMember]
    public string Username { get; set; }
    [JsonConverter(typeof(SystemUserRoleConverter))]
    [DataMember(Name = "Role")]
    public SystemUserRole Role { get; set; }

    public SystemUserResponseModel(string firstName, string lastName, string username, SystemUserRole role)
    {
        FirstName = firstName;
        LastName = lastName;
        Username = username;
        Role = role;
    }
}
