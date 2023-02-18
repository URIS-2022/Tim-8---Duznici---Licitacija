using Preparation.API.Enums;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Preparation.API.Models
{
    /// <summary>
    /// Model representing the response to a POST request for a new Announcement.
    /// </summary>
    [DataContract]
    public class AnnouncementPostResponseModel
    {
        /// <summary>
        /// Gets or sets the Guid of the associated Licitation.
        /// </summary>
        [DataMember]
        public Guid LicitationGuid { get; set; }

        /// <summary>
        /// The Announcement Status of the new announcement.
        /// </summary>
        [JsonConverter(typeof(AnnouncementStatusConverter))]
        [DataMember(Name = "AnnouncementStatus")]
        public AnnouncementStatus AnnouncementStatus { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AnnouncementPostResponseModel"/> class with the specified LicitationGuid.
        /// </summary>
        /// <param name="licitationGuid">The Guid of the associated Licitation.</param>
        /// /// <param name="announcementStatus">The Announcement Status of the new announcement.</param>
        public AnnouncementPostResponseModel(Guid licitationGuid, AnnouncementStatus announcementStatus)
        {
            LicitationGuid = licitationGuid;
            AnnouncementStatus = announcementStatus;
        }
    }
}
