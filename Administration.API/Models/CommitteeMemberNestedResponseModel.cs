﻿using System.Runtime.Serialization;

namespace Administration.API.Models;

[DataContract(Name = "CommitteeMember", Namespace = "")]
public class CommitteeMemberNestedResponseModel
{
    [DataMember]
    public Guid Guid { get; set; }
    [DataMember]
    public string FirstName { get; set; }
    [DataMember]
    public string LastName { get; set; }
    [DataMember]
    public string Role { get; set; }

}
