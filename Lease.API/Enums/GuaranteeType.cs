using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Lease.API.Enums;

public enum GuaranteeType
{
    None = 0,
    Surety,
    Bank,
    RealEstate,
    Guarantor,
    Payment
}

[NotMapped]
public class GuaranteeTypeConverter : JsonConverter<GuaranteeType>
{
    private readonly Dictionary<GuaranteeType, string> _guaranteeTypeMapping = new Dictionary<GuaranteeType, string>
{
    { GuaranteeType.None, "Nije dodeljeno" },
    { GuaranteeType.Surety, "Jemstvo" },
    { GuaranteeType.Bank, "Bankarska garancija" },
    { GuaranteeType.RealEstate, "Garancija nektretninom" },
    { GuaranteeType.Guarantor, "Zirantska" },
    { GuaranteeType.Payment, "Uplata Gotovinom" },

};

    public override GuaranteeType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string guaranteeTypeString = reader.GetString() ?? "Nije dodeljeno";
        foreach (var guaranteeTypeMapping in _guaranteeTypeMapping)
        {
            if (guaranteeTypeMapping.Value == guaranteeTypeString)
            {
                return guaranteeTypeMapping.Key;
            }
        }

        throw new JsonException($"Unable to map Guarantee Type string '{guaranteeTypeString}' to Guarantee Type.");
    }

    public override void Write(Utf8JsonWriter writer, GuaranteeType value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(_guaranteeTypeMapping[value]);
    }
}
