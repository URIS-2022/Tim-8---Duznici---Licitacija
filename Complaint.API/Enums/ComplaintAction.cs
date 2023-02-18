using System.Text.Json;
using System.Text.Json.Serialization;

namespace Complaint.API.Enums;

/// <summary>
/// Action to be taken for the complaint
/// </summary>
public enum ComplaintAction
{
    /// <summary>
    /// No second round
    /// </summary>
    NoSecondRound = 0,

    /// <summary>
    /// Second round with new conditions
    /// </summary>
    SecondRoundNewConditions,
    /// <summary>
    /// Second round with same conditions
    /// </summary>
    SecondRoundSameConditions
}

/// <summary>
/// JSON converter for ComplaintAction
/// </summary>
public class ComplaintActionConverter : JsonConverter<ComplaintAction>
{
    private readonly Dictionary<ComplaintAction, string> _actionMapping = new()
    {
        { ComplaintAction.SecondRoundNewConditions, "JN ide u drugi krug sa novim uslovima" },
        { ComplaintAction.SecondRoundSameConditions, "JN ide u drugi krug sa starim uslovima" },
        { ComplaintAction.NoSecondRound, "JN ne ide u drugi krug" },
    };

    /// <summary>
    /// Read override for ComplaintActionConverter
    /// </summary>
    /// <param name="reader"> Utf8JsonReader for ComplaintActionConverter</param>
    /// <param name="typeToConvert"> Type to convert for ComplaintActionConverter</param>
    /// <param name="options"> JsonSerializerOptions for ComplaintActionConverter</param>
    /// <returns> ComplaintAction</returns>
    /// <exception cref="JsonException"> Unable to map role string to complaint action</exception>
    public override ComplaintAction Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string actionString = reader.GetString() ?? "JN ne ide u drugi krug";
        foreach (var action in _actionMapping)
        {
            if (action.Value == actionString)
            {
                return action.Key;
            }
        }

        throw new JsonException($"Unable to map role string '{actionString}' to complaint action.");
    }

    /// <summary>
    /// Write override for ComplaintActionConverter
    /// </summary>
    /// <param name="writer"> Utf8JsonWriter for ComplaintActionConverter</param>
    /// <param name="value"> ComplaintAction to write</param>
    /// <param name="options"> JsonSerializerOptions for ComplaintActionConverter</param>
    public override void Write(Utf8JsonWriter writer, ComplaintAction value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(_actionMapping[value]);
    }
}
