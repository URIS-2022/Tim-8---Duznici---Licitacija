using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace Person.API.Models.ContactPerson
{

    /// <summary>
    /// Dto Create kontakt osoba
    /// </summary>
    public class ContactPersonCreationModel
    {
        /// <summary>
        /// Ime kontakt osobae
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti ime!")]
        public string FirstName { get; set; }

        /// <summary>
        /// Prezime kontakt osobe
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti prezime!")]
        public string LastName { get; set; }

        /// <summary>
        /// Funkcija kontakt osobe
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti funkciju!")]
        public string Function { get; set; }

        /// <summary>
        /// Telefon kontakt osobe
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti telefon!")]
        public string PhoneNumber { get; set; }
    }
}
