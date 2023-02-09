namespace Person.API.Entities
{
    public class Address
    {
        public Guid AddressID { get; set; }
        public string Country { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string Place { get; set; }
        public string ZipCode { get; set; }
    }
}
