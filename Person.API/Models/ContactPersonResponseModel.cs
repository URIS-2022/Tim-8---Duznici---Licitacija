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
        /// <summary>
        /// Represents an contact person response model.
        /// </summary>
        /// <param name="firstName">The first name of the contact person.</param>
        /// <param name="lastName">The last name of the contact person.</param>
        /// <param name="function">The function of the contact person.</param>
        /// <param name="phoneNumber">The phone number of the contact person.</param>
        public ContactPersonResponseModel(string firstName, string lastName, string function, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Function = function;
            PhoneNumber = phoneNumber;

        }
    }
}