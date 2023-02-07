using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Person.API.Models.PhysicalPerson
{
    /// <summary>
    /// Dto fizicko lice
    /// </summary>
    public class PhysicalPersonModel
    {
        /// <summary>
        /// Ime fizičkog lica
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Prezime fizičkog lica
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Jmbg fizičkog lica
        /// </summary>
        public string Jmbg { get; set; }

        /// <summary>
        /// Adresa id
        /// </summary>
        public Guid AddressId { get; set; }

        /// <summary>
        /// Broj telefona fizičkog lica
        /// </summary>
        public string PhoneNumber1 { get; set; }

        /// <summary>
        /// Broj telefona 2 fizičkog lica
        /// </summary>
        public string PhoneNumber2 { get; set; }

        /// <summary>
        /// Email fizičkog lica
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Broj računa fizičkog lica
        /// </summary>
        public string AccountNumber { get; set; }

    }
}
