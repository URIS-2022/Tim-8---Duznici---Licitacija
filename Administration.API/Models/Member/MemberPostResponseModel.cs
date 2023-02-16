﻿using Administration.API.Models.CommitteeMember;
using System.Runtime.Serialization;

namespace Administration.API.Models.Member;

[DataContract(Name = "Member", Namespace = "")]
public class MemberPostResponseModel
{
    [DataMember]
    public string FirstName { get; set; }

    [DataMember]
    public string LastName { get; set; }

    [DataMember]
    public IEnumerable<CommitteeMemberMemberGetResponseModel> MemberCommittees { get; set; }

    public MemberPostResponseModel() { }
}
