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
        public Guid LandGuids { get; set; }

        public LicitationUpdateModel(int? stage, DateTime? date, int? year, int? constarint, int? bidIncrement, DateTime? applicationDeadline, Guid landGuids)
        {
            Stage = stage;
            Date = date;
            Year = year;
            Constarint = constarint;
            BidIncrement = bidIncrement;
            ApplicationDeadline = applicationDeadline;
            LandGuids = landGuids;
        }
    }
}
