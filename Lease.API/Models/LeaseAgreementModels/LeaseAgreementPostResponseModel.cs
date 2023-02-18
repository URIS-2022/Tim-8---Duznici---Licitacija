using Lease.API.Enums;
using System.Text.Json.Serialization;

namespace Lease.API.Models.LeaseAgreementModels;
public class LeaseAgreementPostResponseModel
{
    public Guid Guid { get; set; }

    [JsonConverter(typeof(GuaranteeTypeConverter))]
    public GuaranteeType GuaranteeType { get; set; }
    public string ReferenceNumber { get; set; }
    public DateTime DateRecording { get; set; }
    public Guid MinisterGuid { get; set; }
    public DateTime DeadlineLandReturn { get; set; }
    public string PlaceOfSigning { get; set; }
    public DateTime DateOfSigning { get; set; }
    public Guid? PublicBiddingGuid { get; set; }
    public Guid PersonGuid { get; set; }

    [JsonConverter(typeof(DocumentStatusConverter))]
    public DocumentStatus DocumentStatus { get; set; }
    public Guid DueDateGuid { get; set; }

    public LeaseAgreementPostResponseModel() { }
    public LeaseAgreementPostResponseModel(Guid Guid, GuaranteeType guaranteeType, string referenceNumber,
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
    }
}