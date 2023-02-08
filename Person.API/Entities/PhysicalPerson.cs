namespace Person.API.Entities
{
    public class PhysicalPerson
    {
        public Guid PhysicalPersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Jmbg { get; set; }
        public Guid AddressId { get; set; }
        public string PhoneNumber1 { get; set; }
        public string PhoneNumber2 { get; set; }
        public string Email { get; set; }
        public string AccountNumber { get; set; }
    }
}
