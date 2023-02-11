using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace Landlot.API.Models
{
    public class LotModel
    {
        /// <summary>
        /// Lot id
        /// </summary>
        public Guid LotId { get; set; }

        /// <summary>
        /// Datum isteka
        /// </summary>
        public DateAndTime ExpiryDate { get; set; }


        /// <summary>
        /// Povrsina dela parcele
        /// </summary>
        public int LotArea { get; set; }

        /// <summary>
        /// Korisnik dela parcele
        /// </summary>
        public int LotUser { get; set; }

        /// <summary>
        /// Broj dela parcele
        /// </summary>
        public int LotNumber { get; set; }

        /// <summary>
        /// Kultura stvarno stanje
        /// </summary>
        public string LandCultureState { get; set; }

        /// <summary>
        /// Obradivnost zemljista stvarno stanje
        /// </summary>
        public string LandProcessingState { get; set; }


        // <summary>
        /// Zasticena zona stvarno stanje
        /// </summary>
        public string ProtectedZoneState { get; set; }


        /// <summary>
        /// Drenaza stvarno stanje
        /// </summary>
        public string DrainageState { get; set; }

    }
}
