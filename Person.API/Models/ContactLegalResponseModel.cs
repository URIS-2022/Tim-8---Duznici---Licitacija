using System.Runtime.Serialization;
using Person.API.Entities;

namespace Person.API.Models
{
    /// <summary>
    /// Represents a response model for a contact person object in legal person record.
    /// </summary>

    [DataContract(Name = "ContactLegalResponseModel", Namespace = "")]
        public class ContactLegalResponseModel
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
        }
}
