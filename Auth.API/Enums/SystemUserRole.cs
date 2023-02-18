using System.Text.Json;
using System.Text.Json.Serialization;

namespace Auth.API.Enums;

/// <summary>
/// The SystemUserRole enumeration defines the different roles a user can have in the system.
/// </summary>
public enum SystemUserRole
{

    /// <summary>
    /// The user has no role assigned.
    /// </summary>
    None = 0,

    /// <summary>
    /// The user is an operator.
    /// </summary>
    Operator,

    /// <summary>
    /// The user is a technical secretary.
    /// </summary>
    TechSecretary,

    /// <summary>
    /// The user is a member of the first commission.
    /// </summary>
    FirstCommission,

    /// <summary>
    /// The user is a superuser.
    /// </summary>
    Superuser,

    /// <summary>
    /// The user is a bidding operator.
    /// </summary>
    BiddingOperator,

    /// <summary>
    /// The user is a bidder.
    /// </summary>
    Bidder,

    /// <summary>
    /// The user is a manager.
    /// </summary>
    Manager,

    /// <summary>
    /// The user is an administrator.
    /// </summary>
    Admin
}


/// <summary>
/// The SystemUserRoleConverter class provides a custom implementation for converting the SystemUserRole enum to and from JSON.
/// </summary>
public class SystemUserRoleConverter : JsonConverter<SystemUserRole>
{
    private readonly Dictionary<SystemUserRole, string> _roleMapping = new Dictionary<SystemUserRole, string>
    {
        { SystemUserRole.None, "Nije dodeljeno" },
        { SystemUserRole.Operator, "Operater" },
        { SystemUserRole.TechSecretary, "Tehnički sekretar" },
        { SystemUserRole.FirstCommission, "Prva komisija" },
        { SystemUserRole.Superuser, "Superkorisnik" },
        { SystemUserRole.BiddingOperator, "Operater nadmetanja" },
        { SystemUserRole.Bidder, "Licitant" },
        { SystemUserRole.Manager, "Menadžer" },
        { SystemUserRole.Admin, "Administrator" },
    };

    /// <summary>
    /// Reads the SystemUserRole value from a JSON reader.
    /// </summary>
    /// <param name="reader">The JSON reader to read from.</param>
    /// <param name="typeToConvert">The type to convert to.</param>
    /// <param name="options">The JSON serializer options.</param>
    /// <returns>The SystemUserRole value read from the JSON reader.</returns>
    public override SystemUserRole Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string roleString = reader.GetString() ?? "Nije dodeljeno";
        foreach (var roleMapping in _roleMapping)
        {
            if (roleMapping.Value == roleString)
            {
                return roleMapping.Key;
            }
        }

        throw new JsonException($"Unable to map role string '{roleString}' to SystemUserRole.");
    }

    /// <summary>
    /// Writes the SystemUserRole value to a JSON writer.
    /// </summary>
    /// <param name="writer">The JSON writer to write to.</param>
    /// <param name="value">The SystemUserRole value to write.</param>
    /// <param name="options">The JSON serializer options.</param>
    public override void Write(Utf8JsonWriter writer, SystemUserRole value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(_roleMapping[value]);
    }
}
