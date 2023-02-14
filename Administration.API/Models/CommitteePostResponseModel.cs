using Administration.API.Entities;

namespace Administration.API.Models;

public class CommitteePostResponseModel
{
    public DateTime DateAssembled { get; set; }
    public ICollection<CommitteeMember> CommitteeMembers { get; set; }

    public CommitteePostResponseModel() { }
}
