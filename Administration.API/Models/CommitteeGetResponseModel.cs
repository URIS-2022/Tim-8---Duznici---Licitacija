using System.Runtime.Serialization;

namespace Administration.API.Models;

[DataContract(Name = "Committee", Namespace = "")]
public class CommitteeGetResponseModel
{
    [DataMember]
    public DateTime DateAssembled { get; set; }
    [DataMember]
    public ICollection<CommitteeMemberNestedResponseModel> CommitteeMembers { get; set; }

    public CommitteeGetResponseModel() { }
}
