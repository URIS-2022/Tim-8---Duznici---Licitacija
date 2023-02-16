using Landlot.API.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Landlot.API.Models
{
    /// <summary>
    /// Model for updating a land's properties.
    /// </summary>
    public class LandPatchRequestModel
    {
        /// <summary>
        /// Gets or sets the total area of the land.
        /// </summary>
        public decimal? TotalArea { get; set; }

        /// <summary>
        /// Gets or sets the municipality where the land is located.
        /// </summary>
        [JsonConverter(typeof(LandlotMunicipalityConverter))]
        public LandlotMunicipality? Municipality { get; set; }

        /// <summary>
        /// Gets or sets the real estate number of the land.
        /// </summary>
        public string? RealEstateNumber { get; set; }

        /// <summary>
        /// Gets or sets the culture of the land.
        /// </summary>
        [JsonConverter(typeof(LandlotCultureConverter))]
        public LandlotCulture? Culture { get; set; }

        /// <summary>
        /// Gets or sets the class of the land.
        /// </summary>
        [JsonConverter(typeof(LandlotClassConverter))]
        public LandlotClass? LandClass { get; set; }

        /// <summary>
        /// Gets or sets the processing type of the land.
        /// </summary>
        [JsonConverter(typeof(LandlotProcessingConverter))]
        public LandlotProcessing? Processing { get; set; }

        /// <summary>
        /// Gets or sets the protected zone of the land.
        /// </summary>
        [JsonConverter(typeof(LandlotProtectedZoneConverter))]
        public LandlotProtectedZone? Zone { get; set; }

        /// <summary>
        /// Gets or sets the property type of the land.
        /// </summary>
        [JsonConverter(typeof(LandlotPropertyTypeConverter))]
        public LandlotPropertyType? Property { get; set; }

        /// <summary>
        /// Gets or sets the drainage type of the land.
        /// </summary>
        [JsonConverter(typeof(LandlotDrainageConverter))]
        public LandlotDrainage? Drainage { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LandPatchRequestModel"/> class with the specified parameters.
        /// </summary>
        /// <param name="totalArea">The total area of the land lot.</param>
        /// <param name="municipality">The municipality where the land lot is located.</param>
        /// <param name="realEstateNumber">The real estate number of the land lot.</param>
        /// <param name="culture">The culture of the land lot.</param>
        /// <param name="landClass">The class of the land lot.</param>
        /// <param name="processing">The processing type of the land lot.</param>
        /// <param name="zone">The protected zone of the land lot.</param>
        /// <param name="property">The property type of the land lot.</param>
        /// <param name="drainage">The drainage type of the land lot.</param>
        public LandPatchRequestModel(decimal? totalArea, LandlotMunicipality? municipality, string? realEstateNumber, LandlotCulture? culture,
                                    LandlotClass? landClass, LandlotProcessing? processing, LandlotProtectedZone? zone,
                                    LandlotPropertyType? property, LandlotDrainage? drainage)
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
