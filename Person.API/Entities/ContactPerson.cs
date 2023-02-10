namespace Person.API.Entities
{
    public class ContactPerson
    {
        public Guid ContactPersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Function { get; set; }
        public string PhoneNumber { get; set; }
    }
}
