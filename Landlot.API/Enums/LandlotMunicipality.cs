using System.Text.Json.Serialization;
using System.Text.Json;

namespace Landlot.API.Enums;

/// <summary>
/// Specifies the municipality in which a land lot is located.
/// </summary>
public enum LandlotMunicipality
{
    /// <summary>
    /// The land lot is located in the Bikovo municipality.
    /// </summary>
    Bikovo,
    /// <summary>
    /// The land lot is located in the Bajmok municipality.
    /// </summary>
    Bajmok,
    /// <summary>
    /// The land lot is located in the Palic municipality.
    /// </summary>
    Palic,
    /// <summary>
    /// The land lot is located in the Stari Grad municipality.
    /// </summary>
    StariGrad,
    /// <summary>
    /// The land lot is located in the Novi Grad municipality.
    /// </summary>
    NoviGrad,
    /// <summary>
    /// The land lot is located in the Donji Grad municipality.
    /// </summary>
    DonjiGrad,
    /// <summary>
    /// The land lot is located in the Zednik municipality.
    /// </summary>
    Zednik,
    /// <summary>
    /// The land lot is located in the Djurdjin municipality.
    /// </summary>
    Djurdjin,
    /// <summary>
    /// The land lot is located in the Tavankut municipality.
    /// </summary>
    Tavankut,
    /// <summary>
    /// The land lot is located in the Backi Vinogradi municipality.
    /// </summary>
    BackiVinogradi,
    /// <summary>
    /// The land lot is located in the Cantavir municipality.
    /// </summary>
    Cantavir
}

/// <summary>
/// Provides custom conversion logic for the <see cref="LandlotMunicipality"/> enumeration when
/// it is serialized or deserialized with Newtonsoft.Json.
/// </summary>
public class LandlotMunicipalityConverter : JsonConverter<LandlotMunicipality>
{
    private readonly Dictionary<LandlotMunicipality, string> _municipalityMapping = new()
{
    { LandlotMunicipality.Bikovo, "Opština Bikovo" },
    { LandlotMunicipality.Bajmok, "Opština Bajmok" },
    { LandlotMunicipality.Palic, "Opština Palić" },
    { LandlotMunicipality.StariGrad, "Opština Stari grad" },
    { LandlotMunicipality.NoviGrad, "Opština Novi grad" },
    { LandlotMunicipality.DonjiGrad, "Opština Donji grad" },
    { LandlotMunicipality.Zednik, "Opština Žednik" },
    { LandlotMunicipality.Djurdjin, "Opština Đurđin" },
    { LandlotMunicipality.Tavankut, "Opština Tavankut" },
    { LandlotMunicipality.BackiVinogradi, "Opština Bački Vinogradi" },
    { LandlotMunicipality.Cantavir, "Opština Čantavir" }
};

    /// <summary>
    /// Reads and converts the JSON representation of the <see cref="LandlotMunicipality"/> enumeration.
    /// </summary>
    /// <param name="reader">The reader used to read the JSON.</param>
    /// <param name="typeToConvert">The type of object being converted.</param>
    /// <param name="options">The serializer options to use.</param>
    /// <returns>The deserialized <see cref="LandlotMunicipality"/> enumeration value.</returns>
    public override LandlotMunicipality Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? municipalityString = reader.GetString();
        foreach (var municipality in _municipalityMapping)
        {
            if (municipality.Value == municipalityString)
            {
                return municipality.Key;
            }
        }

        throw new JsonException($"Unable to map municipality string '{municipalityString}' to LandlotMunicipality value.");
    }
    /// <summary>
    /// Writes the JSON representation of the specified <see cref="LandlotMunicipality"/> enumeration value.
    /// </summary>
    /// <param name="writer">The writer used to write the JSON.</param>
    /// <param name="value">The <see cref="LandlotMunicipality"/> enumeration value to write.</param>
    /// <param name="options">The serializer options to use.</param>
    public override void Write(Utf8JsonWriter writer, LandlotMunicipality value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(_municipalityMapping[value]!);
    }

}
