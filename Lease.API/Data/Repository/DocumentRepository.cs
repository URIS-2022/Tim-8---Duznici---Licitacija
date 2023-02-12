using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lease.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lease.API.Data.Repository
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly LeaseDbContext _context;

        public DocumentRepository(LeaseDbContext context)
        {
            _context = context;
        }

        public async Task<Document> GetByGuid(Guid id)
        {
            return await _context.Documents.FirstOrDefaultAsync(d => d.Guid == id);
        }

        public async Task<List<Document>> GetAll()
        {
            return await _context.Documents.ToListAsync();
        }

        public async Task<Document> Add(Document document)
        {
            await _context.Documents.AddAsync(document);
            await _context.SaveChangesAsync();
            return document;
        }

        public async Task<Document> Update(Document document)
        {
            _context.Documents.Update(document);
            await _context.SaveChangesAsync();
            return document;
        }

        public async Task<Document> Delete(Guid id)
        {
            var document = await _context.Documents.FirstOrDefaultAsync(d => d.Guid == id);
            if (document == null) return null;

            _context.Documents.Remove(document);
            await _context.SaveChangesAsync();
            return document;
        }
    }
}
