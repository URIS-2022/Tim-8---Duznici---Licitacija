using System.Runtime.Serialization;

namespace Preparation.API.Models
{
    [DataContract(Name = "Announcement", Namespace = "")]
    public class AnnouncementResponseModel
    {
        [DataMember]
        public Guid LicitationGuid { get; set; }

        public AnnouncementResponseModel(Guid licitationGuid)
        {
            LicitationGuid = licitationGuid;
        }
    }
}
