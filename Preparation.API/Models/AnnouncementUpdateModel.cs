namespace Preparation.API.Models
{
    public class AnnouncementUpdateModel
    {
        public Guid? LicitationGuid { get; set; }

        public AnnouncementUpdateModel(Guid? licitationGuid)
        {
            LicitationGuid = licitationGuid;
        }
    }
}
