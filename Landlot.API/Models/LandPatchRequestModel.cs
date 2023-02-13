using Landlot.API.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Landlot.API.Models
{
    public class LandPatchRequestModel
    {
        public decimal? TotalArea { get; set; }

        [JsonConverter(typeof(LandlotMunicipalityConverter))]
     
        public LandlotMunicipality? Municipality { get; set; }

        public string? RealEstateNumber { get; set; }

        [JsonConverter(typeof(LandlotCultureConverter))]

        public LandlotCulture? Culture { get; set; }

        [JsonConverter(typeof(LandlotClassConverter))]
        public LandlotClass? LandClass { get; set; }

        [JsonConverter(typeof(LandlotProcessingConverter))]
        public LandlotProcessing? Processing { get; set; }

        [JsonConverter(typeof(LandlotProtectedZoneConverter))]
        public LandlotProtectedZone? Zone { get; set; }

        [JsonConverter(typeof(LandlotPropertyTypeConverter))]
        public LandlotPropertyType? Property { get; set; }

        [JsonConverter(typeof(LandlotDrainageConverter))]
        public LandlotDrainage? Drainage { get; set; }

        public LandPatchRequestModel(decimal area, LandlotMunicipality municipality, string estateNumber, LandlotCulture culture,
                                    LandlotClass landclass, LandlotProcessing processing, LandlotProtectedZone zone,
                                    LandlotPropertyType property, LandlotDrainage drainage)
        {
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
