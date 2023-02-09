using System.Text.Json;
using System.Text.Json.Serialization;

namespace Auth.API.Enums;
public enum SystemUserRole
{
    None = 0,
    Operator,
    TechSecretary,
    FirstCommission,
    Superuser,
    BiddingOperator,
    Bidder,
    Manager,
    Admin
}

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

    public override void Write(Utf8JsonWriter writer, SystemUserRole value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(_roleMapping[value]);
    }
}
