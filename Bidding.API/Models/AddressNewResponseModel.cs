using System.Runtime.Serialization;

namespace Bidding.API.Models
{
    /// <summary>
    /// Represents a response model for creating a new address.
    /// </summary>

    [DataContract(Name = "Address", Namespace = "")]
    public class AddressNewResponseModel
    {
        /// <summary>
        /// Gets or sets the unique identifier for the address.
        /// </summary>
        [DataMember]
        public Guid Guid { get; set; }

        /// <summary>
        /// Gets or sets the country of the address.
        /// </summary>

        [DataMember]
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the street of the address.
        /// </summary>
        [DataMember]
        public string Street { get; set; }

        /// <summary>
        /// Gets or sets the street number of the address.
        /// </summary>
        [DataMember]
        public string StreetNumber { get; set; }
        /// <summary>
        /// Gets or sets the place of the address.
        /// </summary>

        [DataMember]
        public string Place { get; set; }

        /// <summary>
        /// Gets or sets the ZIP code of the address.
        /// </summary>
        [DataMember]
        public string ZipCode { get; set; }
        /// <summary>
        /// Initializes a new instance of the AddressNewResponseModel class.
        /// </summary>


        public AddressNewResponseModel() { }

        /// <summary>
        /// Initializes a new instance of the AddressNewResponseModel class with the specified properties.
        /// </summary>
        /// <param name="country">The country of the address.</param>
        /// <param name="street">The street of the address.</param>
        /// <param name="streetNumber">The street number of the address.</param>
        /// <param name="place">The place of the address.</param>
        /// <param name="zipCode">The ZIP code of the address.</param>


        public AddressNewResponseModel(string country, string street, string streetNumber, string place, string zipCode)
        {
            Country = country;
            Street = street;
            StreetNumber = streetNumber;
            Place = place;
            ZipCode = zipCode;
        }
    }
}
