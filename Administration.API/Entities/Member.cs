using System.ComponentModel.DataAnnotations;

namespace Administration.API.Entities;

/// <summary>
/// Represents a member in a committee.
/// </summary>
public class Member
{
    /// <summary>
    /// Gets or sets the unique identifier of the member.
    /// </summary>
    [Key]
    public Guid Guid { get; set; }

    /// <summary>
    /// Gets or sets the first name of the member.
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Gets or sets the last name of the member.
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Gets or sets the committee members associated with the member.
    /// </summary>
    public IEnumerable<CommitteeMember> CommitteeMembers { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Member"/> class with the specified parameters.
    /// </summary>
    /// <param name="guid">The unique identifier of the member.</param>
    /// <param name="firstName">The first name of the member.</param>
    /// <param name="lastName">The last name of the member.</param>
    /// <param name="committeeMembers">The committee members associated with the member.</param>
    public Member(Guid guid, string firstName, string lastName, ICollection<CommitteeMember>? committeeMembers = null)
    {
        Guid = guid;
        FirstName = firstName;
        LastName = lastName;
        CommitteeMembers = committeeMembers ?? new HashSet<CommitteeMember>();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Member"/> class with the specified parameters.
    /// </summary>
    /// <param name="firstName">The first name of the member.</param>
    /// <param name="lastName">The last name of the member.</param>
    /// <param name="committeeMembers">The committee members associated with the member.</param>
    public Member(string firstName, string lastName, ICollection<CommitteeMember>? committeeMembers = null)
    {
        Guid = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        CommitteeMembers = committeeMembers ?? new HashSet<CommitteeMember>();
    }
}
