using System.Runtime.Serialization;

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
        /// Initializes a new instance of the <see cref="AnnouncementPatchResponseModel"/> class.
        /// </summary>
        /// <param name="guid">The announcement GUID.</param>
        /// <param name="licitationGuid">The licitation GUID.</param>
        public AnnouncementPatchResponseModel(Guid guid, Guid licitationGuid)
        {
            Guid = guid;
            LicitationGuid = licitationGuid;
        }
    }
}
