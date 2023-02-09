﻿using System.ComponentModel.DataAnnotations;

namespace Person.API.Models.LegalPerson
{
    /// <summary>
    /// Dto Create pravno lice
    /// </summary>
    public class LegalPersonCreationModel
    {
        /// <summary>
        /// Kontakt osoba id
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti id kontakt osobe!")]
        public Guid ContactPersonId { get; set; }

        /// <summary>
        /// Naziv pravnog lica
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti naziv!")]
        public string Name { get; set; }

        /// <summary>
        /// Matični broj pravnog lica
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti matični broj!")]
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
        [Required(ErrorMessage = "Obavezno je uneti broj računa!")]
        public string AccountNumber { get; set; }
    }
}