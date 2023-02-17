using System.Runtime.Serialization;

namespace Licitation.API.Models.Licitation
{
    [DataContract(Name = "Licitation", Namespace = "")]
    public class LicitationResponseModel
    {
        [DataMember]
        public Guid Guid { get; set; }
        [DataMember]
        public int Stage { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public int Year { get; set; }
        [DataMember]
        public int Constarint { get; set; }
        [DataMember]
        public int BidIncrement { get; set; }
        [DataMember]
        public DateTime ApplicationDeadline { get; set; }

        [DataMember]
        public IEnumerable<LicitationLandLicitationResponseModel> LicitationLands { get; set; }
        [DataMember]
        public IEnumerable<LicitationPublicBiddingLicitationResponseModel> LicitationPublicBiddings { get; set; }

        public LicitationResponseModel()
        {

        }
    }
}
