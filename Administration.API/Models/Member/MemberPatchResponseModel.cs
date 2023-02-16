using System.Runtime.Serialization;
using Administration.API.Models.CommitteeMember;

namespace Administration.API.Models.Member;

[DataContract(Name = "Member", Namespace = "")]
public class MemberPatchResponseModel
{
    [DataMember]
    public string FirstName { get; set; }

    [DataMember]
    public string LastName { get; set; }

    [DataMember]
    public IEnumerable<CommitteeMemberMemberGetResponseModel> MemberCommittees { get; set; }

    public MemberPatchResponseModel() { }
}
