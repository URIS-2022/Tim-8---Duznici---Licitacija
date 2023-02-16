using System.Runtime.Serialization;

namespace Person.API.Models
{

    /// <summary>
    /// Represents a response model for a physical person record.
    /// </summary>

    [DataContract(Name = "PhysicalPerson", Namespace = "")]
    public class PhysicalPersonResponseModel
    {
        /// <summary>
        /// Ime fizičkog lica
        /// </summary>
        [DataMember] 
        public string FirstName { get; set; }

        /// <summary>
        /// Prezime fizičkog lica
        /// </summary>

        [DataMember] 
        public string LastName { get; set; }

        /// <summary>
        /// Jmbg fizičkog lica
        /// </summary>
        [DataMember] 
        public string Jmbg { get; set; }

        /// <summary>
        /// Adresa id
        /// </summary>
        [DataMember]
        public Guid AddressId { get; set; }

        /// <summary>
        /// Broj telefona fizičkog lica
        /// </summary>
        [DataMember] 
        public string PhoneNumber1 { get; set; }

        /// <summary>
        /// Broj telefona 2 fizičkog lica
        /// </summary>
        [DataMember] 
        public string PhoneNumber2 { get; set; }

        /// <summary>
        /// Email fizičkog lica
        /// </summary>
        [DataMember]
        public string Email { get; set; }

        /// <summary>
        /// Broj računa fizičkog lica
        /// </summary>
        [DataMember]
        public string AccountNumber { get; set; }

        public PhysicalPersonResponseModel(string firstName, string lastName, string jmbg, Guid addressId, string phoneNumber1, string phoneNumber2, string email, string accountNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Jmbg = jmbg;
            AddressId = addressId;
            PhoneNumber1 = phoneNumber1;
            PhoneNumber2 = phoneNumber2;
            Email = email;
            AccountNumber = accountNumber;
        }
    }
}
