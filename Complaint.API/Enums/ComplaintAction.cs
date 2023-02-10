using System.Text.Json.Serialization;
using System.Text.Json;

namespace Complaint.API.Enums;

public enum ComplaintAction
{
    SecondRoundNewConditions,
    SecondRoundSameConditions,
    NoSecondRound
}

public class ComplaintActionConverter : JsonConverter<ComplaintAction>
{
    private readonly Dictionary<ComplaintAction, string> _actionMapping = new()
    {
        { ComplaintAction.SecondRoundNewConditions, "JN ide u drugi krug sa novim uslovima" },
        { ComplaintAction.SecondRoundSameConditions, "JN ide u drugi krug sa starim uslovima" },
        { ComplaintAction.NoSecondRound, "JN ne ide u drugi krug" },
    };

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

    public override void Write(Utf8JsonWriter writer, ComplaintAction value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(_actionMapping[value]);
    }
}
