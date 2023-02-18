using Person.API.Enums;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Person.API.Models
{

    /// <summary>
    /// Represents a response model for a address record.
    /// </summary>
    [DataContract(Name = "Address", Namespace = "")]
    public class AddressResponseModel
    {
        /// <summary>
        /// Drzava
        /// </summary>
        [JsonConverter(typeof(CountryConverter))]
        [DataMember]
        public Country Country { get; set; }

        /// <summary>
        /// Ulica adrese
        /// </summary>
        [DataMember]
        public string Street { get; set; }

        /// <summary>
        /// Broj adrese
        /// </summary>
        [DataMember]
        public string StreetNumber { get; set; }

        /// <summary>
        /// Mesto adrese
        /// </summary>
        [DataMember]
        public string Place { get; set; }

        /// <summary>
        /// Postanski broj adrese
        /// </summary>
        [DataMember]
        public string ZipCode { get; set; }

        /// <summary>
        /// Represents an address response model.
        /// </summary>
        /// <param name="country">The country of the address.</param>
        /// <param name="street">The street name of the address.</param>
        /// <param name="streetNumber">The street number of the address.</param>
        /// <param name="place">The place of the address.</param>
        /// <param name="zipCode">The zip code of the address.</param>
        public AddressResponseModel(Country country, string street, string streetNumber, string place, string zipCode)

        {
            Country = country;
            Street = street;
            StreetNumber = streetNumber;
            Place = place;
            ZipCode = zipCode;

        }

    }
}
