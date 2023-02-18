using Landlot.API.Enums;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Landlot.API.Models
{
    /// <summary>
    /// Represents a response model for a land post request.
    /// </summary>
    [DataContract(Name = "Land", Namespace = "")]
    public class LandPostResponseModel
    {
        /// <summary>
        /// Gets or sets the total area of the land.
        /// </summary>
        [DataMember]
        public decimal TotalArea { get; set; }

        /// <summary>
        /// Gets or sets the municipality of the land.
        /// </summary>
        [JsonConverter(typeof(LandlotMunicipalityConverter))]
        [DataMember(Name = "Municipality")]
        public LandlotMunicipality Municipality { get; set; }

        /// <summary>
        /// Gets or sets the real estate number of the land.
        /// </summary>
        [DataMember]
        public string RealEstateNumber { get; set; }

        /// <summary>
        /// Gets or sets the culture of the land.
        /// </summary>
        [JsonConverter(typeof(LandlotCultureConverter))]
        [DataMember(Name = "Culture")]
        public LandlotCulture Culture { get; set; }

        /// <summary>
        /// Gets or sets the land class of the land.
        /// </summary>
        [JsonConverter(typeof(LandlotClassConverter))]
        [DataMember(Name = "LandClass")]
        public LandlotClass LandClass { get; set; }

        /// <summary>
        /// Gets or sets the processing information of the land.
        /// </summary>
        [JsonConverter(typeof(LandlotProcessingConverter))]
        [DataMember(Name = "Processing")]
        public LandlotProcessing Processing { get; set; }

        /// <summary>
        /// Gets or sets the protected zone of the land.
        /// </summary>
        [JsonConverter(typeof(LandlotProtectedZoneConverter))]
        [DataMember(Name = "Zone")]
        public LandlotProtectedZone Zone { get; set; }

        /// <summary>
        /// Gets or sets the property type of the land.
        /// </summary>
        [JsonConverter(typeof(LandlotPropertyTypeConverter))]
        [DataMember(Name = "Property")]
        public LandlotPropertyType Property { get; set; }

        /// <summary>
        /// Gets or sets the drainage information of the land.
        /// </summary>
        [JsonConverter(typeof(LandlotDrainageConverter))]
        [DataMember(Name = "Drainage")]
        public LandlotDrainage Drainage { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LandPostResponseModel"/> class.
        /// </summary>
        /// <param name="totalArea">The total area of the land.</param>
        /// <param name="municipality">The municipality of the land.</param>
        /// <param name="realEstateNumber">The real estate number of the land.</param>
        /// <param name="culture">The culture of the land.</param>
        /// <param name="landClass">The land class of the land.</param>
        /// <param name="processing">The processing information of the land.</param>
        /// <param name="zone">The protected zone of the land.</param>
        /// <param name="property">The property type of the land.</param>
        /// <param name="drainage">The drainage information of the land.</param>

        public LandPostResponseModel(decimal totalArea, LandlotMunicipality municipality, string realEstateNumber, LandlotCulture culture, LandlotClass landClass, LandlotProcessing processing, LandlotProtectedZone zone, LandlotPropertyType property, LandlotDrainage drainage)
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
