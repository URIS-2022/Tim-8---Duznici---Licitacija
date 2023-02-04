using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Person.API.Models.ContactPerson
    
{
    /// <summary>
    /// Dto kontakt osoba
    /// </summary>
    public class ContactPersonDto
    {
        /// <summary>
        /// Ime kontakt osobe
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Prezime kontakt osobe
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Funkcija kontakt osoba
        /// </summary>
        public string Function { get; set; }

        /// <summary>
        /// Telefon kontakt osobe
        /// </summary>
        public string PhoneNumber { get; set; }
    }
}