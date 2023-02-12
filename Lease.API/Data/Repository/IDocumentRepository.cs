using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lease.API.Entities;

namespace Lease.API.Data.Repository;

public interface IDocumentRepository
{
    Task<Document> GetByGuid(Guid id);
    Task<List<Document>> GetAll();
    Task<Document> Add(Document document);
    Task<Document> Update(Document document);
    Task<Document> Delete(Guid id);
}