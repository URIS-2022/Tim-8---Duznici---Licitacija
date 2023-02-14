using Administration.API.Entities;

namespace Administration.API.Models;

public class CommitteePatchRequestModel
{
    public DateTime DateAssembled { get; set; }
    public ICollection<CommitteeMember> CommitteeMembers { get; set; }

    public CommitteePatchRequestModel() { }
}
