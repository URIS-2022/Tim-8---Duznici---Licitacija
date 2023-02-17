using Licitation.API.Entities;
using Licitation.API.Enums;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace Licitation.API.Models.Document
{
    [DataContract(Name = "Document", Namespace = "")]
    public class DocumentResponseModel
    {
            [DataMember]
            public Guid Guid { get; set; }

            [DataMember]
            public Guid LicitationGuid { get; set; }

            [JsonConverter(typeof(DocumentTypeConverter))]

            [DataMember(Name = "documentType")]
            public DocumentType DocumentType { get; set; }

            [DataMember]
            public string ReferenceNumber { get; set; }

            [DataMember]

            public DateTime DateSubmitted { get; set; } 

            [DataMember]
            public DateTime DateCertified { get; set; }

            [DataMember]
            public string Template { get; set; }

            public DocumentResponseModel(Guid licitation, DocumentType documentType, string referenceNumber, DateTime dateSubmitted, DateTime dateCertified, string template)
            {

                Guid = Guid.NewGuid();
                this.LicitationGuid = licitation;
                DocumentType = documentType;
                ReferenceNumber = referenceNumber;
                DateSubmitted = dateSubmitted;
                DateCertified = dateCertified;
                Template = template;
            }



        
    }
}
