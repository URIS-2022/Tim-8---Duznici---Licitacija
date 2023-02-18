using Preparation.API.Enums;
using System.Text.Json.Serialization;

namespace Preparation.API.Models
{
    /// <summary>
    /// Model for the request to patch an announcement.
    /// </summary>
    public class AnnouncementPatchRequestModel
    {
        /// <summary>
        /// Gets or sets the optional Licitation Guid to update in the announcement.
        /// </summary>
        public Guid? LicitationGuid { get; set; }

        /// <summary>
        /// Gets or sets the announcement status.
        /// </summary>
        [JsonConverter(typeof(AnnouncementStatusConverter))]
        public AnnouncementStatus? AnnouncementStatus { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AnnouncementPatchRequestModel"/> class with the specified Licitation Guid.
        /// </summary>
        /// <param name="licitationGuid">The optional Licitation Guid to update in the announcement.</param>
        /// <param name="announcementStatus">The announcement status.</param>
        public AnnouncementPatchRequestModel(Guid? licitationGuid, AnnouncementStatus? announcementStatus)
        {
            LicitationGuid = licitationGuid;
            AnnouncementStatus = announcementStatus;
        }
    }
}
