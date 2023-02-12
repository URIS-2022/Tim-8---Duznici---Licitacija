namespace Lease.API.Models;
public class LeaseAgreementResponseModel
{
    public Guid Guid { get; set; }
    public string GuaranteeType { get; set; }
    public string ReferenceNumber { get; set; }
    public DateTime DateRecording { get; set; }
    public string MinisterFullName { get; set; }
    public DateTime DeadlineLandReturn { get; set; }
    public string PlaceOfSigning { get; set; }
    public DateTime DateOfSigning { get; set; }
    public Guid PublicBiddingGuid { get; set; }
    public Guid PersonGuid { get; set; }
    public string DocumentStatus { get; set; }
    public LeaseAgreementResponseModel(Guid Guid, string guaranteeType, string referenceNumber,
        DateTime dateRecording, string ministerFullName, DateTime deadlineLandReturn, string placeOfSigning,
        DateTime dateOfSigning, Guid publicBiddingGuid, Guid personGuid, string documentStatus)
    {
        this.Guid = Guid;
        GuaranteeType = guaranteeType;
        ReferenceNumber = referenceNumber;
        DateRecording = dateRecording;
        MinisterFullName = ministerFullName;
        DeadlineLandReturn = deadlineLandReturn;
        PlaceOfSigning = placeOfSigning;
        DateOfSigning = dateOfSigning;
        PublicBiddingGuid = publicBiddingGuid;
        PersonGuid = personGuid;
        DocumentStatus = documentStatus;
    }
}