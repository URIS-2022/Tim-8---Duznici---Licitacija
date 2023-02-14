using Microsoft.EntityFrameworkCore;

namespace Licitation.API.Data.Repository;

public class DocumentRepository : IDocumentRepository
{
    private readonly LicitationDBContext _context;

    public DocumentRepository(LicitationDBContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Entities.Document>> GetAllDocuments()
    {
        return await _context.Documents.ToListAsync();
    }

    public async Task<Entities.Document> GetDocumentByGuid(Guid guid)
    {
        return await _context.Documents.FindAsync(guid);
    }

    public async Task<Entities.Document?> GetDocumentByReferenceNumber(string referenceNumber)
    {
        return await _context.Documents.FirstOrDefaultAsync(d => d.ReferenceNumber == referenceNumber);
    }

    public async Task<Entities.Document> AddDocument(Entities.Document document)
    {
        _context.Documents.Add(document);
        await _context.SaveChangesAsync();
        return document;
    }

    public async Task DeleteDocument(Guid guid)
    {
        var document = await GetDocumentByGuid(guid);
        if (document == null)
        {
            throw new InvalidOperationException($"The document with ID '{guid}' was not found.");
        }

        _context.Documents.Remove(document);
        await _context.SaveChangesAsync();
    }

    public async Task<Entities.Document?> UpdateDocument(Entities.Document document)
    {
        var existingDocument = await GetDocumentByGuid(document.Guid);
        if (existingDocument == null)
        {
            throw new InvalidOperationException($"The document with ID '{document.Guid}' was not found.");
        }

        _context.Entry(existingDocument).CurrentValues.SetValues(document);
        await _context.SaveChangesAsync();

        return existingDocument;
    }
}


