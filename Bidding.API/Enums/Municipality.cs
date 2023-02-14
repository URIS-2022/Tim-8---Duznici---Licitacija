using System.Text.Json;
using System.Text.Json.Serialization;


namespace Bidding.API.Enums
{

    public enum Municipality
    {
        None = 0,
        Cantavir,
        BackiVinogradi,
        Bikovo,
        Dudin,
        Zednik,
        Tavankut,
        Bajmok,
        DonjiGrad,
        StariGrad,
        NoviGrad,
        Palic
    }
    public class MunicipalityConverter : JsonConverter<Municipality>
    {
        private readonly Dictionary<Municipality, string> _muncipalityMapping = new Dictionary<Municipality, string>
        {
         { Municipality.None, "Nije dodeljeno" },
         { Municipality.Cantavir, "Čantavir" },
         { Municipality.BackiVinogradi, "Bački Vinogradi" },
         { Municipality.Bikovo, "Bikovo" },
         { Municipality.Dudin, "Đuđin" },
         { Municipality.Zednik, "Žednik" },
         { Municipality.Tavankut, "Tavankut" },
         { Municipality.Bajmok, "Bajmok" },
         { Municipality.DonjiGrad, "DonjiGrad" },
         { Municipality.StariGrad, "StariGrad" },
         { Municipality.NoviGrad, "NoviGrad" },
         { Municipality.Palic, "Palić" }
        };

        public override Municipality Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string muncipalityString = reader.GetString() ?? "Nije dodeljeno";
            foreach (var muncipalityMapping in _muncipalityMapping)
            {
                if (muncipalityMapping.Value == muncipalityString)
                {
                    return muncipalityMapping.Key;
                }
            }

            throw new JsonException($"Unable to map muncipality string '{muncipalityString}' to Municipality.");
        }

        public override void Write(Utf8JsonWriter writer, Municipality value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(_muncipalityMapping[value]);
        }
    }
}
