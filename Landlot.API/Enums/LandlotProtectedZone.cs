using System.Text.Json;
using System.Text.Json.Serialization;

namespace Landlot.API.Enums
{
    /// <summary>
    /// Specifies the protected zone classification for a land lot.
    /// </summary>
    public enum LandlotProtectedZone
    {
        /// <summary>
        /// Zone 1 classification.
        /// </summary>
        Zone1 = 1,

        /// <summary>
        /// Zone 2 classification.
        /// </summary>
        Zone2 = 2,

        /// <summary>
        /// Zone 3 classification.
        /// </summary>
        Zone3 = 3,

        /// <summary>
        /// Zone 4 classification.
        /// </summary>
        Zone4 = 4
    }


    /// <summary>
    /// Converts a <see cref="LandlotProtectedZone"/> value to and from JSON.
    /// </summary>
    public class LandlotProtectedZoneConverter : JsonConverter<LandlotProtectedZone>
    {
        /// <summary>
        /// Reads and converts the JSON representation of the <see cref="LandlotProtectedZone"/> enumeration.
        /// </summary>
        /// <param name="reader">The reader used to read the JSON.</param>
        /// <param name="typeToConvert">The type of object being converted.</param>
        /// <param name="options">The serializer options to use.</param>
        /// <returns>The deserialized <see cref="LandlotProtectedZone"/> enumeration value.</returns>
        public override LandlotProtectedZone Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            int zoneNumber = reader.GetInt32();
            return (LandlotProtectedZone)zoneNumber;
        }

        /// <summary>
        /// Writes the JSON representation of the specified <see cref="LandlotProtectedZone"/> enumeration value.
        /// </summary>
        /// <param name="writer">The writer used to write the JSON.</param>
        /// <param name="value">The <see cref="LandlotProtectedZone"/> enumeration value to write.</param>
        /// <param name="options">The serializer options to use.</param>
        public override void Write(Utf8JsonWriter writer, LandlotProtectedZone value, JsonSerializerOptions options)
        {
            writer.WriteNumberValue((int)value!);
        }
    }

}
