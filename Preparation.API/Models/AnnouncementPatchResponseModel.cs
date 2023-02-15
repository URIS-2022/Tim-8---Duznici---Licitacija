using System.Runtime.Serialization;

namespace Preparation.API.Models
{
    [DataContract(Name = "Announcement", Namespace = "")]
    public class AnnouncementPatchResponseModel
    {
        [DataMember]
        public Guid Guid { get; set; }
        [DataMember]
        public Guid LicitationGuid { get; set; }

        public AnnouncementPatchResponseModel(Guid guid, Guid licitationGuid)
        {
            Guid = guid;
            LicitationGuid = licitationGuid;
        }
    }
}
