using Preparation.API.Entities;
using Preparation.API.Enums;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Preparation.API.Models
{
    /// <summary>
    /// Represents the response model for retrieving announcement data.
    /// </summary>
    [DataContract(Name = "Announcement", Namespace = "")]
    public class AnnouncementGetResponseModel
    {
        /// <summary>
        /// Gets or sets the unique identifier of the announcement.
        /// </summary>
        [DataMember]
        public Guid Guid { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the licitation associated with the announcement.
        /// </summary>
        [DataMember]
        public Guid LicitationGuid { get; set; }

        /// <summary>
        /// Initializes a new instance of the AnnouncementGetResponseModel class with the specified values.
        /// </summary>
        /// <param name="guid">The unique identifier of the announcement.</param>
        /// <param name="licitationGuid">The unique identifier of the licitation associated with the announcement.</param>
        public AnnouncementGetResponseModel(Guid guid, Guid licitationGuid)
        {
            Guid = guid;
            LicitationGuid = licitationGuid;
        }
    }
}
