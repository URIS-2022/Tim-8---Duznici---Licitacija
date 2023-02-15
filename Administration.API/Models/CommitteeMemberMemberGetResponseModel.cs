using System.Runtime.Serialization;

namespace Administration.API.Models;

[DataContract(Name = "MemberCommittee", Namespace = "")]
public class CommitteeMemberMemberGetResponseModel
{
    [DataMember]
    public Guid Guid { get; set; }

    [DataMember]
    public DateTime DateAssembled { get; set; }

    [DataMember]
    public string MemberRole { get; set; }

}
