using Administration.API.Models.CommitteeMember;
using System.Runtime.Serialization;

namespace Administration.API.Models.Committee;

/// <summary>
/// Represents a post response model for the document retrieval operation.
/// </summary>
[DataContract(Name = "Committee", Namespace = "")]
public class CommitteePostResponseModel
{
    /// <summary>
    /// Gets or sets the date when the committee was assembled.
    /// </summary>
    [DataMember]
    public DateTime DateAssembled { get; set; }

    /// <summary>
    /// Gets or sets the list of members that are in the committee.
    /// </summary>
    [DataMember]
    public IEnumerable<CommitteeMemberCommitteeGetResponseModel>? CommitteeMembers { get; set; }

    /// <summary>
    /// Initializes a new instance of the CommitteePostResponseModel class.
    /// </summary>
    public CommitteePostResponseModel() { }
}
