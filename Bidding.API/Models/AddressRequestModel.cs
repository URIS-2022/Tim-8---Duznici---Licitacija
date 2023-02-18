namespace Bidding.API.Models
{
    public class AddressRequestModel
    {

        public string Country { get; set; }

        public string Street { get; set; }

        public string StreetNumber { get; set; }

        public string Place { get; set; }

        public string ZipCode { get; set; }

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
