﻿using System.Runtime.Serialization;

namespace Administration.API.Models;

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
