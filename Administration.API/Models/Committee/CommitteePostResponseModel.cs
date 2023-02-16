using System.Runtime.Serialization;
using Administration.API.Models.CommitteeMember;

namespace Administration.API.Models.Committee;

[DataContract(Name = "Committee", Namespace = "")]
public class CommitteePostResponseModel
{
    [DataMember]
    public DateTime DateAssembled { get; set; }

    [DataMember]
    public IEnumerable<CommitteeMemberCommitteeGetResponseModel> CommitteeMembers { get; set; }

    public CommitteePostResponseModel() { }
}
