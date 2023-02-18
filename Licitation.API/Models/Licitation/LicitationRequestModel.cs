namespace Licitation.API.Models.Licitation
{
    /**
    Represents a REQUEST model for posting a new licitation.
    */
    public class LicitationRequestModel
    {
        /// <summary>
        /// The Stage of the LICITATION.
        /// </summary>
        public int Stage { get; set; }
        /// <summary>
        /// The Date of the LICITATION.
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// The Year of the LICITATION.
        /// </summary>
        public int Year { get; set; }
        /// <summary>
        /// The unique identifier of the LICITATION.
        /// </summary>
        public int Constarint { get; set; }
        /// <summary>
        /// The unique identifier of the LICITATION.
        /// </summary>
        public int BidIncrement { get; set; }
        /// <summary>
        /// The unique identifier of the LICITATION.
        /// </summary>
        public DateTime ApplicationDeadline { get; set; }

        /// <summary>
        /// The representing constructor.
        /// </summary>
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

