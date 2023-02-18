using Microsoft.EntityFrameworkCore;

namespace Licitation.API.Data.Repository
{
    /// <summary>
    /// Implementation of the IDocumentRepository
    /// interface for managing Document entities in the database.
    /// </summary>
    public class DocumentRepository : IDocumentRepository
    {
        private readonly LicitationDBContext context;

        /// <summary>
        /// Initializes a new instance of the DocumentRepository class.
        /// </summary>
        /// <param name="context">The database context to use for data access.</param>
        public DocumentRepository(LicitationDBContext context)
        {
            this.context = context;
        }

        /// <inheritdoc cref="IDocumentRepository.GetDocuments"/>
        /// <returns>An enumerable collection of Document entities</returns>
        public async Task<IEnumerable<Entities.Document>> GetDocuments()
        {
            return await context.Documents.ToListAsync();
        }

        /// <inheritdoc cref="IDocumentRepository.GetDocument"/>
        /// <returns>The Document entity with the specified ID, or null if not found</returns>
        public async Task<Entities.Document?> GetDocument(Guid id)
        {
            return await context.Documents.FindAsync(id);
        }

        /// <inheritdoc cref="IDocumentRepository.UpdateDocument"/>
        public async Task<Entities.Document?> UpdateDocument(Guid id, Entities.Document updateModel)
        {
            var document = await context.Documents.FirstOrDefaultAsync(c => c.Guid == id);
            if (document == null)
            {
                return null;
            }
            context.Entry(document).CurrentValues.SetValues(updateModel);
            await context.SaveChangesAsync();
            return document;
        }

        /// <inheritdoc cref="IDocumentRepository.AddDocument"/>
        /// <returns>The created Document entity</returns>
        public async Task<Entities.Document?> AddDocument(Entities.Document document)
        {
            var created = context.Documents.Add(document);
            await context.SaveChangesAsync();
            return created.Entity;
        }

        /// <inheritdoc cref="IDocumentRepository.DeleteDocument"/>
        public async Task DeleteDocument(Guid id)
        {
            var document = await context.Documents.FindAsync(id);
            if (document == null)
            {
                throw new InvalidOperationException("Document not found");
            }
            context.Documents.Remove(document);
            await context.SaveChangesAsync();
        }

    }
}


