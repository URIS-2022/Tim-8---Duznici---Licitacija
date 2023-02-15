using Microsoft.EntityFrameworkCore;
using Preparation.API.Entities;

namespace Preparation.API.Data.Repository
{
    /// <summary>
    /// Implementation of the ISystemUserRepository
    /// interface for managing SystemUser entities in the database.
    /// </summary>
    public class AnnouncementRepository : IAnnouncementRepository
    {
        private readonly PreparationDBContext context;

        /// <summary>
        /// Initializes a new instance of the SystemUserRepository class.
        /// </summary>
        /// <param name="context">The database context to use for data access.</param>
        public AnnouncementRepository(PreparationDBContext context)
        {
            this.context = context;
        }

        /// <inheritdoc cref="IAnnouncementRepository.GetAll"/>
        public async Task<Announcement> Add(Announcement Announcement)
        {
            context.Announcements.Add(Announcement);
            await context.SaveChangesAsync();
            return Announcement;
        }

        /// <inheritdoc cref="IAnnouncementRepository.Delete(Guid)"/>
        public async Task Delete(Guid Guid)
        {
            var Announcement = await context.Announcements.FindAsync(Guid);
            if (Announcement == null)
            {
                throw new InvalidOperationException("Announcement not found");
            }
            context.Announcements.Remove(Announcement);
            await context.SaveChangesAsync();
        }

        /*
        /// <inheritdoc cref="IAnnouncementRepository.Delete(string)"/>
        public async Task Delete(string ReferenceNumber)
        {
            var Document = await context.Documents.FirstOrDefaultAsync(x => x.ReferenceNumber == ReferenceNumber);
            if (Document == null)
            {
                throw new InvalidOperationException("Document not found");
            }
            context.Documents.Remove(Document);
            await context.SaveChangesAsync();
        }
        */

        /// <inheritdoc cref="IAnnouncementRepository.GetAll"/>
        public async Task<IEnumerable<Announcement>> GetAll()
        {
            return await context.Announcements.ToListAsync();
        }

        /*
        /// <inheritdoc cref="ISystemUserRepository.GetByCredentials(string, string)"/>
        public async Task<SystemUser?> GetByCredentials(string username, string password)
        {
            var systemUser = await context.SystemUsers.SingleOrDefaultAsync(x => x.Username == username && x.Password == password);

            return systemUser;
        }
        */

        /// <inheritdoc cref="IAnnouncementRepository.GetByGuid(Guid)"/>
        public async Task<Announcement?> GetByGuid(Guid Guid)
        {
            var Announcement = await context.Announcements.SingleOrDefaultAsync(x => x.Guid == Guid);

            return Announcement;
        }

        /// <inheritdoc cref="IAnnouncementRepository.GetByLicitation(Guid)"/>
        public async Task<Announcement?> GetByLicitation(Guid LicitationGuid)
        {
            Announcement? Announcement = await context.Announcements.SingleOrDefaultAsync(x => x.LicitationGuid == LicitationGuid);

            return Announcement;
        }

        /// <inheritdoc cref="IAnnouncementRepository.Update(Announcement)"/>
        public async Task<Announcement?> Update(Announcement Announcement)
        {
            var existingAnnouncement = await context.Announcements.FindAsync(Announcement.Guid);
            if (existingAnnouncement == null)
            {
                throw new InvalidOperationException($"The Announcement with ID '{Announcement.Guid}' was not found.");
            }

            context.Entry(existingAnnouncement).CurrentValues.SetValues(Announcement);
            await context.SaveChangesAsync();

            return existingAnnouncement;
        }

    }
}
