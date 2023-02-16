using System.Text.Json.Serialization;
using System.Text.Json;

namespace Landlot.API.Enums
{
    /// <summary>
    /// Represents the class state of a landlot, which reflects its agricultural productivity potential.
    /// </summary>
    public enum LandlotClass
    {
        /// <summary>
        /// Represents the "I" soil classification category.
        /// </summary>
        I,
        /// <summary>
        /// Represents the "II" soil classification category.
        /// </summary>
        II,
        /// <summary>
        /// Represents the "III" soil classification category.
        /// </summary>
        III,
        /// <summary>
        /// Represents the "IV" soil classification category.
        /// </summary>
        IV,
        /// <summary>
        /// Represents the "V" soil classification category.
        /// </summary>
        V,
        /// <summary>
        /// Represents the "VI" soil classification category.
        /// </summary>
        VI,
        /// <summary>
        /// Represents the "VII" soil classification category.
        /// </summary>
        VII,
        /// <summary>
        /// Represents the "VIII" soil classification category.
        /// </summary>
        VIII
    }
    /// <summary>
    /// Provides custom JSON serialization and deserialization for the LandlotClass enum.
    /// </summary>
    /// <remarks>
    /// The LandlotClassConverter class can be used to convert a JSON representation of a LandlotClass enum value to an instance of the LandlotClass type, and vice versa.
    /// This can be useful when serializing or deserializing Land objects to or from JSON format, for example.
    /// </remarks>

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

        /// <summary>
        /// Reads the JSON representation of a LandlotClass enum value and converts it to an instance of the LandlotClass type.
        /// </summary>
        /// <param name="reader">The Utf8JsonReader that contains the JSON data to be read.</param>
        /// <param name="typeToConvert">The target type to convert to, which should be LandlotClass.</param>
        /// <param name="options">The JsonSerializerOptions to use for deserialization.</param>
        /// <returns>An instance of the LandlotClass type that corresponds to the JSON value that was read.</returns>
        /// <remarks>
        /// The Read method is called by the JSON serializer to convert a JSON representation of a LandlotClass enum value to an instance of the LandlotClass type.
        /// The method reads the JSON data from the reader parameter and returns an instance of the LandlotClass type that corresponds to the JSON value that was read.
        /// </remarks>
        public override LandlotClass Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {


            string? classString = reader.GetString();
            foreach (var item in _classMapping)
            {
                if (item.Value == classString)
                {
                    return item.Key;
                }
            }

            throw new JsonException($"Unable to map class string '{classString}' to LandlotClass.");
        }

        /// <summary>
        /// Writes a LandlotClass value to JSON format using the specified Utf8JsonWriter.
        /// </summary>
        /// <param name="writer">The Utf8JsonWriter to use for writing the JSON data.</param>
        /// <param name="value">The LandlotClass value to write to JSON format.</param>
        /// <param name="options">The JsonSerializerOptions to use for serialization.</param>
        /// <remarks>
        /// The Write method is called by the JSON serializer to convert a LandlotClass value to a JSON representation.
        /// The method writes the JSON data to the writer parameter in the specified format.
        /// </remarks>
        /// 
        public override void Write(Utf8JsonWriter writer, LandlotClass value, JsonSerializerOptions options)
        {
            string classString;
            if (_classMapping.TryGetValue(value, out classString!))
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
