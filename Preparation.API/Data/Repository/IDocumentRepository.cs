using Preparation.API.Entities;

namespace Preparation.API.Data.Repository
{
    public interface IDocumentRepository
    {
        
        Task<IEnumerable<Document>> GetAll();

        Task<Document?> GetByGuid(Guid Guid);

        Task<Document?> GetByNumber(string ReferenceNumber);

        Task<Document?> Add(Document Document);

        Task<Document?> Update(Document Document);

        Task Delete(Guid Guid);

        Task Delete(string ReferenceNumber);
    }
}
