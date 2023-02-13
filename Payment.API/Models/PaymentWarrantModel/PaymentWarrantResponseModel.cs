﻿using System.Runtime.Serialization;

namespace Payment.API.Models.PaymentWarrantModel;

[DataContract(Name = "PaymentWarrant", Namespace = "")]
public class PaymentWarrantResponseModel
{
    [DataMember]
    public string ReferenceNumber { get; set; }
    [DataMember]
    public Guid PayerGuid { get; set; }
    [DataMember]
    public decimal TotalAmount { get; set; }
    [DataMember]
    public Guid PublicBiddingGuid { get; set; }

    public PaymentWarrantResponseModel(string referenceNumber, Guid payerGuid, decimal totalAmount, Guid publicBiddingGuid)
    {
        ReferenceNumber = referenceNumber;
        PayerGuid = payerGuid;
        TotalAmount = totalAmount;
        PublicBiddingGuid = publicBiddingGuid;
    }
}