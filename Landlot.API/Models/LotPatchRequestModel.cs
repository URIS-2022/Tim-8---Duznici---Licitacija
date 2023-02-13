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
        public Guid? LandGuid { get; set; }

        public decimal? LotArea { get; set; }

        public Guid? LotUser { get; set; }

        public int? LotNumber { get; set; }

        [JsonConverter(typeof(LandlotCultureConverter))]
        public LandlotCulture? CultureState { get; set; }

        [JsonConverter(typeof(LandlotClassConverter))]
        public LandlotClass? ClassState { get; set; }

        [JsonConverter(typeof(LandlotProcessingConverter))]
        public LandlotProcessing? ProcessingState { get; set; }

        [JsonConverter(typeof(LandlotProtectedZoneConverter))]
        public LandlotProtectedZone? ProtectedZoneState { get; set; }

        [JsonConverter(typeof(LandlotDrainageConverter))]
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
