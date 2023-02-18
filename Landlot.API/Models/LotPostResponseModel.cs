﻿using Landlot.API.Enums;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Landlot.API.Models
{
    /// <summary>
    /// Represents the response model for a new lot posted to the system.
    /// </summary>
    [DataContract(Name = "Lot", Namespace = "")]
    public class LotPostResponseModel
    {
        /// <summary>
        /// Gets or sets the GUID of the land associated with the lot.
        /// </summary>
        [DataMember]
        public Guid LandGuid { get; set; }

        /// <summary>
        /// Gets or sets the area of the lot.
        /// </summary>
        [DataMember]
        public decimal LotArea { get; set; }

        /// <summary>
        /// Gets or sets the GUID of the user who owns the lot.
        /// </summary>
        [DataMember]
        public Guid LotUser { get; set; }

        /// <summary>
        /// Gets or sets the number of the lot.
        /// </summary>
        [DataMember]
        public int LotNumber { get; set; }

        /// <summary>
        /// Gets or sets the culture state of the lot.
        /// </summary>
        [JsonConverter(typeof(LandlotCultureConverter))]
        [DataMember(Name = "CultureState")]
        public LandlotCulture CultureState { get; set; }

        /// <summary>
        /// Gets or sets the class state of the lot.
        /// </summary>
        [JsonConverter(typeof(LandlotClassConverter))]
        [DataMember(Name = "ClassState")]
        public LandlotClass ClassState { get; set; }

        /// <summary>
        /// Gets or sets the processing state of the lot.
        /// </summary>
        [JsonConverter(typeof(LandlotProcessingConverter))]
        [DataMember(Name = "ProcessingState")]
        public LandlotProcessing ProcessingState { get; set; }

        /// <summary>
        /// Gets or sets the protected zone state of the lot.
        /// </summary>
        [JsonConverter(typeof(LandlotProtectedZoneConverter))]
        [DataMember(Name = "ProtectedZoneState")]
        public LandlotProtectedZone ProtectedZoneState { get; set; }

        /// <summary>
        /// Gets or sets the drainage state of the lot.
        /// </summary>
        [JsonConverter(typeof(LandlotDrainageConverter))]
        [DataMember(Name = "DrainageState")]
        public LandlotDrainage DrainageState { get; set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="LotPostResponseModel"/> class with the specified values.
        /// </summary>
        /// <param name="landGuid">The unique identifier of the land.</param>
        /// <param name="lotArea">The area of the lot.</param>
        /// <param name="lotUser">The unique identifier of the user who owns the lot.</param>
        /// <param name="lotNumber">The number of the lot.</param>
        /// <param name="cultureState">The culture state of the lot.</param>
        /// <param name="classState">The class state of the lot.</param>
        /// <param name="processingState">The processing state of the lot.</param>
        /// <param name="protectedZoneState">The protected zone state of the lot.</param>
        /// <param name="drainageState">The drainage state of the lot.</param>
        public LotPostResponseModel(Guid landGuid, decimal lotArea, Guid lotUser, int lotNumber, LandlotCulture cultureState, LandlotClass classState, LandlotProcessing processingState, LandlotProtectedZone protectedZoneState, LandlotDrainage drainageState)
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
