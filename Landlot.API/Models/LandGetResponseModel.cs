using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Landlot.API.Enums;

namespace Landlot.API.Models
{

    [DataContract(Name = "Land", Namespace = "")]
    public class LandGetResponseModel
    {
        [DataMember]
        public Guid LandGuid { get; set; }

        [DataMember]
        public int TotalArea { get; set; }

        [JsonConverter(typeof(LandlotMunicipalityConverter))]
        [DataMember]
        public LandlotMunicipality Municipality { get; set; }

        [DataMember]
        public string RealEstateNumber { get; set; }

        [JsonConverter(typeof(LandlotCultureConverter))]
        [DataMember]

        public LandlotCulture Culture { get; set; }

        [JsonConverter(typeof(LandlotClassConverter))]
        [DataMember]
        public LandlotClass LandClass { get; set; }

        [JsonConverter(typeof(LandlotProcessingConverter))]
        [DataMember]
        public LandlotProcessing Processing { get; set; }

        [JsonConverter(typeof(LandlotProtectedZoneConverter))]
        [DataMember]
        public LandlotProtectedZone Zone { get; set; }

        [JsonConverter(typeof(LandlotPropertyTypeConverter))]
        [DataMember]
        public LandlotPropertyType Property { get; set; }

        [JsonConverter(typeof(LandlotDrainageConverter))]
        [DataMember]
        public LandlotDrainage Drainage { get; set; }


        public LandGetResponseModel(Guid guid, int area, LandlotMunicipality municipality, string estateNumber, LandlotCulture culture,
                                    LandlotClass landclass, LandlotProcessing processing,LandlotProtectedZone zone,
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




    
       
