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
        public int LotArea { get; set; }
      
        [DataMember]
        public int LotUser { get; set; }

        [DataMember]
        public int LotNumber { get; set; }

        [JsonConverter(typeof(LandlotCultureConverter))]
        [DataMember]
        public LandlotCulture CultureState { get; set; }


        [JsonConverter(typeof(LandlotProcessingConverter))]
        [DataMember]
        public LandlotProcessing ProcessingSate { get; set; }


        [JsonConverter(typeof(LandlotProtectedZoneConverter))]
        [DataMember]
        public LandlotProtectedZone ProtectedZoneSate{ get; set; }

        [JsonConverter(typeof(LandlotDrainageConverter))]
        [DataMember]
        public LandlotDrainage DrainageState { get; set; }

        public LotGetResponseModel() { }

        public LotGetResponseModel(Guid lotGuid, Guid landGuid, int lotArea, int lotUser, int lotNumber, LandlotCulture cultureState, LandlotProcessing processingSate, LandlotProtectedZone protectedZoneSate, LandlotDrainage drainageState)
        {
            LotGuid = lotGuid;
            LandGuid = landGuid;
            LotArea = lotArea;
            LotUser = lotUser;
            LotNumber = lotNumber;
            CultureState = cultureState;
            ProcessingSate = processingSate;
            ProtectedZoneSate = protectedZoneSate;
            DrainageState = drainageState;
        }
    }
}
