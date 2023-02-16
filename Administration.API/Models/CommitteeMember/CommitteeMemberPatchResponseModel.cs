namespace Administration.API.Models.CommitteeMember
{
    public class CommitteeMemberPatchResponseModel
    {
        public Guid CommitteeGuid { get; set; }
        public Guid MemberGuid { get; set; }
        public string MemberRole { get; set; }
    }
}
