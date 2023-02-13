using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Landlot.API.Enums;


namespace Landlot.API.Models
{

    [DataContract(Name = "Lot", Namespace = "")]
    public class LotGetResponseModel
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
        public LandlotProtectedZone ProtectedZoneState{ get; set; }

        [JsonConverter(typeof(LandlotDrainageConverter))]
        [DataMember]
        public LandlotDrainage DrainageState { get; set; }

        public LotGetResponseModel() { }

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
