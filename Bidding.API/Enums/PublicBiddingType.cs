using System.Text.Json;
using System.Text.Json.Serialization;

namespace Bidding.API.Enums
{
    public enum PublicBiddingType
    {
        None = 0,
        PublicLicitation,
        OpeningOfSealedBids


    }
    public class PublicBiddingTypeConverter : JsonConverter<PublicBiddingType>
    {
        private readonly Dictionary<PublicBiddingType, string> _biddingTypeMapping = new Dictionary<PublicBiddingType, string>
        {
         { PublicBiddingType.None, "Nije dodeljeno" },
         { PublicBiddingType.PublicLicitation, "Javna licitacija" },
         { PublicBiddingType.OpeningOfSealedBids, "Otvaranje zatvorenih ponuda" },


        };

        public override PublicBiddingType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string biddingTypeString = reader.GetString() ?? "Nije dodeljeno";
            foreach (var biddingTypeMapping in _biddingTypeMapping)
            {
                if (biddingTypeMapping.Value == biddingTypeString)
                {
                    return biddingTypeMapping.Key;
                }
            }

            throw new JsonException($"Unable to map bidding type string '{biddingTypeString}' to PublicBiddingType.");
        }

        public override void Write(Utf8JsonWriter writer, PublicBiddingType value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(_biddingTypeMapping[value]);
        }
    }
}
