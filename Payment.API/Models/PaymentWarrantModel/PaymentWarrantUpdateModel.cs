namespace Payment.API.Models.PaymentWarrantModel;

public class PaymentWarrantUpdateModel
{ 

    //public string? ReferenceNumber { get; set; }
    public Guid? PayerGuid { get; set; }
    public decimal? TotalAmount { get; set; }
    public Guid? PublicBiddingGuid { get; set; }

    public PaymentWarrantUpdateModel(/*string? referenceNumber,*/ Guid? payerGuid, decimal? totalAmount, Guid? publicBiddingGuid)
    {
        //ReferenceNumber = referenceNumber;
        PayerGuid = payerGuid;
        TotalAmount = totalAmount;
        PublicBiddingGuid = publicBiddingGuid;
    }
}
