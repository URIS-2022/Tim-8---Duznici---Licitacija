using System.Text.Json;
using System.Text.Json.Serialization;

namespace Complaint.API.Enums;

/// <summary>
/// Type of the complaint
/// </summary>
public enum ComplaintType
{
    /// <summary>
    /// None
    /// </summary>
    None = 0,
    /// <summary>
    /// Bidding complaint
    /// </summary>
    BiddingComplaint,
    /// <summary>
    /// Lease complaint
    /// </summary>
    LeaseComplaint,
    /// <summary>
    /// Use permit complaint
    /// </summary>
    UsePermitComplaint
}

/// <summary>
/// Converts ComplaintType to string and vice versa
/// </summary>
public class ComplaintTypeConverter : JsonConverter<ComplaintType>
{
    private readonly Dictionary<ComplaintType, string> _typeMapping = new()
    {
        { ComplaintType.None, "Nije dodeljeno" },
        { ComplaintType.BiddingComplaint, "Žalba na tok javnog nadmetanja" },
        { ComplaintType.LeaseComplaint, "Žalba na Odluku o davanju u zakup" },
        { ComplaintType.UsePermitComplaint, "Žalba na Odluku o davanju na korišćenje" }
    };

    /// <summary>
    /// Reads complaint type from string
    /// </summary>
    /// <param name="reader"> Utf8JsonReader for reading complaint type</param>
    /// <param name="typeToConvert"> Type to convert for ComplaintTypeConverter</param>
    /// <param name="options"> JsonSerializerOptions for ComplaintTypeConverter</param>
    /// <returns> ComplaintType</returns>
    /// <exception cref="JsonException"> Unable to map role string to complaint type</exception>
    public override ComplaintType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string typeString = reader.GetString() ?? "Nije dodeljeno";
        foreach (var typeMapping in _typeMapping)
        {
            if (typeMapping.Value == typeString)
            {
                return typeMapping.Key;
            }
        }

        throw new JsonException($"Unable to map role string '{typeString}' to complaint type.");
    }

    /// <summary>
    /// Writes complaint type to string
    /// </summary>
    /// <param name="writer"> Utf8JsonWriter for writing complaint type</param>
    /// <param name="value"> ComplaintType to write</param>
    /// <param name="options"> JsonSerializerOptions for ComplaintTypeConverter</param>
    public override void Write(Utf8JsonWriter writer, ComplaintType value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(_typeMapping[value]);
    }
}
