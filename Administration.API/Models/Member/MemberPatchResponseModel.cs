using Administration.API.Models.CommitteeMember;
using System.Runtime.Serialization;

namespace Administration.API.Models.Member;

/// <summary>
/// Represents a patch request model for the member retrieval operation.
/// </summary>
[DataContract(Name = "Member", Namespace = "")]
public class MemberPatchResponseModel
{
    /// <summary>
    /// Gets or sets the first name of the member.
    /// </summary>
    [DataMember]
    public string? FirstName { get; set; }

    /// <summary>
    /// Gets or sets the last name of the member.
    /// </summary>
    [DataMember]
    public string? LastName { get; set; }

    /// <summary>
    /// Gets or sets the list of committees that the member belongs to.
    /// </summary>
    [DataMember]
    public IEnumerable<CommitteeMemberMemberGetResponseModel>? MemberCommittees { get; set; }

    /// <summary>
    /// Initializes a new instance of the MemberPatchRequestModel class.
    /// </summary>
    public MemberPatchResponseModel() { }
}
