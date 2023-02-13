using Landlot.API.Enums;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Landlot.API.Models
{

    [DataContract(Name = "Land", Namespace = "")]
    public class LandPatchResponseModel
    {
        [DataMember]
        public Guid LandGuid { get; set; }

        [DataMember]
        public decimal TotalArea { get; set; }

        [JsonConverter(typeof(LandlotMunicipalityConverter))]
        [DataMember(Name = "Municipality")]
        public LandlotMunicipality Municipality { get; set; }

        [DataMember]
        public string RealEstateNumber { get; set; }

        [JsonConverter(typeof(LandlotCultureConverter))]
        [DataMember(Name = "Culture")]

        public LandlotCulture Culture { get; set; }

        [JsonConverter(typeof(LandlotClassConverter))]
        [DataMember(Name = "LandClass")]
        public LandlotClass LandClass { get; set; }

        [JsonConverter(typeof(LandlotProcessingConverter))]
        [DataMember(Name = "Processing")]
        public LandlotProcessing Processing { get; set; }

        [JsonConverter(typeof(LandlotProtectedZoneConverter))]
        [DataMember(Name = "Zone")]
        public LandlotProtectedZone Zone { get; set; }

        [JsonConverter(typeof(LandlotPropertyTypeConverter))]
        [DataMember(Name = "Property")]
        public LandlotPropertyType Property { get; set; }

        [JsonConverter(typeof(LandlotDrainageConverter))]
        [DataMember(Name = "Drainage")]
        public LandlotDrainage Drainage { get; set; }


        public LandPatchResponseModel(Guid guid, decimal area, LandlotMunicipality municipality, string estateNumber, LandlotCulture culture,
                                   LandlotClass landclass, LandlotProcessing processing, LandlotProtectedZone zone,
                                   LandlotPropertyType property, LandlotDrainage drainage)
        {
            LandGuid = guid;
            TotalArea = area;
            Municipality = municipality;
            RealEstateNumber = estateNumber;
            Culture = culture;
            LandClass = landclass;
            Processing = processing;
            Zone = zone;
            Property = property;
            Drainage = drainage;

        }
    }
}
