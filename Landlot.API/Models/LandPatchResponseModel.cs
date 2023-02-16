using Landlot.API.Enums;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Landlot.API.Models
{

    /// <summary>
    /// Represents a response model for patching land details
    /// </summary>
    [DataContract(Name = "Land", Namespace = "")]
    public class LandPatchResponseModel
    {
        /// <summary>
        /// Gets or sets the GUID of the land.
        /// </summary>
        [DataMember]
        public Guid LandGuid { get; set; }

        /// <summary>
        /// Gets or sets the total area of the land.
        /// </summary>
        [DataMember]
        public decimal TotalArea { get; set; }

        /// <summary>
        /// Gets or sets the municipality of the land.
        /// </summary>
        [JsonConverter(typeof(LandlotMunicipalityConverter))]
        [DataMember]
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
        [DataMember]
        public LandlotCulture Culture { get; set; }

        /// <summary>
        /// Gets or sets the class of the land.
        /// </summary>
        [JsonConverter(typeof(LandlotClassConverter))]
        [DataMember]
        public LandlotClass LandClass { get; set; }

        /// <summary>
        /// Gets or sets the processing of the land.
        /// </summary>
        [JsonConverter(typeof(LandlotProcessingConverter))]
        [DataMember]
        public LandlotProcessing Processing { get; set; }

        /// <summary>
        /// Gets or sets the protected zone of the land.
        /// </summary>
        [JsonConverter(typeof(LandlotProtectedZoneConverter))]
        [DataMember]
        public LandlotProtectedZone Zone { get; set; }

        /// <summary>
        /// Gets or sets the property type of the land.
        /// </summary>
        [JsonConverter(typeof(LandlotPropertyTypeConverter))]
        [DataMember]
        public LandlotPropertyType Property { get; set; }

        /// <summary>
        /// Gets or sets the drainage of the land.
        /// </summary>
        [JsonConverter(typeof(LandlotDrainageConverter))]
        [DataMember]
        public LandlotDrainage Drainage { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LandPatchResponseModel"/> class.
        /// </summary>
        /// <param name="landGuid">The GUID of the land.</param>
        /// <param name="totalArea">The total area of the land.</param>
        /// <param name="municipality">The municipality of the land.</param>
        /// <param name="realEstateNumber">The real estate number of the land.</param>
        /// <param name="culture">The culture of the land.</param>
        /// <param name="landClass">The class of the land.</param>
        /// <param name="processing">The processing of the land.</param>
        /// <param name="zone">The protected zone of the land.</param>
        /// <param name="property">The property type of the land.</param>
        /// <param name="drainage">The drainage of the land.</param>
        public LandPatchResponseModel(Guid landGuid, decimal totalArea, LandlotMunicipality municipality, string realEstateNumber, LandlotCulture culture,
                                       LandlotClass landClass, LandlotProcessing processing, LandlotProtectedZone zone,
                                      LandlotPropertyType property, LandlotDrainage drainage)
        {
            LandGuid = landGuid;
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
