

using Bidding.API.Entities;
using Bidding.API.Enums;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Bidding.API.Models
{
    [DataContract(Name = "Address", Namespace = "")]
    public class AddressNewResponseModel
    {
        [DataMember]
        public Guid Guid { get; set; }

        [DataMember]
        public string Country { get; set; }
        [DataMember]
        public string Street { get; set; }
        [DataMember]
        public string StreetNumber { get; set; }
        [DataMember]
        public string Place { get; set; }
        [DataMember]
        public string ZipCode { get; set; }

        public AddressNewResponseModel() { }


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
