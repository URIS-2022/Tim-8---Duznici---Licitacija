using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace Landlot.API.Models
{
    public class LotCreationModel
    {
        /// <summary>
        /// Lot guid
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti id dela parcele!")]
        public Guid LotGuid { get; set; }

        /// <summary>
        /// Guid parcele
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti id parcele!")]
        public Guid LandGuid { get; set; }

        /// <summary>
        /// Datum isteka
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti datum isteka!")]
        public DateTime ExpiryDate { get; set; }

        /// <summary>
        /// Povrsina dela parcele
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti površinu dela parcele.")]
        public int LotArea { get; set; }

        /// <summary>
        /// Korisnik dela parcele
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti korisnika dela parcele.")]
        public int LotUser { get; set; }

        /// <summary>
        /// Broj dela parcele
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti broj dela parcele.")]
        public int LotNumber { get; set; }

        /// <summary>
        /// Kultura stvarno stanje
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti odgovarajuću vrednost kulture dela parcele.")]
        public string LandCultureState { get; set; }

        /// <summary>
        /// Obradivnost zemljista stvarno stanje
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti odgovarajuću obradivost dela parcele.")]
        public string LandProcessingState { get; set; }


        // <summary>
        /// Zasticena zona stvarno stanje
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti odgovarajuću vrednost statusa zaštićene zone dela parcele.")]
        public string ProtectedZoneState { get; set; }


        /// <summary>
        /// Drenaza stvarno stanje
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti odgovarajuću vrstu drenaže.")]
        public string DrainageState { get; set; }

    }
}
