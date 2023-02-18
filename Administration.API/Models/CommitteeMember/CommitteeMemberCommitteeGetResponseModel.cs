using System.Runtime.Serialization;

namespace Administration.API.Models.CommitteeMember;

/// <summary>
/// Represents a CommitteeMember in CommitteeGetResponseModel.
/// </summary>
[DataContract(Name = "CommitteeMember", Namespace = "")]
public class CommitteeMemberCommitteeGetResponseModel
{
    /// <summary>
    /// Gets or sets the unique identifier of the committee.
    /// </summary>
    [DataMember]
    public Guid Guid { get; set; }

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
    /// Gets or sets the rome of the member in committee.
    /// </summary>
    [DataMember]
    public string? Role { get; set; }

}
