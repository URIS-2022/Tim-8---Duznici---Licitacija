using System.ComponentModel.DataAnnotations;
using Person.API.Data.Repository;
using Person.API.Entities;

namespace Person.API.Models
{
    /// <summary>
    /// Dto Create pravno lice
    /// </summary>
    public class LegalPersonRequestModel
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

        /// <summary>
        /// Represents a request model for creating a legal person.
        /// </summary>
        public LegalPersonRequestModel(Guid contactPersonId,string name, string identificationNumber, Guid addressId, string phoneNumber1,
                                           string phoneNumber2, string fax, string email, string accountNumber)
        {
            ContactPersonId = contactPersonId;
            Name = name;
            IdentificationNumber = identificationNumber;     
            AddressId = addressId;
            PhoneNumber1 = phoneNumber1;
            PhoneNumber2 = phoneNumber2;
            Fax = fax;
            Email = email;
            AccountNumber = accountNumber;
            
        }
    }
}
