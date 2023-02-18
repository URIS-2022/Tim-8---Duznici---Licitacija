using System.Runtime.Serialization;

/// <summary>
/// Represents the response model for a payment warrant.
/// </summary>
[DataContract(Name = "PaymentWarrant", Namespace = "")]
public class PaymentWarrantResponseModel
{
    /// <summary>
    /// Gets or sets the GUID of the payment warrant.
    /// </summary>
    [DataMember]
    public Guid Guid { get; set; }

    /// <summary>
    /// Gets or sets the reference number of the payment warrant.
    /// </summary>
    [DataMember]
    public string ReferenceNumber { get; set; }

    /// <summary>
    /// Gets or sets the GUID of the payer associated with the payment warrant.
    /// </summary>
    [DataMember]
    public Guid PayerGuid { get; set; }

    /// <summary>
    /// Gets or sets the total amount of the payment warrant.
    /// </summary>
    [DataMember]
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// Gets or sets the GUID of the public bidding associated with the payment warrant.
    /// </summary>
    [DataMember]
    public Guid PublicBiddingGuid { get; set; }

    /// <summary>
    /// Initializes a new instance of the PaymentWarrantResponseModel class with the specified values.
    /// </summary>
    /// <param name="referenceNumber">The reference number of the payment warrant.</param>
    /// <param name="payerGuid">The GUID of the payer associated with the payment warrant.</param>
    /// <param name="totalAmount">The total amount of the payment warrant.</param>
    /// <param name="publicBiddingGuid">The GUID of the public bidding associated with the payment warrant.</param>
    public PaymentWarrantResponseModel(string referenceNumber, Guid payerGuid, decimal totalAmount, Guid publicBiddingGuid)
    {
        Guid = Guid.NewGuid();
        ReferenceNumber = referenceNumber;
        PayerGuid = payerGuid;
        TotalAmount = totalAmount;
        PublicBiddingGuid = publicBiddingGuid;
    }
}

