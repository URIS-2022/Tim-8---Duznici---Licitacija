using Person.API.Enums;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Person.API.Models
{
    public class AddressPersonResponseModel
    {
        
        public string Country { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string Place { get; set; }
        public string ZipCode { get; set; }
    }

    
}
