using System.Runtime.Serialization;

namespace Administration.API.Models;

[DataContract(Name = "Committee", Namespace = "")]
public class CommitteeGetResponseModel
{
    [DataMember]
    public Guid Guid { get; set; }
    [DataMember]
    public DateTime DateAssembled { get; set; }
    [DataMember]
    public IEnumerable<CommitteeMemberCommitteeGetResponseModel> CommitteeMembers { get; set; }

    public CommitteeGetResponseModel() { }
}
