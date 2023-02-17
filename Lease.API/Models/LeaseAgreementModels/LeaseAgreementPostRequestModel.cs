using Lease.API.Entities;
using Lease.API.Enums;
using System.Text.Json.Serialization;

namespace Lease.API.Models.LeaseAgreementModels;

public class LeaseAgreementPostRequestModel
{
    public string ReferenceNumber { get; set; }

    [JsonConverter(typeof(GuaranteeTypeConverter))]
    public GuaranteeType GuaranteeType { get; set; }

    public DateTime DateRecording { get; set; }
    public Guid MinisterGuid { get; set; }
    public DateTime DeadlineLandReturn { get; set; }
    public string PlaceOfSigning { get; set; }
    public DateTime DateOfSigning { get; set; }
    public Guid PublicBiddingGuid { get; set; }
    public Guid PersonGuid { get; set; }

    [JsonConverter(typeof(DocumentStatusConverter))]
    public DocumentStatus DocumentStatus { get; set; }

    public Guid DueDateGuid { get; set; }


    public LeaseAgreementPostRequestModel(string referenceNumber, GuaranteeType guaranteeType, DateTime dateRecording, Guid ministerGuid,
        DateTime deadlineLandReturn, string placeOfSigning, DateTime dateOfSigning, Guid publicBiddingGuid,
        Guid personGuid, DocumentStatus documentStatus, Guid dueDateGuid)
    {
        ReferenceNumber = referenceNumber;
        GuaranteeType = guaranteeType;
        MinisterGuid = ministerGuid;
        DateRecording = dateRecording;
        DeadlineLandReturn = deadlineLandReturn;
        PlaceOfSigning = placeOfSigning;
        DateOfSigning = dateOfSigning;
        PublicBiddingGuid = publicBiddingGuid;
        PersonGuid = personGuid;
        DocumentStatus = documentStatus;
        DueDateGuid = dueDateGuid;
    }

}