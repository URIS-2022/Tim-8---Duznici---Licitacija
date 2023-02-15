using System.Runtime.Serialization;

namespace Administration.API.Models;

[DataContract(Name = "Committee", Namespace = "")]
public class CommitteePostResponseModel
{
    [DataMember]
    public DateTime DateAssembled { get; set; }

    [DataMember]
    public IEnumerable<CommitteeMemberCommitteeGetResponseModel> CommitteeMembers { get; set; }

    public CommitteePostResponseModel() { }
}
