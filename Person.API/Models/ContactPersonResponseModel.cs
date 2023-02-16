using Person.API.Entities;
using System.Runtime.Serialization;

namespace Person.API.Models

{
    /// <summary>
    /// Represents a response model for a contact person record.
    /// </summary>
    [DataContract(Name = "ContactPerson", Namespace = "")]
    public class ContactPersonResponseModel
    {
        /// <summary>
        /// Ime kontakt osobe
        /// </summary>
        [DataMember] 
        public string FirstName { get; set; }


        /// <summary>
        /// Prezime kontakt osobe
        /// </summary>
        [DataMember] 
        public string LastName { get; set; }

        /// <summary>
        /// Funkcija kontakt osoba
        /// </summary>
        [DataMember] 
        public string Function { get; set; }

        /// <summary>
        /// Telefon kontakt osobe
        /// </summary>
        [DataMember] 
        public string PhoneNumber { get; set; }

        public ContactPersonResponseModel(string firstName, string lastName, string function, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Function = function;
            PhoneNumber = phoneNumber;

        }
    }
}