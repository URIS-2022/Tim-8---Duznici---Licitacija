using System.Runtime.Serialization;

namespace Administration.API.Models.CommitteeMember;

/// <summary>
/// Represents a CommitteeMember in MemberGetResponseModel.
/// </summary>
[DataContract(Name = "MemberCommittee", Namespace = "")]
public class CommitteeMemberMemberGetResponseModel
{
    /// <summary>
    /// Gets or sets the unique identifier of the committee.
    /// </summary>
    [DataMember]
    public Guid Guid { get; set; }

    /// <summary>
    /// Gets or sets the date when the committee was assembled.
    /// </summary>
    [DataMember]
    public DateTime DateAssembled { get; set; }

    /// <summary>
    /// Gets or sets the role of the member in committee.
    /// </summary>
    [DataMember]
    public string? MemberRole { get; set; }

}
