using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Landlot.API.Models
{
    public class LandCreationModel
    {
        /// <summary>
        /// Land id
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti id parcele!")]
        public Guid LandId { get; set; }

        /// <summary>
        /// Povrsina parcele
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti površinu parcele.")]
        public int TotalArea { get; set; }

        /// <summary>
        /// ID opstine
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti šifru opštine.")]
        public Guid MunicipalityId { get; set; }

        /// <summary>
        /// Naziv opstine
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti naziv odgovarajuće opštine.")]
        public string NameOfTheMunicipality { get; set; }

        /// <summary>
        /// Lista nepokretnosti
        /// </summary>
        [MaxLength(15)]
        [Required(ErrorMessage = "Obavezno je uneti broj liste nepokretnosti.")]
        public string RealEstateNumber { get; set; }

        /// <summary>
        /// Kultura 
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti odgovarajuću vrednost kulture.")]
        public string LandCulture { get; set; }

        /// <summary>
        /// Klasa 
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti odgovarajuću vrednost klase.")]
        public string LandClass { get; set; }

        /// <summary>
        /// Obradivnost zemljista
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti odgovarajuću obradivost.")]
        public string LandProcessing { get; set; }

        // <summary>
        /// Zasticena zona 
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti odgovarajuću vrednost statusa zaštićene zone.")]
        public string ProtectedZone { get; set; }


        /// <summary>
        /// Tip svojine
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti odgovarajući tip svojine.")]
        public string PropertyType { get; set; }


        /// <summary>
        /// Drenaza
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti odgovarajuću vrstu drenaže.")]
        public string Drainage { get; set; }


    }
}