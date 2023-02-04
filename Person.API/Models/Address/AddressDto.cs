using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Person.API.Models.Address
{
    /// <summary>
    /// Dto za adresu
    /// </summary>
    public class AddressDto
    {
        /// <summary>
        /// Drzava
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Ulica adrese
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// Broj adrese
        /// </summary>
        public string StreetNumber { get; set; }

        /// <summary>
        /// Mesto adrese
        /// </summary>
        public string Place { get; set; }

        /// <summary>
        /// Postanski broj adrese
        /// </summary>
        public string ZipCode { get; set; }


    }
}
