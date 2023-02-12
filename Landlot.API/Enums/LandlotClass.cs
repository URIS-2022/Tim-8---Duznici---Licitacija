using System.Text.Json.Serialization;
using System.Text.Json;

namespace Landlot.API.Enums
{
    public enum LandlotClass
    {
        I,
        II,
        III,
        IV,
        V,
        VI,
        VII,
        VIII
    }

    public class LandlotClassConverter : JsonConverter<LandlotClass>
    {
        private readonly Dictionary<LandlotClass, string> _classMapping = new()
    {
        { LandlotClass.I, "I" },
        { LandlotClass.II, "II" },
        { LandlotClass.III, "III" },
        { LandlotClass.IV, "IV" },
        { LandlotClass.V, "V" },
        { LandlotClass.VI, "VI" },
        { LandlotClass.VII, "VII" },
        { LandlotClass.VIII, "VIII" },
    };

        public override LandlotClass Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string classString = reader.GetString();
            foreach (var item in _classMapping)
            {
                if (item.Value == classString)
                {
                    return item.Key;
                }
            }

            throw new JsonException($"Unable to map class string '{classString}' to LandlotClass.");
        }

        public override void Write(Utf8JsonWriter writer, LandlotClass value, JsonSerializerOptions options)
        {
            string classString;
            if (_classMapping.TryGetValue(value, out classString))
            {
                writer.WriteStringValue(classString);
            }
            else
            {
                throw new JsonException($"Unable to find class string for LandlotClass value '{value}'.");
            }
        }
    }

}
