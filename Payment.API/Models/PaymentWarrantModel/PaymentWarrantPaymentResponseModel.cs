using System.Runtime.Serialization;

namespace Payment.API.Models.PaymentWarrantModel;

[DataContract(Name = "PaymentWarrantPaymentResponseModel", Namespace = "")]
public class PaymentWarrantPaymentResponseModel
{
    [DataMember]
    public Guid Guid { get; set; }

    [DataMember]
    public Guid PayerGuid { get; set; }
    [DataMember]
    public decimal TotalAmount { get; set; }
    [DataMember]
    public Guid PublicBiddingGuid { get; set; }

}
