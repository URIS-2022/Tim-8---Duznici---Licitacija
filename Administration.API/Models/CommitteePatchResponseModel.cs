using System.Runtime.Serialization;

namespace Administration.API.Models;

[DataContract(Name = "Committee", Namespace = "")]
public class CommitteePatchResponseModel
{
    [DataMember]
    public DateTime DateAssembled { get; set; }

    [DataMember]
    public IEnumerable<CommitteeMemberCommitteePatchResponseModel> CommitteeMembers { get; set; }

    public CommitteePatchResponseModel() { }
}
