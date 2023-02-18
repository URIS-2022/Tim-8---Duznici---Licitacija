using System.Text.Json;
using System.Text.Json.Serialization;

namespace Complaint.API.Enums;

/// <summary>
/// Status of the complaint
/// </summary>
public enum ComplaintStatus
{
    /// <summary>
    /// Complaint is opened
    /// </summary>
    Opened = 0,

    /// <summary>
    /// Complaint is rejected
    /// </summary>
    Rejected,

    /// <summary>
    /// Complaint is accepted
    /// </summary>
    Accepted
}

/// <summary>
/// Converts complaint status to string and vice versa
/// </summary>
public class ComplaintStatusConverter : JsonConverter<ComplaintStatus>
{
    private readonly Dictionary<ComplaintStatus, string> _statusMapping = new()
    {
        { ComplaintStatus.Opened, "Otvorena" },
        { ComplaintStatus.Rejected, "Odbijena" },
        { ComplaintStatus.Accepted, "Usvojena" }
    };

    /// <summary>
    /// Reads complaint status from string
    /// </summary>
    /// <param name="reader"> Utf8JsonReader for reading complaint status</param>
    /// <param name="typeToConvert"> Type to convert for ComplaintStatusConverter</param>
    /// <param name="options"> JsonSerializerOptions for ComplaintStatusConverter</param>
    /// <returns> ComplaintStatus</returns>
    /// <exception cref="JsonException"> Unable to map role string to complaint status</exception>
    public override ComplaintStatus Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string statusString = reader.GetString() ?? "Otvorena";
        foreach (var status in _statusMapping)
        {
            if (status.Value == statusString)
            {
                return status.Key;
            }
        }

        throw new JsonException($"Unable to map role string '{statusString}' to complaint status.");
    }

    /// <summary>
    /// Writes complaint status to string
    /// </summary>
    /// <param name="writer"> Utf8JsonWriter for writing complaint status</param>
    /// <param name="value"> ComplaintStatus to write</param>
    /// <param name="options"> JsonSerializerOptions for ComplaintStatusConverter</param>
    public override void Write(Utf8JsonWriter writer, ComplaintStatus value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(_statusMapping[value]);
    }
}
