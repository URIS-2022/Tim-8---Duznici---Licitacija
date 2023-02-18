﻿namespace Bidding.API.Models
{

    /// <summary>
    /// Represents a model for requesting an address.
    /// </summary>
    public class AddressRequestModel
    {
        /// <summary>
        /// Gets or sets the country of the address.
        /// </summary>

        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the street of the address.
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// Gets or sets the street number of the address.
        /// </summary>
        public string StreetNumber { get; set; }

        /// <summary>
        /// Gets or sets the place of the address.
        /// </summary>
        public string Place { get; set; }

        /// <summary>
        /// Gets or sets the ZIP code of the address.
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// Initializes a new instance of the AddressRequestModel class.
        /// </summary>
        public AddressRequestModel() { }

        /// <summary>
        /// Initializes a new instance of the AddressRequestModel class with the specified properties.
        /// </summary>
        /// <param name="country">The country of the address.</param>
        /// <param name="street">The street of the address.</param>
        /// <param name="streetNumber">The street number of the address.</param>
        /// <param name="place">The place of the address.</param>
        /// <param name="zipCode">The ZIP code of the address.</param>
        public AddressRequestModel(string country,string street,string streetNumber,string place,string zipCode)
        {
            Country = country;
            Street = street;
            StreetNumber = streetNumber;
            Place = place;
            ZipCode = zipCode;

        }
    }
}
