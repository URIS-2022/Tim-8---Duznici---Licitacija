using Landlot.API.Enums;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Landlot.API.Models
{
    /// <summary>
    /// Represents a model for a HTTP POST request to create a new lot.
    /// </summary>
    public class LotPostRequestModel
    {
        /// <summary>
        /// Gets or sets the GUID of the land associated with the lot.
        /// </summary>
        public Guid LandGuid { get; set; }

        /// <summary>
        /// Gets or sets the area of the lot.
        /// </summary>
        public decimal LotArea { get; set; }

        /// <summary>
        /// Gets or sets the GUID of the user associated with the lot.
        /// </summary>
        public Guid LotUser { get; set; }

        /// <summary>
        /// Gets or sets the number of the lot.
        /// </summary>
        public int LotNumber { get; set; }

        /// <summary>
        /// Gets or sets the culture state of the lot.
        /// </summary>
        [JsonConverter(typeof(LandlotCultureConverter))]
        public LandlotCulture CultureState { get; set; }

        /// <summary>
        /// Gets or sets the class state of the lot.
        /// </summary>
        [JsonConverter(typeof(LandlotClassConverter))]
        public LandlotClass ClassState { get; set; }

        /// <summary>
        /// Gets or sets the processing state of the lot.
        /// </summary>
        [JsonConverter(typeof(LandlotProcessingConverter))]
        public LandlotProcessing ProcessingState { get; set; }

        /// <summary>
        /// Gets or sets the protected zone state of the lot.
        /// </summary>
        [JsonConverter(typeof(LandlotProtectedZoneConverter))]
        public LandlotProtectedZone ProtectedZoneState { get; set; }

        /// <summary>
        /// Gets or sets the drainage state of the lot.
        /// </summary>
        [JsonConverter(typeof(LandlotDrainageConverter))]
        public LandlotDrainage DrainageState { get; set; }


        /// <summary>
        /// Creates a new instance of the LotPostRequestModel class with the specified properties.
        /// </summary>
        /// <param name="landGuid">The GUID of the land associated with the lot.</param>
        /// <param name="lotArea">The area of the lot in square meters.</param>
        /// <param name="lotUser">The GUID of the user who owns the lot.</param>
        /// <param name="lotNumber">The number of the lot within the land.</param>
        /// <param name="cultureState">The culture state of the lot.</param>
        /// <param name="classState">The class state of the lot.</param>
        /// <param name="processingState">The processing state of the lot.</param>
        /// <param name="protectedZoneState">The protected zone state of the lot.</param>
        /// <param name="drainageState">The drainage state of the lot.</param>

        public LotPostRequestModel(Guid landGuid, decimal lotArea, Guid lotUser, int lotNumber, LandlotCulture cultureState, LandlotClass classState, LandlotProcessing processingState, LandlotProtectedZone protectedZoneState, LandlotDrainage drainageState)
        {
            LandGuid = landGuid;
            LotArea = lotArea;
            LotUser = lotUser;
            LotNumber = lotNumber;
            CultureState = cultureState;
            ClassState = classState;
            ProcessingState = processingState;
            ProtectedZoneState = protectedZoneState;
            DrainageState = drainageState;
        }
    }
}
