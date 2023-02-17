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

        public LicitationRequestModel(int stage, DateTime date, int year, int constarint, int bidIncrement, DateTime applicationDeadline)
        {
            Stage = stage;
            Date = date;
            Year = year;
            Constarint = constarint;
            BidIncrement = bidIncrement;
            ApplicationDeadline = applicationDeadline;
        }
    }
}

