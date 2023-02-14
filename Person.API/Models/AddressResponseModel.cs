using System.Runtime.Serialization;

namespace Person.API.Models
{
    [DataContract (Name = "Address", Namespace ="")]
    public class AddressResponseModel
    {
        /// <summary>
        /// Drzava
        /// </summary>
        [DataMember]
        public string Country { get; set; }

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


        public AddressResponseModel(string country, string street, string streetNumber, string place, string zipCode)

        {
            Country = country;
            Street = street;
            StreetNumber = streetNumber;
            Place = place;
            ZipCode = zipCode;

        }

    }
}
