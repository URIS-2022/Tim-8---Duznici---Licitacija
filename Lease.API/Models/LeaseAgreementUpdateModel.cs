using Lease.API.Enums;

namespace Lease.API.Models;

public class LeaseAgreementUpdateModel
{
    public string? ReferenceNumber { get; set; }
    public string? GuaranteeType { get; set; }
    public string? MinisterFullName { get; set; }
    public DateTime? DeadlineLandReturn { get; set; }
    public string? PlaceOfSigning { get; set; }
    public DateTime? DateOfSigning { get; set; }
    public Guid? PublicBiddingGuid { get; set; }
    public Guid? PersonGuid { get; set; }
    public string? DocumentStatus { get; set; }


    public LeaseAgreementUpdateModel(string referenceNumber, string guaranteeType, string ministerFullName,
        DateTime deadlineLandReturn, string placeOfSigning, DateTime dateOfSigning, Guid publicBiddingGuid,
        Guid personGuid, string documentStatus)
    {
        ReferenceNumber = referenceNumber;
        GuaranteeType = guaranteeType;
        MinisterFullName = ministerFullName;
        DeadlineLandReturn = deadlineLandReturn;
        PlaceOfSigning = placeOfSigning;
        DateOfSigning = dateOfSigning;
        PublicBiddingGuid = publicBiddingGuid;
        PersonGuid = personGuid;
        DocumentStatus = documentStatus;
    }

}