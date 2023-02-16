namespace Administration.API.Entities;

public class CommitteeMember
{
    public Guid CommitteeGuid { get; set; }
    public Committee Committee { get; set; }
    public Guid MemberGuid { get; set; }
    public Member Member { get; set; }
    public string Role { get; set; }

    public CommitteeMember() { }

    public CommitteeMember(Guid committeeGuid, Guid memberGuid, string role)
    {
        CommitteeGuid = committeeGuid;
        MemberGuid = memberGuid;
        Role = role;
    }

    public CommitteeMember(Committee committee, Member member, string role)
    {
        Committee = committee;
        Member = member;
        Role = role;
    }
}
