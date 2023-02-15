using System.Runtime.Serialization;

namespace Preparation.API.Models
{
    public class AnnouncementPostResponseModel
    {
        [DataMember]
        public Guid LicitationGuid { get; set; }

        public AnnouncementPostResponseModel(Guid licitationGuid)
        {
            LicitationGuid = licitationGuid;
        }
    }
}
