using System.ComponentModel.DataAnnotations;


namespace Person.API.Models.ContactPerson
{
    /// <summary>
    /// Dto Update kontakt osoba
    /// </summary>
    public class ContactPersonUpdateModel
    {
        /// <summary>
        /// Ime kontakt osobe
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti ime!")]
        public string FirstName { get; set; }

        /// <summary>
        /// Prezime kontakt osobe
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti prezime!")]
        public string LastName { get; set; }

        /// <summary>
        /// Funckija kontakt osobe
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
