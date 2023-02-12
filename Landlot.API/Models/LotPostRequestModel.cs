using Landlot.API.Enums;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Landlot.API.Models
{
    public class LotPostRequestModel
    {
        public Guid LandGuid { get; set; }

        public int LotArea { get; set; }

        public int LotUser { get; set; }

        public int LotNumber { get; set; }

        [JsonConverter(typeof(LandlotCultureConverter))]
        public LandlotCulture CultureState { get; set; }

        [JsonConverter(typeof(LandlotProcessingConverter))]
        public LandlotProcessing ProcessingSate { get; set; }

        [JsonConverter(typeof(LandlotProtectedZoneConverter))]
        public LandlotProtectedZone ProtectedZoneSate { get; set; }

        [JsonConverter(typeof(LandlotDrainageConverter))]
        public LandlotDrainage DrainageState { get; set; }

        public LotPostRequestModel(Guid landGuid, int lotArea, int lotUser, int lotNumber, LandlotCulture cultureState, LandlotProcessing processingSate, LandlotProtectedZone protectedZoneSate, LandlotDrainage drainageState)
        {
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
