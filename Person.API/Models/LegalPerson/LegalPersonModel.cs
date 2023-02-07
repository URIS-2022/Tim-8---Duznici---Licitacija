using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Person.API.Models.ContactPerson;


namespace Person.API.Models.LegalPerson
{
    /// <summary>
    /// Dto pravno lica
    /// </summary>
    public class LegalPersonModel
    {
        public ContactPersonModel ContactPerson { get; set; }
        /// <summary>
        /// Naziv pravnog lica
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Matični broj pravnog lica
        /// </summary>
        /// 
        public string IdentificationNumber { get; set; }
        /// <summary>
        /// Adresa id
        /// </summary>
        public Guid AddressId { get; set; }
        /// <summary>
        /// Broj telefona pravnog lica
        /// </summary>
        public string PhoneNumber1 { get; set; }

        /// <summary>
        /// Broj telefona 2 pravnog lica
        /// </summary>
        public string PhoneNumber2 { get; set; }

        /// <summary>
        /// Faks pravnog lica
        /// </summary>
        public string Fax { get; set; }

        /// <summary>
        /// Email pravnog lica
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Broj računa pravnog lica
        /// </summary>
        public string AccountNumber { get; set; }

    }

}

