namespace Preparation.API.Models
{
    public class AnnouncementRequestModel
    {
        
        public Guid LicitationGuid { get; set; }

        public AnnouncementRequestModel(Guid licitationGuid)
        {
            LicitationGuid = licitationGuid;
        }
    }
}
