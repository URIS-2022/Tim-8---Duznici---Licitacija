using System.Text.Json.Serialization;
using System.Text.Json;

namespace Landlot.API.Enums
{
    public enum LandlotProtectedZone
    {
        Zone1 = 1,
        Zone2 = 2,
        Zone3 = 3,
        Zone4 = 4
    }

    public class LandlotProtectedZoneConverter : JsonConverter<LandlotProtectedZone>
    {
        public override LandlotProtectedZone Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            int zoneNumber = reader.GetInt32();
            return (LandlotProtectedZone)zoneNumber;
        }

        public override void Write(Utf8JsonWriter writer, LandlotProtectedZone value, JsonSerializerOptions options)
        {
            writer.WriteNumberValue((int)value);
        }
    }

}
