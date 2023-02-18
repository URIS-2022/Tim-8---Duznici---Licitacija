using System.Text.Json;
using System.Text.Json.Serialization;

namespace Person.API.Enums
{
    /// <summary>
    /// Enum representing countries.
    /// </summary>
    public enum Country
    {
        /// <summary>
        /// Represents the "Srbija" country.
        /// </summary>
        Srbija,
        /// <summary>
        /// Represents the "Crna Gora" country.
        /// </summary>
        CrnaGora,
        /// <summary>
        /// Represents the "Bosna i Hercegovina" country.
        /// </summary>
        BiH,
        /// <summary>
        /// Represents the "Madjarska" country.
        /// </summary>
        Madjarska,
        /// <summary>
        /// Represents the "Hrvatska" country.
        /// </summary>
        Hrvatska
    }
    /// <summary>
    /// JSON converter for <see cref="Country"/> enum.
    /// </summary>
    public class CountryConverter : JsonConverter<Country>
    {
        private readonly Dictionary<Country, string> _countryMapping = new()
    {
        { Country.Srbija, "Srbija" },
        { Country.CrnaGora, "Crna Gora" },
        { Country.BiH, "Bosna i Hercegovina" },
        { Country.Madjarska, "Madjarska" },
        { Country.Hrvatska, "Hrvatska" }
    };

        /// <summary>
        /// Reads the JSON representation of the object and converts it to an instance of <see cref="Country"/>.
        /// </summary>
        /// <param name="reader">The <see cref="Utf8JsonReader"/> to read from.</param>
        /// <param name="typeToConvert">The type of object to convert.</param>
        /// <param name="options">The <see cref="JsonSerializerOptions"/> being used.</param>
        /// <returns>The converted object.</returns>
        public override Country Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string? countryString = reader.GetString();
            foreach (var country in _countryMapping)
            {
                if (country.Value == countryString)
                {
                    return country.Key;
                }
            }

            throw new JsonException($"Unable to map counrty string '{countryString}' to Country.");
        }
        /// <summary>
        /// Writes a JSON representation of the <paramref name="value"/> object to the specified <see cref="Utf8JsonWriter"/>.
        /// </summary>
        /// <param name="writer">The <see cref="Utf8JsonWriter"/> to write to.</param>
        /// <param name="value">The value to write.</param>
        /// <param name="options">The <see cref="JsonSerializerOptions"/> being used.</param>
        public override void Write(Utf8JsonWriter writer, Country value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(_countryMapping[value]!);
        }
    }
}










