using System.Runtime.Serialization;

namespace Administration.API.Models;

[DataContract(Name = "MemberCommittee", Namespace = "")]
public class CommitteeMemberMemberPatchResponseModel
{
    [DataMember]
    public DateTime DateAssembled { get; set; }

    [DataMember]
    public string MemberRole { get; set; }

}
