using Administration.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Administration.API.Data.Repository;

/// <summary>
/// Implementation of the IDocumentRepository
/// interface for managing Document entities in the database.
/// </summary>
public class DocumentRepository : IDocumentRepository
{
    private readonly AdministrationDbContext context;

    /// <summary>
    /// Initializes a new instance of the DocumentRepository class.
    /// </summary>
    /// <param name="context">The database context to use for data access.</param>
    public DocumentRepository(AdministrationDbContext context)
    {
        this.context = context;
    }

    /// <inheritdoc cref="IDocumentRepository.GetDocuments"/>
    public async Task<IEnumerable<Document>> GetDocuments()
    {
        return await context.Documents.ToListAsync();
    }

    /// <inheritdoc cref="IDocumentRepository.GetDocument"/>
    public async Task<Document?> GetDocument(Guid id)
    {
        return await context.Documents.FindAsync(id);
    }

    /// <inheritdoc cref="IDocumentRepository.UpdateDocument"/>
    public async Task<Document?> UpdateDocument(Guid id, Document updateModel)
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
    public async Task<Document?> AddDocument(Document document)
    {
        var created = context.Documents.Add(document);
        await context.SaveChangesAsync();
        return created.Entity;
    }

    /// <inheritdoc cref="IDocumentRepository.DeleteDocument"/>
    public async Task DeleteDocument(Guid id)
    {
        var systemUser = await context.Documents.FindAsync(id);
        if (systemUser == null)
        {
            throw new InvalidOperationException("Document not found");
        }
        context.Documents.Remove(systemUser);
        await context.SaveChangesAsync();
    }
}
