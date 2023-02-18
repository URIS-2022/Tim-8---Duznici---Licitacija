using Landlot.API.Enums;
using System.Text.Json.Serialization;

namespace Landlot.API.Models
{
    /// <summary>
    /// Represents a request model for creating a new land.
    /// </summary>
    public class LandPostRequestModel
    {
        /// <summary>
        /// Gets or sets the total area of the land.
        /// </summary>
        public decimal TotalArea { get; set; }

        /// <summary>
        /// Gets or sets the municipality of the land.
        /// </summary>
        [JsonConverter(typeof(LandlotMunicipalityConverter))]
        public LandlotMunicipality Municipality { get; set; }

        /// <summary>
        /// Gets or sets the real estate number of the land.
        /// </summary>
        public string RealEstateNumber { get; set; }

        /// <summary>
        /// Gets or sets the culture of the land.
        /// </summary>
        [JsonConverter(typeof(LandlotCultureConverter))]
        public LandlotCulture Culture { get; set; }

        /// <summary>
        /// Gets or sets the class of the land.
        /// </summary>
        [JsonConverter(typeof(LandlotClassConverter))]
        public LandlotClass LandClass { get; set; }

        /// <summary>
        /// Gets or sets the processing of the land.
        /// </summary>
        [JsonConverter(typeof(LandlotProcessingConverter))]
        public LandlotProcessing Processing { get; set; }

        /// <summary>
        /// Gets or sets the protected zone of the land.
        /// </summary>
        [JsonConverter(typeof(LandlotProtectedZoneConverter))]
        public LandlotProtectedZone Zone { get; set; }

        /// <summary>
        /// Gets or sets the property type of the land.
        /// </summary>
        [JsonConverter(typeof(LandlotPropertyTypeConverter))]
        public LandlotPropertyType Property { get; set; }

        /// <summary>
        /// Gets or sets the drainage of the land.
        /// </summary>
        [JsonConverter(typeof(LandlotDrainageConverter))]
        public LandlotDrainage Drainage { get; set; }

        /// <summary>
        /// Initializes a new instance of the LandPostRequestModel class with the specified values.
        /// </summary>
        /// <param name="totalArea">The total area of the land.</param>
        /// <param name="municipality">The municipality of the land.</param>
        /// <param name="realEstateNumber">The real estate number of the land.</param>
        /// <param name="culture">The culture of the land.</param>
        /// <param name="landClass">The class of the land.</param>
        /// <param name="processing">The processing of the land.</param>
        /// <param name="zone">The protected zone of the land.</param>
        /// <param name="property">The property type of the land.</param>
        /// <param name="drainage">The drainage of the land.</param>
        public LandPostRequestModel(decimal totalArea, LandlotMunicipality municipality, string realEstateNumber, LandlotCulture culture,
                                     LandlotClass landClass, LandlotProcessing processing, LandlotProtectedZone zone,
                                     LandlotPropertyType property, LandlotDrainage drainage)
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
