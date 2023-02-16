using System.Text.Json.Serialization;
using System.Text.Json;

namespace Landlot.API.Enums
{
    /// <summary>
    /// Specifies the type of property ownership for a land lot.
    /// </summary>
    public enum LandlotPropertyType
    {
        /// <summary>
        /// The land lot is privately owned.
        /// </summary>
        PrivatnaSvojina,

        /// <summary>
        /// The land lot is owned by the state.
        /// </summary>
        DrzavnaSvojina,

        /// <summary>
        /// The land lot is owned by the Republic of Serbia.
        /// </summary>
        DrzavnaSvojinaRS,

        /// <summary>
        /// The land lot is owned by a social organization or institution.
        /// </summary>
        DrustvenaSvojina,

        /// <summary>
        /// The land lot is owned by a cooperative or communal organization.
        /// </summary>
        ZadruznaSvojina,

        /// <summary>
        /// The land lot has a mixed ownership structure.
        /// </summary>
        MesovitaSvojina,

        /// <summary>
        /// The land lot has a different or unspecified ownership structure.
        /// </summary>
        DrugiOblici
    }
    /// <summary>
    /// Converts a <see cref="LandlotPropertyType"/> value to and from JSON.
    /// </summary>
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

        /// <summary>
        /// Reads and converts the JSON representation of the <see cref="LandlotPropertyType"/> enumeration.
        /// </summary>
        /// <param name="reader">The reader used to read the JSON.</param>
        /// <param name="typeToConvert">The type of object being converted.</param>
        /// <param name="options">The serializer options to use.</param>
        /// <returns>The deserialized <see cref="LandlotPropertyType"/> enumeration value.</returns>
        public override LandlotPropertyType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string? propertyString = reader.GetString();
            foreach (var property in _landlotPropertyTypeMapping)
            {
                if (property.Value == propertyString)
                {
                    return property.Key;
                }
            }

            throw new JsonException($"Unable to map property string '{propertyString}' to LandlotMunicipality value.");
        }


        /// <summary>
        /// Writes the JSON representation of the specified <see cref="LandlotPropertyType"/> enumeration value.
        /// </summary>
        /// <param name="writer">The writer used to write the JSON.</param>
        /// <param name="value">The <see cref="LandlotPropertyType"/> enumeration value to write.</param>
        /// <param name="options">The serializer options to use.</param>
        public override void Write(Utf8JsonWriter writer, LandlotPropertyType value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(_landlotPropertyTypeMapping[value]!);
        }

    }

}
