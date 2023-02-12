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
        public List<LicitationLandResponse> LandGuids { get; set; }

        [DataMember]
        public List<LicitationPublicBiddingResponse> PublicBiddingGuids { get; set; }

        public LicitationResponseModel(int stage, DateTime date, int year, int constarint, int bidIncrement, DateTime applicationDeadline, List<LicitationLandResponse> landGuids, List<LicitationPublicBiddingResponse> publicBiddingGuids)
        {
            Stage = stage;
            Date = date;
            Year = year;
            Constarint = constarint;
            BidIncrement = bidIncrement;
            ApplicationDeadline = applicationDeadline;
            LandGuids = landGuids;
            PublicBiddingGuids = publicBiddingGuids;
        }
    }
}
