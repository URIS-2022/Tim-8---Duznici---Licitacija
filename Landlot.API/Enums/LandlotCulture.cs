using System.Text.Json;
using System.Text.Json.Serialization;

namespace Landlot.API.Enums
{
    /// <summary>
    /// Enumerates the possible land use categories for a land lot.
    /// </summary>
    /// <remarks>
    /// The LandlotCulture enumeration represents the possible land use categories for a land lot, such as agriculture, forestry, or wetlands.
    /// The enum values correspond to the categories defined in the Croatian land use classification system, which classifies land use based on its function and economic value.
    /// The possible values are "Njive", "Vrtovi", "Voćnjaci", "Vinogradi", "Livade", "Pasnjaci", "Sume", and "TrsticiMocvare".
    /// </remarks>
    public enum LandlotCulture
    {
        /// <summary>
        /// Represents the "Njive" land use category.
        /// </summary>
        Njive,
        /// <summary>
        /// Represents the "Vrtovi" land use category.
        /// </summary>
        Vrtovi,
        /// <summary>
        /// Represents the "Njive" land use category.
        /// </summary>
        Voćnjaci,
        /// <summary>
        /// Represents the "Vinogradi" land use category.
        /// </summary>
        Vinogradi,
        /// <summary>
        /// Represents the "Livade" land use category.
        /// </summary>
        Livade,
        /// <summary>
        /// Represents the "Pasnjaci" land use category.
        /// </summary>
        Pasnjaci,
        /// <summary>
        /// Represents the "Sume" land use category.
        /// </summary>
        Sume,
        /// <summary>
        /// Represents the "Trstici Mocvare" land use category.
        /// </summary>
        TrsticiMocvare
    }
    /// <summary>
    /// Converts a <see cref="LandlotCulture"/> value to and from JSON.
    /// </summary>
    /// <remarks>
    /// This converter is used by the JSON serializer to convert LandlotCulture enum values to and from JSON.
    /// It overrides the default serialization behavior to output enum values as strings instead of integers.
    /// </remarks>

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
        /// <summary>
        /// Reads a JSON value and converts it to a <see cref="LandlotCulture"/> enum value.
        /// </summary>
        /// <param name="reader">The reader used to read the JSON value.</param>
        /// <param name="typeToConvert">The type to convert.</param>
        /// <param name="options">The serializer options.</param>
        /// <returns>A <see cref="LandlotCulture"/> enum value.</returns>
        public override LandlotCulture Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string? cultureString = reader.GetString();
            foreach (var culture in _cultureMapping)
            {
                if (culture.Value == cultureString)
                {
                    return culture.Key;
                }
            }

            throw new JsonException($"Unable to map culture string '{cultureString}' to LandlotCulture.");
        }
        /// <summary>
        /// Writes a LandlotCulture value to JSON format using the specified Utf8JsonWriter.
        /// </summary>
        /// <param name="writer">The Utf8JsonWriter to use for writing the JSON data.</param>
        /// <param name="value">The LandlotCulture value to write to JSON format.</param>
        /// <param name="options">The JsonSerializerOptions to use for serialization.</param>
        /// <remarks>
        /// The Write method is called by the JSON serializer to convert a LandlotCulture value to a JSON representation.
        /// The method writes the JSON data to the writer parameter in the specified format.
        /// </remarks>
        /// 
        public override void Write(Utf8JsonWriter writer, LandlotCulture value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(_cultureMapping[value]!);
        }
    }


}
