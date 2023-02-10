namespace Licitation.API.Models.Licitation
{
    /// <summary>
    /// DTO za kreiranje licitacije
    /// </summary>
    public class LicitationCreate
    {
        /// <summary>
        /// Broj licitacije
        /// </summary>
        public int Stage { get; set; }

        /// <summary>
        /// Datum licitacije
        /// </summary>
        public DateOnly Date { get; set; }

        /// <summary>
        /// Godina
        /// </summary>
        public int Yaer { get; set; }

        /// <summary>
        /// Ogranicenje
        /// </summary>
        public int Constraint { get; set; }

        /// <summary>
        /// Korak cene
        /// </summary>
        public int BidIncrement { get; set; }

        /// <summary>
        /// Rok za prijavu, datum i vreme
        /// </summary>
        public DateTime ApplicationDeadline { get; set; }
    }
}

