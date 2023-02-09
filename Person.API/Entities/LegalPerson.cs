﻿namespace Person.API.Entities
{
    public class LegalPerson
    {
        public Guid LegalPersonId { get; set; }
        public string Name { get; set; }
        public string IdentificationNumber { get; set; }
        public Guid AddressId { get; set; }
        public string PhoneNumber1 { get; set; }
        public string PhoneNumber2 { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string AccountNumber { get; set; }

    }
}