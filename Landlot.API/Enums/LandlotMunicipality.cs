using System.Text.Json.Serialization;
using System.Text.Json;

namespace Landlot.API.Enums;

public enum LandlotMunicipality
{
    Bikovo,
    Bajmok,
    Palic,
    StariGrad,
    NoviGrad,
    DonjiGrad,
    Zednik,
    Djurdjin,
    Tavankut,
    BackiVinogradi,
    Cantavir
}

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

    public override LandlotMunicipality Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string municipalityString = reader.GetString();
        foreach (var municipality in _municipalityMapping)
        {
            if (municipality.Value == municipalityString)
            {
                return municipality.Key;
            }
        }

        throw new JsonException($"Unable to map municipality string '{municipalityString}' to LandlotMunicipality value.");
    }
    public override void Write(Utf8JsonWriter writer, LandlotMunicipality value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(_municipalityMapping[value]);
    }

}
