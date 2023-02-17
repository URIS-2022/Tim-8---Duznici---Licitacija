using System.Runtime.Serialization;


namespace Bidding.API.Models
{
    [DataContract(Name = "Address", Namespace = "")]
    public class AdressResponseModel
    {
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
    }
}
