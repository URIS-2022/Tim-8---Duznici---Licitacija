namespace Person.API.Models
{
    /// <summary>
    /// Represents an address object belonging to a person.
    /// </summary>
    public class AddressPersonResponseModel
    {
        /// <summary>
        /// The country of the address.
        /// </summary>
        public string? Country { get; set; }
        /// <summary>
        /// The street name of the address.
        /// </summary>
        public string? Street { get; set; }
        /// <summary>
        /// The street name of the address.
        /// </summary>
        public string? StreetNumber { get; set; }
        /// <summary>
        /// The name of the city or town of the address.
        /// </summary>
        public string? Place { get; set; }
        /// <summary>
        /// The postal code of the address.
        /// </summary>
        public string? ZipCode { get; set; }
    }


}
