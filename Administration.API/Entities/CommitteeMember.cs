namespace Administration.API.Entities;

/// <summary>
/// Represents a member-committee relation.
/// </summary>
public class CommitteeMember
{
    /// <summary>
    /// Gets or sets the GUID of the committee this member belongs to.
    /// </summary>
    public Guid CommitteeGuid { get; set; }

    /// <summary>
    /// Gets or sets the committee this member belongs to.
    /// </summary>
    public Committee? Committee { get; set; }

    /// <summary>
    /// Gets or sets the GUID of the member who is a part of the committee.
    /// </summary>
    public Guid MemberGuid { get; set; }

    /// <summary>
    /// Gets or sets the member who is a part of the committee.
    /// </summary>
    public Member? Member { get; set; }

    /// <summary>
    /// Gets or sets the role of the member in the committee.
    /// </summary>
    public string Role { get; set; } = "Member";

    /// <summary>
    /// Initializes a new instance of the CommitteeMember class.
    /// </summary>
    public CommitteeMember() { }

    /// <summary>
    /// Initializes a new instance of the CommitteeMember class with the specified committee GUID, member GUID, and role.
    /// </summary>
    /// <param name="committeeGuid">The GUID of the committee this member belongs to.</param>
    /// <param name="memberGuid">The GUID of the member who is a part of the committee.</param>
    /// <param name="role">The role of the member in the committee.</param>
    public CommitteeMember(Guid committeeGuid, Guid memberGuid, string role)
    {
        CommitteeGuid = committeeGuid;
        MemberGuid = memberGuid;
        Role = role;
    }
}
