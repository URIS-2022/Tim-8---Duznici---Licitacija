using System.ComponentModel.DataAnnotations;

namespace Administration.API.Entities;

public class Committee
{
    [Key]
    public Guid Guid { get; set; }
    public DateTime DateAssembled { get; set; }
    public ICollection<CommitteeMember>? CommitteeMembers { get; set; }

    public Committee(Guid guid, DateTime dateAssembled, ICollection<CommitteeMember>? committeeMembers = null)
    {
        Guid = guid;
        DateAssembled = dateAssembled;
        CommitteeMembers = committeeMembers ?? new HashSet<CommitteeMember>();
    }

    public Committee(DateTime dateAssembled)
    {
        Guid = Guid.NewGuid();
        DateAssembled = dateAssembled;
        CommitteeMembers = new HashSet<CommitteeMember>();
    }

    public Committee(DateTime dateAssembled, ICollection<CommitteeMember>? committeeMembers = null)
    {
        Guid = Guid.NewGuid();
        DateAssembled = dateAssembled;
        CommitteeMembers = committeeMembers ?? new HashSet<CommitteeMember>();
    }
}
