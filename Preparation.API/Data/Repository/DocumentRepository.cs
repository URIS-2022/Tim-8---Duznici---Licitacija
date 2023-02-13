using Microsoft.EntityFrameworkCore;
using Preparation.API.Entities;

namespace Preparation.API.Data.Repository
{
    /// <summary>
    /// Implementation of the ISystemUserRepository
    /// interface for managing SystemUser entities in the database.
    /// </summary>
    public class DocumentRepository : IDocumentRepository
    {
        private readonly PreparationDBContext context;
        
        /// <summary>
        /// Initializes a new instance of the SystemUserRepository class.
        /// </summary>
        /// <param name="context">The database context to use for data access.</param>
        public DocumentRepository(PreparationDBContext context)
        {
            this.context = context;
        }

        /// <inheritdoc cref="IDocumentRepository.GetAll"/>
        public async Task<Document> Add(Document Document)
        {
            context.Documents.Add(Document);
            await context.SaveChangesAsync();
            return Document;
        }

        /// <inheritdoc cref="IDocumentRepository.Delete(Guid)"/>
        public async Task Delete(Guid Guid)
        {
            var Document = await context.Documents.FindAsync(Guid);
            if (Document == null)
            {
                throw new InvalidOperationException("Document not found");
            }
            context.Documents.Remove(Document);
            await context.SaveChangesAsync();
        }

        /// <inheritdoc cref="IDocumentRepository.Delete(string)"/>
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

        /// <inheritdoc cref="IDocumentRepository.GetAll"/>
        public async Task<IEnumerable<Document>> GetAll()
        {
            return await context.Documents.ToListAsync();
        }

        /*
        /// <inheritdoc cref="ISystemUserRepository.GetByCredentials(string, string)"/>
        public async Task<SystemUser?> GetByCredentials(string username, string password)
        {
            var systemUser = await context.SystemUsers.SingleOrDefaultAsync(x => x.Username == username && x.Password == password);

            return systemUser;
        }
        */

        /// <inheritdoc cref="IDocumentRepository.GetByGuid(Guid)"/>
        public async Task<Document?> GetByGuid(Guid Guid)
        {
            var Document = await context.Documents.SingleOrDefaultAsync(x => x.Guid == Guid);

            return Document;
        }

        /// <inheritdoc cref="IDocumentRepository.GetByNumber(string)"/>
        public async Task<Document?> GetByNumber(string ReferenceNumber)
        {
            Document? Document = await context.Documents.SingleOrDefaultAsync(x => x.ReferenceNumber == ReferenceNumber);

            return Document;
        }

        /// <inheritdoc cref="IDocumentRepository.Update(Document)"/>
        public async Task<Document?> Update(Document Document)
        {
            var existingDocument = await context.Documents.FindAsync(Document.Guid);
            if (existingDocument == null)
            {
                throw new InvalidOperationException($"The document with ID '{Document.Guid}' was not found.");
            }

            context.Entry(existingDocument).CurrentValues.SetValues(Document);
            await context.SaveChangesAsync();

            return existingDocument;
        }
    }
}
