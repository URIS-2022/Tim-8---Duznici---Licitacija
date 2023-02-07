using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Person.API.Models.ContactPerson;

namespace Person.API.Models.LegalPerson
{
    /// <summary>
    ///  Dto Update pravno lice
    /// </summary>
    public class LegalPersonUpdateModel
    {
        /// <summary>
        /// Kontakt osoba
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti kontakt osobu!")]
        public Guid ContactPersonId { get; set; }

        /// <summary>
        /// Naziv pravnog lica
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti naziv!")]
        public string Name { get; set; }

        /// <summary>
        /// Matični broj pravnog lica
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti maticni broj!")]
        public string IdentificationNumber { get; set; }

        /// <summary>
        /// Adresa id
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti id adrese!")]
        public Guid AddressId { get; set; }

        /// <summary>
        /// Broj telefona pravnog lica
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti broj telefona 1!")]
        public string PhoneNumber1 { get; set; }

        /// <summary>
        /// Broj telefona 2 pravnog lica
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti broj telefona 2!")]
        public string PhoneNumber2 { get; set; }

        /// <summary>
        /// Faks pravnog lica
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti faks!")]
        public string Fax { get; set; }

        /// <summary>
        /// Email pravnog lica
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti email!")]
        public string Email { get; set; }

        /// <summary>
        /// Broj računa pravnog lica
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti broj racuna!")]
        public string AccountNumber { get; set; }

    }
}
