using System.Runtime.Serialization;

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
        /// Initializes a new instance of the <see cref="AnnouncementPostResponseModel"/> class with the specified LicitationGuid.
        /// </summary>
        /// <param name="licitationGuid">The Guid of the associated Licitation.</param>
        public AnnouncementPostResponseModel(Guid licitationGuid)
        {
            LicitationGuid = licitationGuid;
        }
    }
}
