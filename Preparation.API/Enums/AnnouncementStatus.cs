using System.Text.Json;
using System.Text.Json.Serialization;

namespace Preparation.API.Enums
{
    /// <summary>
    /// Represents the possible status values for a announcement.
    /// </summary>
    public enum AnnouncementStatus
    {
        /// <summary>
        /// The announcement has been approved.
        /// </summary>
        Approved,

        /// <summary>
        /// The announcement has been rejected.
        /// </summary>
        Rejected,

        /// <summary>
        /// The announcement is currently open.
        /// </summary>
        Opened
    }

    /// <summary>
    /// Converts between <see cref="AnnouncementStatus"/> enum and JSON string representation of the status.
    /// </summary>
    public class AnnouncementStatusConverter : JsonConverter<AnnouncementStatus>
    {
        // A mapping between AnnouncementStatus enum values and their JSON string representation.
        private readonly Dictionary<AnnouncementStatus, string> _announcementStatusMapping = new Dictionary<AnnouncementStatus, string>
    {
        { AnnouncementStatus.Approved, "Usvojen" },
        { AnnouncementStatus.Rejected, "Odbijen" },
        { AnnouncementStatus.Opened, "Otvoren" },
    };

        /// <inheritdoc />
        public override AnnouncementStatus Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            // Reads the JSON string representation of the status and converts it to AnnouncementStatus enum value.
            string statusString = reader.GetString() ?? "Otvoren";
            foreach (var announcementStatusMapping in _announcementStatusMapping)
            {
                if (announcementStatusMapping.Value == statusString)
                {
                    return announcementStatusMapping.Key;
                }
            }

            throw new JsonException($"Unable to map status string '{statusString}' to AnnouncementStatus.");
        }

        /// <inheritdoc />
        public override void Write(Utf8JsonWriter writer, AnnouncementStatus value, JsonSerializerOptions options)
        {
            // Writes the JSON string representation of the status for the given AnnouncementStatus enum value.
            writer.WriteStringValue(_announcementStatusMapping[value]);
        }
    }
}
