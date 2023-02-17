using Preparation.API.Enums;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Preparation.API.Models
{
    /// <summary>
    /// Represents an announcement patch response model.
    /// </summary>
    [DataContract(Name = "Announcement", Namespace = "")]
    public class AnnouncementPatchResponseModel
    {
        /// <summary>
        /// Gets or sets the announcement GUID.
        /// </summary>
        [DataMember]
        public Guid Guid { get; set; }

        /// <summary>
        /// Gets or sets the licitation GUID.
        /// </summary>
        [DataMember]
        public Guid LicitationGuid { get; set; }

        /// <summary>
        /// Gets or sets the status of the announcement.
        /// </summary>
        [JsonConverter(typeof(AnnouncementStatusConverter))]
        [DataMember(Name = "AnnouncementStatus")]
        public AnnouncementStatus AnnouncementStatus { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AnnouncementPatchResponseModel"/> class.
        /// </summary>
        /// <param name="guid">The announcement GUID.</param>
        /// <param name="licitationGuid">The licitation GUID.</param>
        /// /// <param name="announcementStatus">The status of the announcement.</param>
        public AnnouncementPatchResponseModel(Guid guid, Guid licitationGuid, AnnouncementStatus announcementStatus)
        {
            Guid = guid;
            LicitationGuid = licitationGuid;
            AnnouncementStatus = announcementStatus;
        }
    }
}
