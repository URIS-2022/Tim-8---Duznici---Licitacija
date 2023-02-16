using Licitation.API.Entities;
using System.Runtime.Serialization;

namespace Licitation.API.Models.Licitation
{
    public class LicitationUpdateModel
    {
        public int? Stage { get; set; }
        public DateTime? Date { get; set; }
        public int? Year { get; set; }
        public int? Constarint { get; set; }
        public int? BidIncrement { get; set; }
        public DateTime? ApplicationDeadline { get; set; }
        public List<LicitationLand> LandGuids { get; set; }
        //public List<LicitationPublicBidding> PublicBiddingGuids { get; set; }



        public LicitationUpdateModel(int? stage, DateTime? date, int? year, int? constarint, int? bidIncrement, DateTime? applicationDeadline, List<LicitationLand> landGuids /*List<LicitationPublicBidding> publicBiddingGuids*/)
        {
            Stage = stage;
            Date = date;
            Year = year;
            Constarint = constarint;
            BidIncrement = bidIncrement;
            ApplicationDeadline = applicationDeadline;
            LandGuids = landGuids;
            //PublicBiddingGuids = publicBiddingGuids;
        }
    }
}
