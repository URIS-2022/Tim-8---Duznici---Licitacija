using System.ComponentModel.DataAnnotations;


namespace Person.API.Models.Address
{
    /// <summary>
    /// DTO za kreiranje adrese
    /// </summary>
    public class AddressCreationModel
    {
        /// <summary>
        /// DrzavA
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti naziv drzave")]
        public string Country { get; set; }

        /// <summary>
        /// Ulica adrese
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti ulicu")]
        public string Street { get; set; }

        /// <summary>
        /// Broj adrese
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti broj")]
        public string StreetNumber { get; set; }

        /// <summary>
        /// Mesto adrese
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti mesto")]
        public string Place { get; set; }

        /// <summary>
        /// Postanski broj adrese
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti postanski broj")]
        public string ZipCode { get; set; }


    }
}
