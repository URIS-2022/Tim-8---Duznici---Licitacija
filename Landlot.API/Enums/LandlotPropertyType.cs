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
        public override LandlotPropertyType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string value = reader.GetString();
            if (string.IsNullOrEmpty(value))
            {
                return LandlotPropertyType.PrivatnaSvojina;
            }

            return value switch
            {
                "Privatna svojina" => LandlotPropertyType.PrivatnaSvojina,
                "Državna svojina" => LandlotPropertyType.DrzavnaSvojina,
                "Državna svojina RS" => LandlotPropertyType.DrzavnaSvojinaRS,
                "Društvena svojina" => LandlotPropertyType.DrustvenaSvojina,
                "Zadružna svojina" => LandlotPropertyType.ZadruznaSvojina,
                "Mešovita svojina" => LandlotPropertyType.MesovitaSvojina,
                "Drugi oblici" => LandlotPropertyType.DrugiOblici,
                _ => throw new JsonException($"Unknown value '{value}' for enum type {typeof(LandlotPropertyType).Name}.")
            };
        }

        public override void Write(Utf8JsonWriter writer, LandlotPropertyType value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString().Replace("Svojina", " svojina"));
        }
    }

}
