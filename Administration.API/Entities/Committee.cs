using System.ComponentModel.DataAnnotations;

namespace Administration.API.Entities;

public class Committee
{
    [Key]
    public Guid Guid { get; set; }
    public DateTime DateAssembled { get; set; }
    public IEnumerable<Document> Documents { get; set; }
    public IEnumerable<CommitteeMember> CommitteeMembers { get; set; }

    public Committee(Guid guid, DateTime dateAssembled, ICollection<CommitteeMember>? committeeMembers = null, IEnumerable<Document>? documents = null)
    {
        Guid = guid;
        DateAssembled = dateAssembled;
        CommitteeMembers = committeeMembers ?? new HashSet<CommitteeMember>();
        Documents = documents ?? new HashSet<Document>();
    }

    public Committee()
    {
        CommitteeMembers = new HashSet<CommitteeMember>();
        Documents = new HashSet<Document>();
    }

    public Committee(DateTime dateAssembled, ICollection<CommitteeMember>? committeeMembers = null, IEnumerable<Document>? documents = null)
    {
        Guid = Guid.NewGuid();
        DateAssembled = dateAssembled;
        CommitteeMembers = committeeMembers ?? new HashSet<CommitteeMember>();
        Documents = documents ?? new HashSet<Document>();
    }
}
