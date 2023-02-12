using Licitation.API.Entities;
using Licitation.API.Models.LicitationLands;
using Licitation.API.Models.LicitationPB;
using System.Collections.ObjectModel;

namespace Licitation.API.Models.Licitation
{
    public class LicitationRequestModel
    {
        public int Stage { get; set; }
        public DateTime Date { get; set; }
        public int Year { get; set; }
        public int Constarint { get; set; }
        public int BidIncrement { get; set; }
        public DateTime ApplicationDeadline { get; set; }
        public List<LicitationLandRequest> LandGuids { get; set; }

        public List<LicitationPublicBiddingRequest> PublicBiddingGuids { get; set; }

        public LicitationRequestModel(int stage, DateTime date, int year, int constarint, int bidIncrement, DateTime applicationDeadline, List<LicitationLandRequest> landGuids, List<LicitationPublicBiddingRequest> publicBiddingGuids)
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

