namespace Payment.API.Models.PaymentModel;

public class PaymentRequestModel
{ 
    public string AccountNumber { get; set; }
    public string ReferenceNumber { get; set; }
    public decimal TotalAmount { get; set; }
    public Guid PayerGuid { get; set; }
    public string PaymentTitle { get; set; }
    public DateTime PaymentDate { get; set; }
    public Guid PublicBiddingGuid { get; set; }
    

    public PaymentRequestModel(string accountNumber, string referenceNumber, decimal totalAmount, Guid payerGuid, string paymentTitle, DateTime paymentDate, Guid publicBiddingGuid)
    {
        AccountNumber = accountNumber;
        ReferenceNumber = referenceNumber;
        TotalAmount = totalAmount;
        PayerGuid = payerGuid;
        PaymentTitle = paymentTitle;
        PaymentDate = paymentDate;
        PublicBiddingGuid = publicBiddingGuid;
    }
}
