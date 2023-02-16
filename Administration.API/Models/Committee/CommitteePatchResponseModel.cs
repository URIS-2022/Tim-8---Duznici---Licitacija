using Administration.API.Models.CommitteeMember;
using System.Runtime.Serialization;

namespace Administration.API.Models.Committee;

[DataContract(Name = "Committee", Namespace = "")]
public class CommitteePatchResponseModel
{
    [DataMember]
    public DateTime DateAssembled { get; set; }

    [DataMember]
    public IEnumerable<CommitteeMemberCommitteePatchResponseModel> CommitteeMembers { get; set; }

    public CommitteePatchResponseModel() { }
}
