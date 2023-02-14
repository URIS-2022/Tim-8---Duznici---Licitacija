using System.ComponentModel.DataAnnotations;


namespace Person.API.Models
{
    /// <summary>
    /// DTO za update adrese
    /// </summary>
    public class AddressUpdateModel
    {

        /// <summary>
        /// Drzava
        /// </summary>
        [Required(ErrorMessage = "Obavezno je naziv drzave")]
        public string? Country { get; set; }

        /// <summary>
        /// Ulica adrese
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti ulicu")]
        public string? Street { get; set; }

        /// <summary>
        /// Broj adrese
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti broj")]
        public string? StreetNumber { get; set; }

        /// <summary>
        /// Mesto adrese
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti mesto")]
        public string? Place { get; set; }

        /// <summary>
        /// Postanski broj adrese
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti postanski broj")]
        public string? ZipCode { get; set; }


        public AddressUpdateModel(string? country, string? street, string? streetNumber, string? place, string? zipCode)

        {
            Country = country;
            Street = street;
            StreetNumber = streetNumber;
            Place = place;
            ZipCode = zipCode;

        }


    }
}
