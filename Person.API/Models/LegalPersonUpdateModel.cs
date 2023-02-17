using System.ComponentModel.DataAnnotations;

namespace Person.API.Models
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
        public Guid? ContactPersonId { get; set; }

        /// <summary>
        /// Naziv pravnog lica
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti naziv!")]
        public string? Name { get; set; }

        /// <summary>
        /// Matični broj pravnog lica
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti maticni broj!")]
        public string? IdentificationNumber { get; set; }

        /// <summary>
        /// Adresa id
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti id adrese!")]
        public Guid? AddressId { get; set; }

        /// <summary>
        /// Broj telefona pravnog lica
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti broj telefona 1!")]
        public string? PhoneNumber1 { get; set; }

        /// <summary>
        /// Broj telefona 2 pravnog lica
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti broj telefona 2!")]
        public string? PhoneNumber2 { get; set; }

        /// <summary>
        /// Faks pravnog lica
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti faks!")]
        public string? Fax { get; set; }

        /// <summary>
        /// Email pravnog lica
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti email!")]
        public string? Email { get; set; }

        /// <summary>
        /// Broj računa pravnog lica
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti broj racuna!")]
        public string? AccountNumber { get; set; }

        /// <summary>
        /// Represents a model used to update a legal person's information.
        /// </summary>
        public LegalPersonUpdateModel(Guid? contactPersonId, string? name, string? identificationNumber, Guid? addressId, string? phoneNumber1, string? phoneNumber2, string? fax, string? email, string? accountNumber)
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
