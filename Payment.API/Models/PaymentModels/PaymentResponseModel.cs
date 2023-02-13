using Payment.API.Entities;
using Payment.API.Models.PaymentWarrantModel;
using System.Runtime.Serialization;

namespace Payment.API.Models.PaymentModels;

[DataContract(Name = "PaymentEntity", Namespace = "")]
public class PaymentResponseModel
{
    [DataMember]
    public string AccountNumber { get; set; }
    [DataMember]
    public string ReferenceNumber { get; set; }
    [DataMember]
    public decimal TotalAmount { get; set; }
    [DataMember]
    public Guid PayerGuid { get; set; }
    [DataMember]
    public string PaymentTitle { get; set; }
    [DataMember]
    public DateTime PaymentDate { get; set; }
    [DataMember]
    public Guid PublicBiddingGuid { get; set; }
    [DataMember]
    public PaymentWarrantResponseModel PaymentWarrant { get; set; }

    public PaymentResponseModel(string accountNumber, string referenceNumber, decimal totalAmount, Guid payerGuid, string paymentTitle, DateTime paymentDate, Guid publicBiddingGuid, PaymentWarrantResponseModel paymentWarrant)
    {
        AccountNumber = accountNumber;
        ReferenceNumber = referenceNumber;
        TotalAmount = totalAmount;
        PayerGuid = payerGuid;
        PaymentTitle = paymentTitle;
        PaymentDate = paymentDate;
        PublicBiddingGuid = publicBiddingGuid;
        PaymentWarrant = paymentWarrant;
    }
}
