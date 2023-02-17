using Person.API.Entities;
using System.Runtime.Serialization;

namespace Person.API.Models
{

    /// <summary>
    /// Represents a response model for a legal person record.
    /// </summary>

    [DataContract(Name = "ContactPerson", Namespace = "")]
    public class LegalPersonResponseModel
        { /// <summary>
          /// Id kontakt osobe
          /// </summary>
        [DataMember]
        public Guid ContactPersonId { get; set; }
        /// <summary>
        /// Naziv pravnog lica
        /// </summary>
        [DataMember]
        public string? Name { get; set; }

        /// <summary>
        /// Matični broj pravnog lica
        /// </summary>
        
        [DataMember]
        public string? IdentificationNumber { get; set; }
        /// <summary>
        /// Adresa id
        /// </summary>
        [DataMember]
        public Guid AddressId { get; set; }
        /// <summary>
        /// Broj telefona pravnog lica
        /// </summary>

        [DataMember] 
        public string? PhoneNumber1 { get; set; }

        /// <summary>
        /// Broj telefona 2 pravnog lica
        /// </summary>
        [DataMember] 
        public string? PhoneNumber2 { get; set; }

        /// <summary>
        /// Faks pravnog lica
        /// </summary>
        [DataMember]
        public string? Fax { get; set; }

        /// <summary>
        /// Email pravnog lica
        /// </summary>
        [DataMember]
        public string? Email { get; set; }

        /// <summary>
        /// Broj računa pravnog lica
        /// </summary>
        [DataMember]
        public string? AccountNumber { get; set; }

        /// <summary>
        /// Gets or sets the contact legal person information.
        /// </summary>
        public ContactLegalResponseModel? ContactLegalPerson { get; set; }
        /// <summary>
        /// Gets or sets the address information.
        /// </summary>
        public AddressPersonResponseModel? Address { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LegalPersonResponseModel"/> class.
        /// </summary>
        public LegalPersonResponseModel() { }
        

        /// <summary>
        /// Represents an legal person response model.
        /// </summary>
        public LegalPersonResponseModel(Guid contactPersonId, ContactLegalResponseModel contactLegalPerson, string name, string identificationNumber, Guid addressId, string phoneNumber1, string phoneNumber2, string fax, string email, string accountNumber)
        {
            ContactPersonId = contactPersonId;
            Name = name;
            IdentificationNumber = identificationNumber;
            AddressId = addressId;
            PhoneNumber1 = phoneNumber1;
            PhoneNumber2 = phoneNumber2;
            Fax = fax;
            Email = email;
            AccountNumber = accountNumber;
            ContactLegalPerson = contactLegalPerson;
            
        }
    }

}

