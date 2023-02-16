using System.ComponentModel.DataAnnotations;

namespace Administration.API.Entities;

/// <summary>
/// Represents a committee entity.
/// </summary>
public class Committee
{
    /// <summary>
    /// Gets or sets the unique identifier for the committee.
    /// </summary>
    [Key]
    public Guid Guid { get; set; }

    /// <summary>
    /// Gets or sets the date when the committee was assembled.
    /// </summary>
    public DateTime DateAssembled { get; set; }

    /// <summary>
    /// Gets or sets the documents associated with the committee.
    /// </summary>
    public IEnumerable<Document> Documents { get; set; }

    /// <summary>
    /// Gets or sets the committee members associated with the committee.
    /// </summary>
    public IEnumerable<CommitteeMember> CommitteeMembers { get; set; }

    /// <summary>
    /// Initializes a new instance of the Committee class with the specified unique identifier, date assembled, committee members and documents.
    /// </summary>
    /// <param name="guid">The unique identifier for the committee.</param>
    /// <param name="dateAssembled">The date when the committee was assembled.</param>
    /// <param name="committeeMembers">The committee members associated with the committee. Defaults to an empty collection if not provided.</param>
    /// <param name="documents">The documents associated with the committee. Defaults to an empty collection if not provided.</param>
    public Committee(Guid guid, DateTime dateAssembled, ICollection<CommitteeMember>? committeeMembers = null, IEnumerable<Document>? documents = null)
    {
        Guid = guid;
        DateAssembled = dateAssembled;
        CommitteeMembers = committeeMembers ?? new HashSet<CommitteeMember>();
        Documents = documents ?? new HashSet<Document>();
    }

    /// <summary>
    /// Initializes a new instance of the Committee class with default values.
    /// </summary>
    public Committee()
    {
        CommitteeMembers = new HashSet<CommitteeMember>();
        Documents = new HashSet<Document>();
    }

    /// <summary>
    /// Initializes a new instance of the Committee class with the specified date assembled, committee members and documents. The unique identifier will be generated automatically.
    /// </summary>
    /// <param name="dateAssembled">The date when the committee was assembled.</param>
    /// <param name="committeeMembers">The committee members associated with the committee. Defaults to an empty collection if not provided.</param>
    /// <param name="documents">The documents associated with the committee. Defaults to an empty collection if not provided.</param>
    public Committee(DateTime dateAssembled, ICollection<CommitteeMember>? committeeMembers = null, IEnumerable<Document>? documents = null)
    {
        Guid = Guid.NewGuid();
        DateAssembled = dateAssembled;
        CommitteeMembers = committeeMembers ?? new HashSet<CommitteeMember>();
        Documents = documents ?? new HashSet<Document>();
    }
}
