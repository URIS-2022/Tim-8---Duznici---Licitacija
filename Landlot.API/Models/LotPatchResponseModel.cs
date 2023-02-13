using Landlot.API.Enums;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Landlot.API.Models
{

    [DataContract(Name = "Lot", Namespace = "")]
    public class LotPatchResponseModel
    {
        [DataMember]
        public Guid LotGuid { get; set; }

        [DataMember]
        public Guid LandGuid { get; set; }

        [DataMember]
        public decimal LotArea { get; set; }

        [DataMember]
        public Guid LotUser { get; set; }

        [DataMember]
        public int LotNumber { get; set; }

        [JsonConverter(typeof(LandlotCultureConverter))]
        [DataMember]
        public LandlotCulture CultureState { get; set; }

        [JsonConverter(typeof(LandlotClassConverter))]
        [DataMember]
        public LandlotClass ClassState { get; set; }

        [JsonConverter(typeof(LandlotProcessingConverter))]
        [DataMember]
        public LandlotProcessing ProcessingState { get; set; }


        [JsonConverter(typeof(LandlotProtectedZoneConverter))]
        [DataMember]
        public LandlotProtectedZone ProtectedZoneSate { get; set; }

        [JsonConverter(typeof(LandlotDrainageConverter))]
        [DataMember]
        public LandlotDrainage DrainageState { get; set; }

        public LotPatchResponseModel(Guid lotGuid, Guid landGuid, decimal lotArea, Guid lotUser, int lotNumber, LandlotCulture cultureState, LandlotClass classState, LandlotProcessing processingState, LandlotProtectedZone protectedZoneSate, LandlotDrainage drainageState)
        {
            LotGuid = lotGuid;
            LandGuid = landGuid;
            LotArea = lotArea;
            LotUser = lotUser;
            LotNumber = lotNumber;
            CultureState = cultureState;
            ClassState = classState;
            ProcessingState = processingState;
            ProtectedZoneSate = protectedZoneSate;
            DrainageState = drainageState;
        }
    }
}
