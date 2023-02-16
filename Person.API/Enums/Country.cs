using System.Text.Json.Serialization;
using System.Text.Json;

namespace Person.API.Enums
{
    
    public enum Country
    {
       
        Srbija,
        
        CrnaGora,
        
        BiH,
        
        Madjarska,
       
        Hrvatska
    }

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
        public override void Write(Utf8JsonWriter writer, Country value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(_countryMapping[value]!);
        }
    }
}


    
    
    

   



