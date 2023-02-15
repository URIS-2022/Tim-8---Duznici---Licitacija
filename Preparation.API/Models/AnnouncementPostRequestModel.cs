namespace Preparation.API.Models
{
    public class AnnouncementPostRequestModel
    {   
        public Guid LicitationGuid { get; set; }

        public AnnouncementPostRequestModel(Guid licitationGuid)
        {
            LicitationGuid = licitationGuid;
        }
    }
}
