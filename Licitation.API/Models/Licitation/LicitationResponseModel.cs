using Licitation.API.Entities;
using Licitation.API.Models.LicitationLands;
using Licitation.API.Models.LicitationPBResponse;
using System.Runtime.Serialization;
using System.Xml.Linq;

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


        //[DataMember]
        //public List<LicitationLand> LandGuids { get; set; }

        //[DataMember]
        //public List<LicitationPublicBidding> PublicBiddingGuids { get; set; }

        //[DataMember]
        //public IEnumerable<LicitationPubblicBiddingLicitationResponseModel> PublicBiddings { get; set; }

        public LicitationResponseModel()
        {

        }
    }
}
