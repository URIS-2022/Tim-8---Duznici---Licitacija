using System.Runtime.Serialization;

namespace Administration.API.Models.CommitteeMember;

/// <summary>
/// Represents a patch response response model for the document retrieval operation.
/// </summary>
public class CommitteeMemberPatchResponseModel
{
    /// <summary>
    /// Gets or sets the unique identifier of the committee.
    /// </summary>
    [DataMember]
    public Guid CommitteeGuid { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the member.
    /// </summary>
    [DataMember]
    public Guid MemberGuid { get; set; }

    /// <summary>
    /// Gets or sets the role of the member in committee.
    /// </summary>
    [DataMember]
    public string? MemberRole { get; set; }
}
