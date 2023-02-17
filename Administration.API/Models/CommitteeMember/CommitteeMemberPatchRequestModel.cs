using System.Runtime.Serialization;

namespace Administration.API.Models.CommitteeMember;

/// <summary>
/// Represents a patch request model for the document retrieval operation.
/// </summary>
public class CommitteeMemberPatchRequestModel
{
    /// <summary>
    /// Gets or sets the role of the member in committee.
    /// </summary>
    [DataMember]
    public string? MemberRole { get; set; }
}
