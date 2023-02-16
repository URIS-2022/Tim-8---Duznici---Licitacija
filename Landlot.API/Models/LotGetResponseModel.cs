using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Landlot.API.Enums;


namespace Landlot.API.Models
{

        // <summary>
        /// Represents a response model for a lot.
        /// </summary>
        [DataContract(Name = "Lot", Namespace = "")]
      public class LotGetResponseModel
        {
        /// <summary>
        /// The unique identifier of the lot.
        /// </summary>
        [DataMember]
        public Guid LotGuid { get; set; }

        /// <summary>
        /// The unique identifier of the land that the lot belongs to.
        /// </summary>
        [DataMember]
        public Guid LandGuid { get; set; }

        /// <summary>
        /// The area of the lot.
        /// </summary>
        [DataMember]
        public decimal LotArea { get; set; }

        /// <summary>
        /// The unique identifier of the user who owns the lot.
        /// </summary>
        [DataMember]
        public Guid LotUser { get; set; }

        /// <summary>
        /// The number of the lot.
        /// </summary>
        [DataMember]
        public int LotNumber { get; set; }

        /// <summary>
        /// The culture state of the lot.
        /// </summary>
        [JsonConverter(typeof(LandlotCultureConverter))]
        [DataMember]
        public LandlotCulture CultureState { get; set; }

        /// <summary>
        /// The class state of the lot.
        /// </summary>
        [JsonConverter(typeof(LandlotClassConverter))]
        [DataMember]
        public LandlotClass ClassState { get; set; }

        /// <summary>
        /// The processing state of the lot.
        /// </summary>
        [JsonConverter(typeof(LandlotProcessingConverter))]
        [DataMember]
        public LandlotProcessing ProcessingState { get; set; }

        /// <summary>
        /// The protected zone state of the lot.
        /// </summary>
        [JsonConverter(typeof(LandlotProtectedZoneConverter))]
        [DataMember]
        public LandlotProtectedZone ProtectedZoneState { get; set; }

        /// <summary>
        /// The drainage state of the lot.
        /// </summary>
        [JsonConverter(typeof(LandlotDrainageConverter))]
        [DataMember]
        public LandlotDrainage DrainageState { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LotGetResponseModel"/> class.
        /// </summary>
        public LotGetResponseModel() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="LotGetResponseModel"/> class with the specified values.
        /// </summary>
        /// <param name="lotGuid">The unique identifier of the lot.</param>
        /// <param name="landGuid">The unique identifier of the land that the lot belongs to.</param>
        /// <param name="lotArea">The area of the lot.</param>
        /// <param name="lotUser">The unique identifier of the user who owns the lot.</param>
        /// <param name="lotNumber">The number of the lot.</param>
        /// <param name="cultureState">The culture state of the lot.</param>
        /// <param name="classState">The class state of the lot.</param>
        /// <param name="processingState">The processing state of the lot.</param>
        /// <param name="protectedZoneState">The protected zone state of the lot.</param>
        /// <param name="drainageState">The drainage state of the lot.</param>
        public LotGetResponseModel(Guid lotGuid, Guid landGuid, decimal lotArea, Guid lotUser, int lotNumber, LandlotCulture cultureState, LandlotClass classState, LandlotProcessing processingState, LandlotProtectedZone protectedZoneState, LandlotDrainage drainageState)


        {
            LotGuid = lotGuid;
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
