using System.ComponentModel.DataAnnotations;


namespace Person.API.Models
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
        public string? FirstName { get; set; }

        /// <summary>
        /// Prezime kontakt osobe
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti prezime!")]
        public string? LastName { get; set; }

        /// <summary>
        /// Funckija kontakt osobe
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti funkciju!")]
        public string? Function { get; set; }

        /// <summary>
        /// Telefon kontakt osobe
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti telefon!")]
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactPersonUpdateModel"/> class.
        /// </summary>
        /// <param name="firstName">The first name of the contact person.</param>
        /// <param name="lastName">The last name of the contact person.</param>
        /// <param name="function">The function of the contact person.</param>
        /// <param name="phoneNumber">The phone number of the contact person.</param>
        public ContactPersonUpdateModel(string? firstName, string? lastName, string? function, string? phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Function = function;
            PhoneNumber = phoneNumber;
        }
    }
}
