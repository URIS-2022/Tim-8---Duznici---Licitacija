using Landlot.API.Enums;
using System.Text.Json.Serialization;

namespace Landlot.API.Models
{
    /// <summary>
    /// Model used for patching a lot's properties.
    /// </summary>
    public class LotPatchRequestModel
    {
        /// <summary>
        /// The GUID of the land that the lot is on.
        /// </summary>
        public Guid? LandGuid { get; set; }

        /// <summary>
        /// The area of the lot.
        /// </summary>
        public decimal? LotArea { get; set; }

        /// <summary>
        /// The GUID of the user who owns the lot.
        /// </summary>
        public Guid? LotUser { get; set; }

        /// <summary>
        /// The lot number.
        /// </summary>
        public int? LotNumber { get; set; }

        /// <summary>
        /// The culture state of the lot.
        /// </summary>
        [JsonConverter(typeof(LandlotCultureConverter))]
        public LandlotCulture? CultureState { get; set; }

        /// <summary>
        /// The class state of the lot.
        /// </summary>
        [JsonConverter(typeof(LandlotClassConverter))]
        public LandlotClass? ClassState { get; set; }

        /// <summary>
        /// The processing state of the lot.
        /// </summary>
        [JsonConverter(typeof(LandlotProcessingConverter))]
        public LandlotProcessing? ProcessingState { get; set; }

        /// <summary>
        /// The protected zone state of the lot.
        /// </summary>
        [JsonConverter(typeof(LandlotProtectedZoneConverter))]
        public LandlotProtectedZone? ProtectedZoneState { get; set; }

        /// <summary>
        /// The drainage state of the lot.
        /// </summary>
        [JsonConverter(typeof(LandlotDrainageConverter))]
        public LandlotDrainage? DrainageState { get; set; }



        /// <summary>
        /// Initializes a new instance of the LotPatchRequestModel class with the specified properties.
        /// </summary>
        /// <param name="landGuid">The new Land Guid to assign to the Lot.</param>
        /// <param name="lotArea">The new area of the Lot.</param>
        /// <param name="lotUser">The new user associated with the Lot.</param>
        /// <param name="lotNumber">The new number of the Lot.</param>
        /// <param name="cultureState">The new culture state of the Lot.</param>
        /// <param name="classState">The new class state of the Lot.</param>
        /// <param name="processingState">The new processing state of the Lot.</param>
        /// <param name="protectedZoneState">The new protected zone state of the Lot.</param>
        /// <param name="drainageState">The new drainage state of the Lot.</param>
        public LotPatchRequestModel(Guid? landGuid, decimal? lotArea, Guid? lotUser, int? lotNumber, LandlotCulture? cultureState, LandlotClass? classState, LandlotProcessing? processingState, LandlotProtectedZone? protectedZoneState, LandlotDrainage? drainageState)
        {
            LandGuid = landGuid;
            LotArea = lotArea;
            LotUser = lotUser;
            LotNumber = lotNumber;
            CultureState = cultureState;
            ProcessingState = processingState;
            ClassState = classState;
            ProtectedZoneState = protectedZoneState;
            DrainageState = drainageState;
        }
    }
}
