using System.Text.Json.Serialization;
using System.Text.Json;

namespace Landlot.API.Enums
{
    public enum LandlotPropertyType
    {
        PrivatnaSvojina,
        DrzavnaSvojina,
        DrzavnaSvojinaRS,
        DrustvenaSvojina,
        ZadruznaSvojina,
        MesovitaSvojina,
        DrugiOblici
    }

    public class LandlotPropertyTypeConverter : JsonConverter<LandlotPropertyType>
    {
        private readonly Dictionary<LandlotPropertyType, string> _landlotPropertyTypeMapping = new()
{
            { LandlotPropertyType.PrivatnaSvojina, "Privatna svojina" },
            { LandlotPropertyType.DrzavnaSvojina, "Drzavna svojina" },
            { LandlotPropertyType.DrzavnaSvojinaRS, "Drzavna svojina RS" },
            { LandlotPropertyType.DrustvenaSvojina, "Opština Stari grad" },
            { LandlotPropertyType.ZadruznaSvojina, "Zadruzna svojina" },
            { LandlotPropertyType.MesovitaSvojina, "Mesovita svojina" },
            { LandlotPropertyType.DrugiOblici, "Drugi oblici" }
        
     };

        public override LandlotPropertyType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string propertyString = reader.GetString();
            foreach (var property in _landlotPropertyTypeMapping)
            {
                if (property.Value == propertyString)
                {
                    return property.Key;
                }
            }

            throw new JsonException($"Unable to map property string '{propertyString}' to LandlotMunicipality value.");
        }
        public override void Write(Utf8JsonWriter writer, LandlotPropertyType value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(_landlotPropertyTypeMapping[value]!);
        }

    }

}
