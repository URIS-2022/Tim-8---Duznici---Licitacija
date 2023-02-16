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
        /// Initializes a new instance of the <see cref="AnnouncementPostRequestModel"/> class with the specified licitation GUID.
        /// </summary>
        /// <param name="licitationGuid">The GUID of the associated licitation.</param>
        public AnnouncementPostRequestModel(Guid licitationGuid)
        {
            LicitationGuid = licitationGuid;
        }
    }
}
