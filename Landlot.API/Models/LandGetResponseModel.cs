using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Landlot.API.Enums;

namespace Landlot.API.Models
{
    /// <summary>
    /// Represents a response model for a land record.
    /// </summary>
    [DataContract(Name = "Land", Namespace = "")]
    
    public class LandGetResponseModel
    {
        /// <summary>
        /// Gets or sets the unique identifier for the land.
        /// </summary>
        [DataMember]
        public Guid LandGuid { get; set; }

        /// <summary>
        /// Gets or sets the total area of the land.
        /// </summary>
        [DataMember]
        public decimal TotalArea { get; set; }

        /// <summary>
        /// Gets or sets the municipality where the land is located.
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
        /// Gets or sets the primary crop culture of the land.
        /// </summary>
        [JsonConverter(typeof(LandlotCultureConverter))]
        [DataMember]
        public LandlotCulture Culture { get; set; }

        /// <summary>
        /// Gets or sets the land class.
        /// </summary>
        [JsonConverter(typeof(LandlotClassConverter))]
        [DataMember]
        public LandlotClass LandClass { get; set; }

        /// <summary>
        /// Gets or sets the land processing type.
        /// </summary>
        [JsonConverter(typeof(LandlotProcessingConverter))]
        [DataMember]
        public LandlotProcessing Processing { get; set; }

        /// <summary>
        /// Gets or sets the protected zone classification of the land.
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
        /// Gets or sets the land drainage type.
        /// </summary>
        [JsonConverter(typeof(LandlotDrainageConverter))]
        [DataMember]
        public LandlotDrainage Drainage { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LandGetResponseModel"/> class.
        /// </summary>
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public LandGetResponseModel() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.


        /// <summary>
        /// Represents a response model for a land record.
        /// </summary>
        public LandGetResponseModel(Guid guid, decimal area, LandlotMunicipality municipality, string estateNumber, LandlotCulture culture,
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




    
       
