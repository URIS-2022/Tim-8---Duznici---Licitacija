using System.Text.Json;
using System.Text.Json.Serialization;



namespace Bidding.API.Enums
{
    /// <summary>
    /// Enumeration of possible bidding statuses.
    /// </summary>
    public enum BiddingStatus
    {
        /// <summary>
        /// Default value for undefined bidding status.
        /// </summary>
        None = 0,
        /// <summary>
        /// First round bidding status.
        /// </summary>
        FirstRound,
        /// <summary>
        /// Second round bidding status with old conditions.
        /// </summary>
        SecondRoundOldConditions,
        /// <summary>
        /// Second round bidding status with new conditions.
        /// </summary>
        SecondRoundNewConditions

    }

    /// <summary>
    /// Json converter for the BiddingStatus enumeration.
    /// </summary>
    public class BiddingStatusConverter : JsonConverter<BiddingStatus>
    {
        private readonly Dictionary<BiddingStatus, string> _biddingStatusMapping = new Dictionary<BiddingStatus, string>
        {
         { BiddingStatus.None, "Nije dodeljeno" },
         { BiddingStatus.FirstRound, "Prvi krug" },
         { BiddingStatus.SecondRoundOldConditions, "Drugi krug sa starim uslovima" },
         { BiddingStatus.SecondRoundNewConditions, "Drugi krug sa novim uslovima" },
        
        };

        /// <summary>
        /// Reads and maps a string value to a BiddingStatus enumeration value.
        /// </summary>

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

        /// <summary>
        /// Writes a BiddingStatus enumeration value as a string value using the mapped string value.
        /// </summary>
        public override void Write(Utf8JsonWriter writer, BiddingStatus value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(_biddingStatusMapping[value]);
        }
    }
}
