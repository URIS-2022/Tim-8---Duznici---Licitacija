using Person.API.Enums;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Person.API.Models
{

    /// <summary>
    /// Represents a response model for a address record.
    /// </summary>
    [DataContract (Name = "Address", Namespace ="")]
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
