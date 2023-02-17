using Preparation.API.Enums;
using System.Text.Json.Serialization;

namespace Preparation.API.Models
{
    /// <summary>
    /// Represents the request model for creating a new announcement.
    /// </summary>
    public class AnnouncementPostRequestModel
    {
        /// <summary>
        /// Gets or sets the GUID of the associated licitation.
        /// </summary>
        public Guid LicitationGuid { get; set; }

        /// <summary>
        /// Gets or sets the status of the announcement.
        /// </summary>
        [JsonConverter(typeof(AnnouncementStatusConverter))]
        public AnnouncementStatus AnnouncementStatus { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AnnouncementPostRequestModel"/> class with the specified licitation GUID.
        /// </summary>
        /// <param name="licitationGuid">The GUID of the associated licitation.</param>
        /// <param name="announcementStatus">The status of the announcement.</param>
        public AnnouncementPostRequestModel(Guid licitationGuid, AnnouncementStatus announcementStatus)
        {
            LicitationGuid = licitationGuid;
            AnnouncementStatus = announcementStatus;
        }
    }
}
