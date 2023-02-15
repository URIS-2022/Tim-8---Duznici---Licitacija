using System.ComponentModel.DataAnnotations;

namespace Administration.API.Entities;

public class Member
{
    [Key]
    public Guid Guid { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public IEnumerable<CommitteeMember> CommitteeMembers { get; set; }

    public Member(Guid guid, string firstName, string lastName, ICollection<CommitteeMember>? committeeMembers = null)
    {
        Guid = guid;
        FirstName = firstName;
        LastName = lastName;
        CommitteeMembers = committeeMembers ?? new HashSet<CommitteeMember>();
    }
    public Member(string firstName, string lastName)
    {
        Guid = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        CommitteeMembers = new HashSet<CommitteeMember>();
    }

    public Member(string firstName, string lastName, ICollection<CommitteeMember>? committeeMembers = null)
    {
        Guid = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        CommitteeMembers = committeeMembers ?? new HashSet<CommitteeMember>();
    }
}
