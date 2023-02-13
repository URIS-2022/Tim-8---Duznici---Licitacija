using Landlot.API.Enums;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Landlot.API.Models
{
    public class LandPostRequestModel
    {
        public decimal TotalArea { get; set; }

        [JsonConverter(typeof(LandlotMunicipalityConverter))]
        public LandlotMunicipality Municipality { get; set; }
        public string RealEstateNumber { get; set; }
        [JsonConverter(typeof(LandlotCultureConverter))]
        public LandlotCulture Culture { get; set; }

        [JsonConverter(typeof(LandlotClassConverter))]
        public LandlotClass LandClass { get; set; }

        [JsonConverter(typeof(LandlotProcessingConverter))]
        public LandlotProcessing Processing { get; set; }

        [JsonConverter(typeof(LandlotProtectedZoneConverter))]
        public LandlotProtectedZone Zone { get; set; }

        [JsonConverter(typeof(LandlotPropertyTypeConverter))]
        public LandlotPropertyType Property { get; set; }

        [JsonConverter(typeof(LandlotDrainageConverter))]
        public LandlotDrainage Drainage { get; set; }

        public LandPostRequestModel (decimal totalArea, LandlotMunicipality municipality, string realEstateNumber, LandlotCulture culture, LandlotClass landClass, LandlotProcessing processing, LandlotProtectedZone zone, LandlotPropertyType property, LandlotDrainage drainage)
        {
            TotalArea = totalArea;
            Municipality = municipality;
            RealEstateNumber = realEstateNumber;
            Culture = culture;
            LandClass = landClass;
            Processing = processing;
            Zone = zone;
            Property = property;
            Drainage = drainage;
        }
    }
}
