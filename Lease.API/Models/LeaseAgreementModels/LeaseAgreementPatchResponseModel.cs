using Lease.API.Enums;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Lease.API.Models.LeaseAgreementModels;
public class LeaseAgreementPatchResponseModel
{
    [DataMember]
    public Guid Guid { get; set; }

    [DataMember]
    [JsonConverter(typeof(GuaranteeTypeConverter))]
    public GuaranteeType GuaranteeType { get; set; }
    [DataMember]
    public string ReferenceNumber { get; set; }
    [DataMember]
    public DateTime DateRecording { get; set; }
    [DataMember]
    public Guid MinisterGuid { get; set; }
    [DataMember]
    public DateTime DeadlineLandReturn { get; set; }
    [DataMember]
    public string PlaceOfSigning { get; set; }
    [DataMember]
    public DateTime DateOfSigning { get; set; }
    [DataMember]
    public Guid? PublicBiddingGuid { get; set; }
    [DataMember]
    public Guid PersonGuid { get; set; }
    [DataMember]
    [JsonConverter(typeof(DocumentStatusConverter))]
    public DocumentStatus DocumentStatus { get; set; }
    [DataMember]
    public Guid DueDateGuid { get; set; }

    public LeaseAgreementPatchResponseModel() { }
   /* public LeaseAgreementPatchResponseModel(Guid Guid, GuaranteeType guaranteeType, string referenceNumber,
        DateTime dateRecording, Guid ministerGuid, DateTime deadlineLandReturn, string placeOfSigning,
        DateTime dateOfSigning, Guid publicBiddingGuid, Guid personGuid, DocumentStatus documentStatus, Guid dueDateGuid)
    {
        this.Guid = Guid;
        GuaranteeType = guaranteeType;
        ReferenceNumber = referenceNumber;
        DateRecording = dateRecording;
        MinisterGuid = ministerGuid;
        DeadlineLandReturn = deadlineLandReturn;
        PlaceOfSigning = placeOfSigning;
        DateOfSigning = dateOfSigning;
        PublicBiddingGuid = publicBiddingGuid;
        PersonGuid = personGuid;
        DocumentStatus = documentStatus;
        DueDateGuid = dueDateGuid;
    } */
}