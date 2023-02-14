using System.Text.Json.Serialization;
using System.Text.Json;

namespace Landlot.API.Enums
{
    public enum LandlotDrainage
    {
       Odvodnjavanje
    }
    public class LandlotDrainageConverter : JsonConverter<LandlotDrainage>
    {
        public override LandlotDrainage Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string value = reader.GetString();
            return value switch
            {
                "Odvodnjavanje" => LandlotDrainage.Odvodnjavanje,
                _ => throw new JsonException($"Unexpected value '{value}' for {typeof(LandlotDrainage)}"),
            };
        }

        public override void Write(Utf8JsonWriter writer, LandlotDrainage value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString()!);
        }
    }

}
