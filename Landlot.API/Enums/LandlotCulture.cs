using System.Text.Json.Serialization;
using System.Text.Json;

namespace Landlot.API.Enums
{
    public enum LandlotCulture
    {
        Njive,
        Vrtovi,
        Voćnjaci,
        Vinogradi,
        Livade,
        Pasnjaci,
        Sume,
        TrsticiMocvare
    }
    public class LandlotCultureConverter : JsonConverter<LandlotCulture>
    {
        private readonly Dictionary<LandlotCulture, string> _cultureMapping = new()
    {
        { LandlotCulture.Njive, "Njive" },
        { LandlotCulture.Vrtovi, "Vrtovi" },
        { LandlotCulture.Voćnjaci, "Voćnjaci" },
        { LandlotCulture.Vinogradi, "Vinogradi" },
        { LandlotCulture.Livade, "Livade" },
        { LandlotCulture.Pasnjaci, "Pašnjaci" },
        { LandlotCulture.Sume, "Šume" },
        { LandlotCulture.TrsticiMocvare, "Trstici-močvare" }
    };

        public override LandlotCulture Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string cultureString = reader.GetString();
            foreach (var culture in _cultureMapping)
            {
                if (culture.Value == cultureString)
                {
                    return culture.Key;
                }
            }

            throw new JsonException($"Unable to map culture string '{cultureString}' to LandlotCulture.");
        }

        public override void Write(Utf8JsonWriter writer, LandlotCulture value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(_cultureMapping[value]);
        }
    }


}
