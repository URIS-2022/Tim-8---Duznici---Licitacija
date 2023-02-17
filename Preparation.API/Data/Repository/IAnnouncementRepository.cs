using Preparation.API.Entities;

namespace Preparation.API.Data.Repository
{
    /// <summary>
    /// The interface for announcement repository, provides methods for getting, updating, adding and deleting a announcement
    /// </summary>
    public interface IAnnouncementRepository
    {
        /// <summary>
        /// Gets a list of all announcements.
        /// </summary>
        /// <returns>A list of announcements.</returns>
        Task<IEnumerable<Entities.Announcement>> GetAnnouncements();

        /// <summary>
        /// Gets a specific announcement by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the announcement.</param>
        /// <returns>The announcement with the specified identifier.</returns>
        Task<Entities.Announcement?> GetAnnouncement(Guid id);

        /// <summary>
        /// Updates a specific announcement.
        /// </summary>
        /// <param name="id">The identifier of the announcement to update.</param>
        /// <param name="patchAnnouncement">The updated values for the announcement.</param>
        /// <returns>The updated announcement.</returns>
        Task<Entities.Announcement?> UpdateAnnouncement(Guid id, Entities.Announcement patchAnnouncement);

        /// <summary>
        /// Adds a new announcement.
        /// </summary>
        /// <param name="announcement">The announcement to add.</param>
        /// <returns>The added announcement.</returns>
        Task<Entities.Announcement?> AddAnnouncement(Entities.Announcement announcement);

        /// <summary>
        /// Deletes a specific announcement.
        /// </summary>
        /// <param name="id">The identifier of the announcement to delete.</param>
        /// <returns>The deleted announcement.</returns>
        Task DeleteAnnouncement(Guid id);

    }
}
