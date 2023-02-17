using Lease.API.Enums;
using System.Text.Json.Serialization;

namespace Lease.API.Models.LeaseAgreementModels;

public class LeaseAgreementPatchRequestModel
{
    public string? ReferenceNumber { get; set; }

    [JsonConverter(typeof(GuaranteeTypeConverter))]
    public GuaranteeType? GuaranteeType { get; set; }
 
    public DateTime? DateRecording { get; set; }

    public Guid? MinisterGuid { get; set; }
   
    public DateTime? DeadlineLandReturn { get; set; }

    public string? PlaceOfSigning { get; set; }

    public DateTime? DateOfSigning { get; set; }

    public Guid? BiddingGuid { get; set; }

    public Guid? PersonGuid { get; set; }

    [JsonConverter(typeof(DocumentStatusConverter))]
    public DocumentStatus? DocumentStatus { get; set; }
    
    public Guid? DueDateGuid { get; set; }

    public LeaseAgreementPatchRequestModel( string? referenceNumber, GuaranteeType? guaranteeType, DateTime? dateRecording, Guid? ministerGuid,
        DateTime? deadlineLandReturn, string? placeOfSigning, DateTime? dateOfSigning, Guid? biddingGuid,
        Guid? personGuid, DocumentStatus? documentStatus, Guid? dueDateGuid)
    {
      
        ReferenceNumber = referenceNumber;
        GuaranteeType = guaranteeType;
        DateRecording = dateRecording;
        MinisterGuid = ministerGuid;
        DeadlineLandReturn = deadlineLandReturn;
        PlaceOfSigning = placeOfSigning;
        DateOfSigning = dateOfSigning;
        BiddingGuid = biddingGuid;
        PersonGuid = personGuid;
        DocumentStatus = documentStatus;
        DueDateGuid = dueDateGuid;

    }

}