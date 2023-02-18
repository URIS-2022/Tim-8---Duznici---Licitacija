namespace Licitation.API.Models.Licitation
{
    /**
    Represents a update model for licitation.
    */
    public class LicitationUpdateModel
    {
        /// <summary>
        /// The stage of the LICITATION.
        /// </summary>
        public int? Stage { get; set; }
        /// <summary>
        /// The DateTime of the LICITATION.
        /// </summary>
        public DateTime? Date { get; set; }
        /// <summary>
        /// The Year of the LICITATION.
        /// </summary>
        public int? Year { get; set; }
        /// <summary>
        /// The Constarint of the LICITATION.
        /// </summary>
        public int? Constarint { get; set; }
        /// <summary>
        /// The BidIncrement of the LICITATION.
        /// </summary>
        public int? BidIncrement { get; set; }
        /// <summary>
        /// The ApplicationDeadline of the LICITATION.
        /// </summary>
        public DateTime? ApplicationDeadline { get; set; }


        /// <summary>
        /// The representing constructor.
        /// </summary>
        public LicitationUpdateModel(int? stage, DateTime? date, int? year, int? constarint, int? bidIncrement, DateTime? applicationDeadline)
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
