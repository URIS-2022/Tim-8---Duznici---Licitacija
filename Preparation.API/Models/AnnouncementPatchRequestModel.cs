namespace Preparation.API.Models
{
    public class AnnouncementPatchRequestModel
    {
        public Guid? LicitationGuid { get; set; }

        public AnnouncementPatchRequestModel(Guid? licitationGuid)
        {
            LicitationGuid = licitationGuid;
        }
    }
}
