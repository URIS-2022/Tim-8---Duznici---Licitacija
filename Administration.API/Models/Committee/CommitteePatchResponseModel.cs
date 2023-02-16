using Administration.API.Models.CommitteeMember;
using System.Runtime.Serialization;

namespace Administration.API.Models.Committee;

/// <summary>
/// Represents a patch response model for the document retrieval operation.
/// </summary>
[DataContract(Name = "Committee", Namespace = "")]
public class CommitteePatchResponseModel
{
    /// <summary>
    /// Gets or sets the date when the committee was assembled.
    /// </summary>
    [DataMember]
    public DateTime DateAssembled { get; set; }

    /// <summary>
    /// Initializes a new instance of the CommitteePostResponseModel class.
    /// </summary>
    [DataMember]
    public IEnumerable<CommitteeMemberCommitteePatchResponseModel>? CommitteeMembers { get; set; }

    /// <summary>
    /// Initializes a new instance of the CommitteePatchResponseModel class.
    /// </summary>
    public CommitteePatchResponseModel() { }
}
