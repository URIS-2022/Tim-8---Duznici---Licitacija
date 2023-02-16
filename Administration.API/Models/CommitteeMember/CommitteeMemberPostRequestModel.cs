namespace Administration.API.Models.CommitteeMember;

public class CommitteeMemberPostRequestModel
{
    public Guid MemberGuid { get; set; }
    public string MemberRole { get; set; }
}
