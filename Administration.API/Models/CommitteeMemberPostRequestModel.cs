namespace Administration.API.Models
{
    public class CommitteeMemberPostRequestModel
    {
        public Guid CommitteeGuid { get; set; }
        public Guid MemberGuid { get; set; }
        public string MemberRole { get; set; }
    }
}
