using Landlot.API.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Landlot.API.Models
{
    public class LotPatchRequestModel
    {
        [DataMember]
        public Guid? LandGuid { get; set; }

        [DataMember]
        public decimal? LotArea { get; set; }

        [DataMember]
        public Guid? LotUser { get; set; }

        [DataMember]
        public int? LotNumber { get; set; }

        [JsonConverter(typeof(LandlotCultureConverter))]
        [DataMember]
        public LandlotCulture? CultureState { get; set; }

        [JsonConverter(typeof(LandlotClassConverter))]
        [DataMember]
        public LandlotClass? ClassState { get; set; }

        [JsonConverter(typeof(LandlotProcessingConverter))]
        [DataMember]
        public LandlotProcessing? ProcessingState { get; set; }


        [JsonConverter(typeof(LandlotProtectedZoneConverter))]
        [DataMember]
        public LandlotProtectedZone? ProtectedZoneState { get; set; }

        [JsonConverter(typeof(LandlotDrainageConverter))]
        [DataMember]
        public LandlotDrainage? DrainageState { get; set; }


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
