using System.Runtime.Serialization;

namespace Preparation.API.Models
{
    [DataContract(Name = "Announcement", Namespace = "")]
    public class AnnouncementGetResponseModel
    {
        [DataMember]
        public Guid Guid { get; set; }
        [DataMember]
        public Guid LicitationGuid { get; set; }

        public AnnouncementGetResponseModel(Guid guid, Guid licitationGuid)
        {
            Guid = guid;
            LicitationGuid = licitationGuid;
        }
    }
}
