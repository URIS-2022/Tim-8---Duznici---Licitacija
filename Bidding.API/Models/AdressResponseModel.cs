using System.Runtime.Serialization;


namespace Bidding.API.Models
{

    /// <summary>
    /// Represents a model for an address response.
    /// </summary>
    [DataContract(Name = "Address", Namespace = "")]
    public class AdressResponseModel
    {
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
    }
}
