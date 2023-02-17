using Licitation.API.Entities;

namespace Licitation.API.Data.Repository
{
    /// <summary>
    /// The interface for document repository, provides methods for getting, updating, adding and deleting a document
    /// </summary>
    public interface IDocumentRepository
    {
        /// <summary>
        /// Gets a list of all documents.
        /// </summary>
        /// <returns>A list of documents.</returns>
        Task<IEnumerable<Entities.Document>> GetDocuments();

        /// <summary>
        /// Gets a specific document by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the document.</param>
        /// <returns>The document with the specified identifier.</returns>
        Task<Entities.Document?> GetDocument(Guid id);

        /// <summary>
        /// Updates a specific document.
        /// </summary>
        /// <param name="id">The identifier of the document to update.</param>
        /// <param name="patchDocument">The updated values for the document.</param>
        /// <returns>The updated document.</returns>
        Task<Entities.Document?> UpdateDocument(Guid id, Entities.Document patchDocument);

        /// <summary>
        /// Adds a new document.
        /// </summary>
        /// <param name="document">The document to add.</param>
        /// <returns>The added document.</returns>
        Task<Entities.Document?> AddDocument(Entities.Document document);

        /// <summary>
        /// Deletes a specific document.
        /// </summary>
        /// <param name="id">The identifier of the document to delete.</param>
        /// <returns>The deleted document.</returns>
        Task DeleteDocument(Guid id);
    }
}
