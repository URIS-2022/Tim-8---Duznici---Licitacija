using System.Text.Json.Serialization;
using System.Text.Json;

namespace Landlot.API.Enums
{
    /// <summary>
    /// Specifies the type of drainage used on a land lot.
    /// </summary>
    public enum LandlotDrainage
    {
        /// <summary>
        /// The land lot is drained by traditional drainage methods.
        /// </summary>
        Odvodnjavanje
    }
    /// <summary>
    /// Provides custom conversion logic for the <see cref="LandlotDrainage"/> enumeration when
    /// it is serialized or deserialized with Newtonsoft.Json.
    /// </summary>
    public class LandlotDrainageConverter : JsonConverter<LandlotDrainage>
    {
        /// <summary>
        /// Reads and converts the JSON representation of the <see cref="LandlotDrainage"/> enumeration.
        /// </summary>
        /// <param name="reader">The reader used to read the JSON.</param>
        /// <param name="typeToConvert">The type of object being converted.</param>
        /// <param name="options">The serializer options to use.</param>
        /// <returns>The deserialized <see cref="LandlotDrainage"/> enumeration value.</returns>
        public override LandlotDrainage Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string? value = reader.GetString();
            return value switch
            {
                "Odvodnjavanje" => LandlotDrainage.Odvodnjavanje,
                _ => throw new JsonException($"Unexpected value '{value}' for {typeof(LandlotDrainage)}"),
            };
        }
        /// <summary>
        /// Writes the JSON representation of the specified <see cref="LandlotDrainage"/> enumeration value.
        /// </summary>
        /// <param name="writer">The writer used to write the JSON.</param>
        /// <param name="value">The <see cref="LandlotDrainage"/> enumeration value to write.</param>
        /// <param name="options">The serializer options to use.</param>
        public override void Write(Utf8JsonWriter writer, LandlotDrainage value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString()!);
        }
    }

}
