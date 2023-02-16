using Person.API.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


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
        [JsonConverter(typeof(CountryConverter))]
        public Country? Country { get; set; }

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


        public AddressUpdateModel(Country? country, string? street, string? streetNumber, string? place, string? zipCode)

        {
            Country = country;
            Street = street;
            StreetNumber = streetNumber;
            Place = place;
            ZipCode = zipCode;

        }


    }
}
