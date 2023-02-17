﻿using Licitation.API.Enums;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Licitation.API.Models.Document
{
    [DataContract(Name = "Document", Namespace = "")]
    public class DocumentGetResponseModel
    {
        [DataMember]
        public Guid Guid { get; set; }
        [DataMember]
        public Guid LicitationGuid { get; set; }

        [JsonConverter(typeof(DocumentTypeConverter))]
        [DataMember(Name = "DocumentType")]
        public DocumentType DocumentType { get; set; }
        [DataMember]
        public string ReferenceNumber { get; set; }
        [DataMember]
        public DateTime DateSubmitted { get; set; }
        [DataMember]
        public DateTime DateCertified { get; set; }
        [DataMember]
        public string Template { get; set; }

        public DocumentGetResponseModel(Guid guid, Guid licitationGuid, DocumentType documentType, string referenceNumber, DateTime dateSubmitted, DateTime dateCertified, string template)
        {
            Guid = guid;
            LicitationGuid = licitationGuid;
            DocumentType = documentType;
            ReferenceNumber = referenceNumber;
            DateSubmitted = dateSubmitted;
            DateCertified = dateCertified;
            Template = template;
        }
    }
}
