using System.Text.Json.Serialization;
using System.Text.Json;

namespace Landlot.API.Enums
{
    public enum LandlotProcessing
    {
        Obradivo,
        Ostalo
    }
    public class LandlotProcessingConverter : JsonConverter<LandlotProcessing>
    {
        private readonly Dictionary<LandlotProcessing, string> _processingMapping = new()
    {
        { LandlotProcessing.Obradivo, "Obradivo" },
        { LandlotProcessing.Ostalo, "Ostalo" }
    };

        public override LandlotProcessing Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string processingString = reader.GetString() ?? "Ostalo";
            foreach (var processing in _processingMapping)
            {
                if (processing.Value == processingString)
                {
                    return processing.Key;
                }
            }

            throw new JsonException($"Unable to map processing string '{processingString}' to LandlotProcessing.");
        }

        public override void Write(Utf8JsonWriter writer, LandlotProcessing value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(_processingMapping[value]!);
        }
    }

}
