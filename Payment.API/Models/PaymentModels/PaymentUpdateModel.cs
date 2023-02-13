namespace Payment.API.Models.PaymentModels;

public class PaymentUpdateModel
{ 
    public string? AccountNumber { get; set; }
    public string ReferenceNumber { get; set; }
    public decimal? TotalAmount { get; set; }
    public Guid PayerGuid { get; set; }
    public string? PaymentTitle { get; set; }
    public DateTime? PaymentDate { get; set; }
    public Guid? PublicBiddingGuid { get; set; }
    public Guid? PaymentWarrantGuid { get; set; }////////////////////////////////////////// i ovde response warr?

    public PaymentUpdateModel(string? accountNumber, string referenceNumber, decimal? totalAmount, Guid payerGuid, string? paymentTitle, DateTime? paymentDate, Guid? publicBiddingGuid, Guid? paymentWarrantGuid)
    {
        AccountNumber = accountNumber;
        ReferenceNumber = referenceNumber;
        TotalAmount = totalAmount;
        PayerGuid = payerGuid;
        PaymentTitle = paymentTitle;
        PaymentDate = paymentDate;
        PublicBiddingGuid = publicBiddingGuid;
        PaymentWarrantGuid = paymentWarrantGuid;
    }
}
