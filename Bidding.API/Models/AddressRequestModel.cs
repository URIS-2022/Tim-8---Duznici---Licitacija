namespace Bidding.API.Models
{

    /// <summary>
    /// Represents a model for requesting an address.
    /// </summary>
    public class AddressRequestModel
    {

        public string Country { get; set; }

        public string Street { get; set; }

        public string StreetNumber { get; set; }

        public string Place { get; set; }

        public string ZipCode { get; set; }

        /// <summary>
        /// Initializes a new instance of the AddressRequestModel class.
        /// </summary>
        public AddressRequestModel() { }

        public AddressRequestModel(string country, string street, string streetNumber, string place, string zipCode)
        {
            Country = country;
            Street = street;
            StreetNumber = streetNumber;
            Place = place;
            ZipCode = zipCode;

        }
    }
}
