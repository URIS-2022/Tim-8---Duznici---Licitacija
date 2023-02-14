using Lease.API.Entities;
using Lease.API.Enums;
using System.Text.Json.Serialization;

namespace Lease.API.Models;
public class LeaseAgreementResponseModel
{
    public Guid Guid { get; set; }

    [JsonConverter(typeof(GuaranteeType))]
    public GuaranteeType GuaranteeType { get; set; }
    public string ReferenceNumber { get; set; }
    public DateTime DateRecording { get; set; }
    public Guid MinisterGuid { get; set; }
    public DateTime DeadlineLandReturn { get; set; }
    public string PlaceOfSigning { get; set; }
    public DateTime DateOfSigning { get; set; }
    public Guid PublicBiddingGuid { get; set; }
    public Guid PersonGuid { get; set; }

    [JsonConverter(typeof(DocumentStatusConverter))]
    public DocumentStatusConverter DocumentStatus { get; set; }
    public DueDate DueDate { get; set; }


    public LeaseAgreementResponseModel(Guid Guid, GuaranteeType guaranteeType, string referenceNumber,
        DateTime dateRecording, Guid ministerGuid, DateTime deadlineLandReturn, string placeOfSigning,
        DateTime dateOfSigning, Guid publicBiddingGuid, Guid personGuid, DocumentStatusConverter documentStatus, DueDate dueDate)
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
        DueDate = dueDate;
    }
}