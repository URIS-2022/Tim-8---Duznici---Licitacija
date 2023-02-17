using Administration.API.Models.CommitteeMember;
using System.Runtime.Serialization;

namespace Administration.API.Models.Committee;

/// <summary>
/// Represents a get response model for the document retrieval operation.
/// </summary>
[DataContract(Name = "Committee", Namespace = "")]
public class CommitteeGetResponseModel
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
    /// Initializes a new instance of the CommitteePostResponseModel class.
    /// </summary>
    [DataMember]
    public IEnumerable<CommitteeMemberCommitteeGetResponseModel>? CommitteeMembers { get; set; }

    /// <summary>
    /// Initializes a new instance of the CommitteeGetResponseModel class.
    /// </summary>
    public CommitteeGetResponseModel() { }
}
