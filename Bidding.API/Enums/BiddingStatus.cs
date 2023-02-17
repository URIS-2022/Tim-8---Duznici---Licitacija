using System.Text.Json;
using System.Text.Json.Serialization;



namespace Bidding.API.Enums
{

    public enum BiddingStatus
    {
        None = 0,
        FirstRound,
        SecondRoundOldConditions,
        SecondRoundNewConditions
        
    }
    public class BiddingStatusConverter : JsonConverter<BiddingStatus>
    {
        private readonly Dictionary<BiddingStatus, string> _biddingStatusMapping = new Dictionary<BiddingStatus, string>
        {
         { BiddingStatus.None, "Nije dodeljeno" },
         { BiddingStatus.FirstRound, "Prvi krug" },
         { BiddingStatus.SecondRoundOldConditions, "Drugi krug sa starim uslovima" },
         { BiddingStatus.SecondRoundNewConditions, "Drugi krug sa novim uslovima" },
        
        };

        public override BiddingStatus Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string biddingStatusString = reader.GetString() ?? "Nije dodeljeno";
            foreach (var biddingStatusMapping in _biddingStatusMapping)
            {
                if (biddingStatusMapping.Value == biddingStatusString)
                {
                    return biddingStatusMapping.Key;
                }
            }

            throw new JsonException($"Unable to map bidding status string '{biddingStatusString}' to BiddingStatus.");
        }

        public override void Write(Utf8JsonWriter writer, BiddingStatus value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(_biddingStatusMapping[value]);
        }
    }
}
