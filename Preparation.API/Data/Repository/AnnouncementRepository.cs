using Microsoft.EntityFrameworkCore;

namespace Preparation.API.Data.Repository
{
    /// <summary>
    /// Implementation of the IAnnouncementRepository
    /// interface for managing Announcement entities in the database.
    /// </summary>
    public class AnnouncementRepository : IAnnouncementRepository
    {
        private readonly PreparationDbContext context;

        /// <summary>
        /// Initializes a new instance of the AnnouncementRepository class.
        /// </summary>
        /// <param name="context">The database context to use for data access.</param>
        public AnnouncementRepository(PreparationDbContext context)
        {
            this.context = context;
        }

        /// <inheritdoc cref="IAnnouncementRepository.GetAnnouncements"/>
        public async Task<IEnumerable<Entities.Announcement>> GetAnnouncements()
        {
            return await context.Announcements.ToListAsync();
        }

        /// <inheritdoc cref="IAnnouncementRepository.GetAnnouncement"/>
        public async Task<Entities.Announcement?> GetAnnouncement(Guid id)
        {
            return await context.Announcements.FindAsync(id);
        }

        /// <inheritdoc cref="IAnnouncementRepository.UpdateAnnouncement"/>
        public async Task<Entities.Announcement?> UpdateAnnouncement(Guid id, Entities.Announcement patchAnnouncement)
        {
            var announcement = await context.Announcements.FirstOrDefaultAsync(c => c.Guid == id);
            if (announcement == null)
            {
                return null;
            }
            context.Entry(announcement).CurrentValues.SetValues(patchAnnouncement);
            await context.SaveChangesAsync();
            return announcement;
        }

        /// <inheritdoc cref="IAnnouncementRepository.AddAnnouncement"/>
        public async Task<Entities.Announcement?> AddAnnouncement(Entities.Announcement announcement)
        {
            var created = context.Announcements.Add(announcement);
            await context.SaveChangesAsync();
            return created.Entity;
        }

        /// <inheritdoc cref="IAnnouncementRepository.DeleteAnnouncement"/>
        public async Task DeleteAnnouncement(Guid id)
        {
            var systemUser = await context.Announcements.FindAsync(id);
            if (systemUser == null)
            {
                throw new InvalidOperationException("Announcement not found");
            }
            context.Announcements.Remove(systemUser);
            await context.SaveChangesAsync();
        }
    }
}
