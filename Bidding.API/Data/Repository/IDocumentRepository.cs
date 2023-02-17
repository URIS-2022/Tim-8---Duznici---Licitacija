using Bidding.API.Entities;

namespace Bidding.API.Data.Repository
{
    public interface IDocumentRepository
    {
        Task<IEnumerable<Document>> GetAllDocuments();
        Task<Document> GetDocumentByGuid(Guid guid);
        Task<Document?> GetDocumentByReferenceNumber(string referenceNumber);
        Task<Document> AddDocument(Document document);
        Task DeleteDocument(Guid guid);
        Task<Document?> UpdateDocument(Document document);
    }
}
